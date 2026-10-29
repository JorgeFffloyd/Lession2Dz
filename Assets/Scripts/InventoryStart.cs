using UnityEngine;
public class InventoryStart : MonoBehaviour
{
    private Inventory myInventory;

    void Start()
    {
        myInventory = new Inventory();

        myInventory.AddItem("Меч");
        myInventory.AddItem("Щит");

        myInventory.AddItem("Меч");//стакак
        myInventory.AddItem("Зелье", 3);// количественая проверка

        myInventory.RemoveItem("Лук"); // удаление отст предмета

        myInventory.AddItem("Палка");
        myInventory.AddItem("Яблоко");
        myInventory.AddItem("Сыр");
        myInventory.AddItem("Шкарпэтки");
        myInventory.AddItem("Печенье бамбук");
        myInventory.AddItem("Козье копыто");

        myInventory.AddItem("Фингерборд");
        myInventory.AddItem("Фингерборд(покруче)");//ошибка

        myInventory.Print();//инвентарь

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
