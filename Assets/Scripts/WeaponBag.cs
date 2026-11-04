using UnityEngine;
using System.Collections.Generic;


public class WeaponBag
{
    private List<Weapon> weapons = new List<Weapon>();

    public void Add(Weapon w)
    {
        weapons.Add(w);
    }

    public List<Weapon> GetAll()
    {
        return weapons;
    }
}