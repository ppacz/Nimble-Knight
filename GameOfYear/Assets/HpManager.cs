using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    public int maxHealt = 100;
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealt;
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
    }

    
}
