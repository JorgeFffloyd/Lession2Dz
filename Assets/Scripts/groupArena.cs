using System.Collections.Generic;
using UnityEngine;

public class groupArena : MonoBehaviour
{
    [SerializeField] private int maxRounds = 20; 

    private List<UnitPlus> heroes = new List<UnitPlus>();
    private List<UnitPlus> enemies = new List<UnitPlus>();

    void Awake()
    {

        UnitPlus warrior = new UnitPlus("Воин", 100, 5, 0.2f);
        Weapon sword = new Weapon("Меч", 15, Element.Fire);
        warrior.Bag.Add(sword);
        warrior.EquippedWeapon = sword;
        heroes.Add(warrior);

        UnitPlus mage = new UnitPlus("Маг", 80, 2, 0.3f);
        Weapon staff = new Weapon("Посох", 12, Element.Ice);
        mage.Bag.Add(staff);
        mage.EquippedWeapon = staff;
        heroes.Add(mage);


        UnitPlus orc = new UnitPlus("Орк", 80, 3, 0.1f);
        Weapon axe = new Weapon("Топор", 10, Element.None);
        orc.Bag.Add(axe);
        orc.EquippedWeapon = axe;
        enemies.Add(orc);
    }

    void Start()
    {
        int round = 0;
        while (heroes.Exists(h => h.IsAlive()) && enemies.Exists(e => e.IsAlive()) && round < maxRounds)
        {
            round++;
            Debug.Log($" Раунод номер:{round}");

            foreach (var hero in heroes)
            {
                if (!hero.IsAlive()) continue;
                var target = enemies.Find(e => e.IsAlive());
                if (target != null)
                {
                    hero.Attack(target);
                    if (!target.IsAlive()) Loot(target, hero);
                }
            }

            foreach (var enemy in enemies)
            {
                if (!enemy.IsAlive()) continue;
                var target = heroes.Find(h => h.IsAlive());
                if (target != null)
                {
                    enemy.Attack(target);
                    if (!target.IsAlive()) Loot(target, enemy);
                }
            }
        }

      
        if (heroes.Exists(h => h.IsAlive()) && !enemies.Exists(e => e.IsAlive()))
            Debug.Log("победа!");
        else if (!heroes.Exists(h => h.IsAlive()) && enemies.Exists(e => e.IsAlive()))
            Debug.Log("поражение!");
        else
            Debug.Log("Время вышло. Ничья");
    }

    private void Loot(UnitPlus dead, UnitPlus looter)
    {
        Debug.Log($"{dead.Name} погиб. Забираем лут.");
        List<Weapon> items = dead.Bag.GetAll();
        foreach (var w in items)
        {
            looter.Bag.Add(w);
            if (looter.EquippedWeapon == null) looter.EquippedWeapon = w; 
        }
    }
}