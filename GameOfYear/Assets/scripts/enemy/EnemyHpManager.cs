using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpManager : MonoBehaviour
{
    public int maxHealt = 100;
    private int currentHealth;
    public GameObject counter;
    private Counter count;
    void Start()
    {
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

    
}
