using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpManager : MonoBehaviour
{
    public int maxHealt = 100;
    private int currentHealth;
    private Counter count;
    private GameObject counter;
    private Spawner spawner;
    void Start()
    {
        counter = CounterManager.instance.counter;
        currentHealth = maxHealt;
        spawner = Spawner.instance;
        count = counter.GetComponent<Counter>();
    }

    public void getsDamaged(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death() 
    {
        Debug.Log("Enemy died!");
        count.Died();
        Destroy(gameObject);
        spawner.GetComponent<Spawner>().deleteEnemy(gameObject);
    }

    
}
