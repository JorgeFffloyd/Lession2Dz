using UnityEngine;

public enum Element 
{
    None,
    Fire,
    Ice
}
public class DamageCalc : MonoBehaviour
{
    private bool isCrit, isElement;
    [Header("Параметры оружия")]
    public int baseDmg = 10;
    public Element weaponElement;
    [SerializeField] public float critChance = 0.3f;

    [Header("Параметры противника")]
    public int armor = 3;
    public Element enemyElement;

    private int finalDmg;

    void CalcDamage() 
    {
        isCrit = false;
        isElement = false;
        finalDmg = baseDmg - armor;//1
        if (finalDmg < 1)
            finalDmg = 1;
        if (enemyElement != Element.None && weaponElement != Element.None)//2
        {
            if (enemyElement == weaponElement)
            {
                finalDmg = 0;
                return;
            }
            else
            {
                float ElementCrit = finalDmg * 1.5f;
                finalDmg = Mathf.FloorToInt(ElementCrit);
                isElement = true;
            }
            
        }
        float randomVal = Random.value; //3
        if (randomVal < critChance)
        {
            finalDmg *= 2;
            isCrit = true;
        }
    }

    void Start()
    {
        
        for (int i = 1; i <= 3; i++) 
        {
            CalcDamage();
            string elementText = isElement ? "Стихия x1.5" : "Без стихии";
            string critText = isCrit ? "Крит" : "Без крита";

            Debug.Log($"Удар {i}: {finalDmg} урона (стихихихия: {elementText}, Крит: {critText})");
        }

    }
}
