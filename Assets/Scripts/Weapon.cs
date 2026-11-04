using UnityEngine;

 public enum Element
    {
        None,
        Fire,
        Ice
    }

public class Weapon
{ 
   

    public string name;
    public int baseDamage;
    public Element elementWeapon;

   

    public Weapon(string name, int baseDamage, Element element)
    {
        this.name = name;
        this.baseDamage = baseDamage;
        this.elementWeapon = element;
    }
    /*
    public int GetPower()
    {
        int power = BaseDamage;

        
        if (Element != Element.None)
        {
            power += 1;
        }

        return power;
    }
    ∆дЄт своего часа
    */
}



