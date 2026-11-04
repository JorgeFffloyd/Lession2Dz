using UnityEngine;
public class InventoryStart : MonoBehaviour
{
    private Inventory m_inventory;

    void Start()
    {
        m_inventory = new Inventory();

        m_inventory.AddItem("Меч");
        m_inventory.AddItem("Щит");

        m_inventory.AddItem("Меч");
        m_inventory.AddItem("Зелье", 3);

        m_inventory.RemoveItem("Лук"); 

        m_inventory.AddItem("Палка");
        m_inventory.AddItem("Яблоко");
        m_inventory.AddItem("Сыр");
        m_inventory.AddItem("Шкарпэтки");
        m_inventory.AddItem("Печенье бамбук");
        m_inventory.AddItem("Козье копыто");

        m_inventory.AddItem("Фингерборд");
        m_inventory.AddItem("Фингерборд(покруче)");

        m_inventory.Print();

    }

    void Update()
    {
        
    }
}
