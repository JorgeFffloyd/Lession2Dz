using UnityEngine;

 public enum Element
    {
        None,
        Fire,
        Ice
    }

public class Weapon
{ 
   

    public string Name;
    public int BaseDamage;
    public Element elementWeapon;

   

    public Weapon(string name, int baseDamage, Element element)
    {
        Name = name;
        BaseDamage = baseDamage;
        elementWeapon = element;
    }
    /*
    public int GetPower()
    {
        int power = BaseDamage;

        
        if (Element != Element.None)
        {
            power += 5;
        }

        return power;
    }
    Неиспользуемый метод
    */
}



