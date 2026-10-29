using UnityEngine;

public class UnitPlus
{
    public string Name;
    public int Health;
    public int MinDamage;
    public int MaxDamage;
    public int Armor;
    public Element MyElement;
    public float CritChance;

    public Inventory MyInventory = new Inventory();

    public UnitPlus(string name, int hp, int minD, int maxD, int armor, Element element, float crit)
    {
        Name = name;
        Health = hp;
        MinDamage = minD;
        MaxDamage = maxD;
        Armor = armor;
        MyElement = element;
        CritChance = crit;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public void Attack(UnitPlus target)
    {
        int finalDmg = Random.Range(MinDamage, MaxDamage + 1);

        finalDmg = finalDmg - target.Armor;
        if (finalDmg < 1) finalDmg = 1;
        //  стихиха
        if (MyElement != Element.None && target.MyElement != Element.None)
        {
            if (MyElement == target.MyElement)
            {
                finalDmg = 0;
                Debug.Log($"{Name} атакует {target.Name}, одинаковые стихии");
                return;
            }
            else
            {
                finalDmg = Mathf.FloorToInt(finalDmg * 1.5f);
            }
        }

        bool isCrit = false;
        if (Random.value < CritChance)
        {
            finalDmg *= 2;
            isCrit = true;
        }

        target.Health -= finalDmg;
        if (target.Health < 0) target.Health = 0;

        string critText = isCrit ? "(крит)" : "";
        Debug.Log($"{Name} наносит {finalDmg} урона {target.Name} {critText}. осталось хзп: {target.Health}");
    }
}