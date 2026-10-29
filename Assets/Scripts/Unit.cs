using UnityEngine;

public class Unit
{
    public string Name;
    public int Health;
    public int MinDamage;
    public int MaxDamage;

    public Unit(string name, int health, int minDmg, int maxDmg)
    {
        Name = name;
        Health = health;
        MinDamage = minDmg;
        MaxDamage = maxDmg;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }

    public bool IsAlive() 
    {
        return Health > 0;
    }
    public int GetDamage() 
    {
        return Random.Range(MinDamage, MaxDamage + 1);
    }
}
