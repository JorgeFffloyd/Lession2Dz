using UnityEngine;

public class UnitPlus : Unit
{
    public int Armor { get; private set; }
    public float CritChance { get; private set; }
    public Weapon EquippedWeapon { get; set; }
    public WeaponBag Bag { get; private set; }

    public UnitPlus(string name, int hp, int armor, float crit) : base(name, hp, 0, 0)
    {
        Armor = armor;
        CritChance = crit;
        Bag = new WeaponBag();
    }

    public void Attack(UnitPlus target)
    {
        int baseDmg = EquippedWeapon != null ? EquippedWeapon.BaseDamage : 1;
        Element myElem = EquippedWeapon != null ? EquippedWeapon.elementWeapon : Element.None;
        Element targetElem = target.EquippedWeapon != null ? target.EquippedWeapon.elementWeapon : Element.None;

        int finalDmg = baseDmg - target.Armor;
        if (finalDmg < 1) finalDmg = 1;

        if (myElem != Element.None && targetElem != Element.None)
        {
            if (myElem == targetElem)
            {
                finalDmg = 0;
            }
            else
            {
                finalDmg = Mathf.FloorToInt(finalDmg * 1.5f);
            }
        }

        if (finalDmg > 0 && Random.value < CritChance)
        {
            finalDmg *= 2;
        }

        target.TakeDamage(finalDmg);

        Debug.Log($"{Name} бьет {target.Name} на {finalDmg} урона. У цели {target.Health} HP");
    }
}