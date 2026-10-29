using System.Collections.Generic;
using UnityEngine;

public class groupArena : MonoBehaviour
{
    private List<UnitPlus> heroes = new List<UnitPlus>();
    private List<UnitPlus> enemies = new List<UnitPlus>();

    void Awake()
    {
        UnitPlus warrior = new UnitPlus("Воин", 100, 10, 16, 5, Element.Ice, 0.3f);
        warrior.MyInventory.AddItem("Меч");
        heroes.Add(warrior);

        UnitPlus mage = new UnitPlus("Маг", 80, 6, 12, 2, Element.Fire, 0.3f);
        mage.MyInventory.AddItem("Посох");
        heroes.Add(mage);

        UnitPlus ork = new UnitPlus("Орк 1", 80, 5, 10, 3, Element.Ice, 0.2f);
        ork.MyInventory.AddItem("Топор");
        enemies.Add(ork);

        UnitPlus goblin = new UnitPlus("Гоблин", 50, 4, 8, 0, Element.Fire, 0.1f);
        enemies.Add(goblin);
    }

    void Start()
    {
        
        while (heroes.Exists(hero => hero.IsAlive()) && enemies.Exists(enemy => enemy.IsAlive()))
        {
            foreach (var hero in heroes)
            {
                if (!hero.IsAlive()) continue;

                UnitPlus target = enemies.Find(enemy => enemy.IsAlive());
                if (target != null) { 
                    hero.Attack(target); 
                    if (!target.IsAlive())
                    {
                        Debug.Log($"{target.Name} Мертв");
                       // if (target.Element == Element.Fire && enemy)
                            LootInventory(target, hero);
                       // else
                          //  Debug.Log("Нет смысла");
                        
                    }
                }
            }

            // ход2
            foreach (var enemy in enemies)
            {
                if (!enemy.IsAlive()) continue;

                UnitPlus target = heroes.Find(hero => hero.IsAlive());
                if (target != null)
                {
                    enemy.Attack(target);

                    if (!target.IsAlive())
                    {
                        Debug.Log($"{target.Name} мертв");
                        LootInventory(target, enemy); 
                    }
                }
            }
        }


        if (heroes.Exists(hero => hero.IsAlive()))
            Debug.Log("Победа");
        else
            Debug.Log("Поражение");
    }

    private void LootInventory(UnitPlus deadUnit, UnitPlus looter)
    {
        var deadManItems = deadUnit.MyInventory.GetItems();

        foreach (var pair in deadManItems)
        {
            looter.myInventory.AddItem(pair.Key, pair.Value);
            Debug.Log($"{looter.Name} подобрал {pair.Key} x{pair.Value} с тела {deadUnit.Name}");
        }
    }
}