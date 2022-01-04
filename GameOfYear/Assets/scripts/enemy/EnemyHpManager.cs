using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpManager : MonoBehaviour
{
    public int maxHealt = 100;
    private int currentHealth;
    private Counter count;
    private GameObject counter;
    void Start()
    {   
        counter = CounterManager.instance.counter;
        currentHealth = maxHealt;
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
    }
    //counter needs to be changed, needs to add funtion that will take care of correct counter
    //that will be in spawner
    
}
