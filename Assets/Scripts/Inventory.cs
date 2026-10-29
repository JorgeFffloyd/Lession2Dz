using UnityEngine;
using System.Collections.Generic;
public class Inventory
{
    private Dictionary<string, int> items = new Dictionary<string, int>();
    private const int Max_slots = 10;

    public void AddItem(string item, int count = 1)
    {
        if (items.ContainsKey(item))
        {
            items[item] += count;
        }
        else
        {
            if (items.Count >= Max_slots)
            {
                Debug.LogWarning($"Нет места для «{item}»: занято {items.Count} из {Max_slots}");
            }
            else
            {
                items.Add(item, count);
            }
        }
  
    }
    public void RemoveItem(string item, int count = 1)
    {
        if (!items.ContainsKey(item))
        {
            Debug.LogWarning($"Нельзя убрать «{item}»: его нет в инвентаре");
            return;
        }

        if (items[item] < count)
        {
            Debug.LogWarning($"Нельзя убрать {count} шт. «{item}»: в наличии только {items[item]}");
            return;
        }

        items[item] -= count;

        if (items[item] <= 0)
        {
            items.Remove(item);
        }
    }
       public void Print()
        {
            foreach (KeyValuePair<string, int> pair in items)
                Debug.Log($"{pair.Key} x{pair.Value}");

            int totalCount = 0;
            foreach (var item in items)
            {
                totalCount += item.Value;
            }
            Debug.Log($"кол-во уникальных предметов {items.Count}, общее кол-во {totalCount}");
        }
}
