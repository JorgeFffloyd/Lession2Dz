using UnityEngine;

public class Arena : MonoBehaviour
{
    [Header("Настройки арены")]
    [SerializeField] private int maxRounds = 10;
    [SerializeField] private bool isHeroWarrior = true;

    private Unit hero;
    private Unit enemy;

    void Awake()
    {
        if (isHeroWarrior)
            hero = new Unit("Воин", 100, 10, 16);
        else
            hero = new Unit("Маг", 130, 6, 12);
        int randomEnemy = Random.Range(1, 4);
        switch (randomEnemy)
        {
            case 1:
                enemy = new Unit("Гоблин", 50, 4, 8);
                break;
            case 2:
                enemy = new Unit("Орк", 80, 5, 10);
                break;
            case 3:
                enemy = new Unit("Троль", 140, 8, 12);
                break;
        }
    }
    void Start()
    {
        Debug.Log($"{hero.Name} ({hero.Health} HP) против {enemy.Name} ({enemy.Health} HP)");

        for (int round = 1; round <= maxRounds; round++)
        {
            if (!hero.IsAlive() || !enemy.IsAlive()) break;
            int heroDamage = hero.GetDamage();
            enemy.TakeDamage(heroDamage);
            Debug.Log($"Раунд {round}: {hero.Name} наносит {heroDamage}, у противника {enemy.Health} HP");

            if (!enemy.IsAlive()) break;

            int enemyDamage = enemy.GetDamage();
            hero.TakeDamage(enemyDamage);
            Debug.Log($"{enemy.Name} наносит {enemyDamage}, у героя {hero.Health} HP");
        }

        if (hero.IsAlive() && !enemy.IsAlive())
        {
            Debug.Log($"Победа. Хп героя: {hero.Health}");
        }
        else if (!hero.IsAlive() && enemy.IsAlive())
        {
            Debug.Log("Поражение");
        }
        else 
        {
            Debug.Log("Ничья");
        }
    }
}
