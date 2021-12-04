using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public TMP_Text HPtext;
    public bool alive = true;
    public int maxHealth;
    private int currentHealth;
    private bool wasDamaged;

    // Update is called once per frame
    void Start()
    {
        wasDamaged = true;
        currentHealth = maxHealth;   
    }
    void Update()
    {
        if (wasDamaged)
        {
            HPtext.text = "HP " + currentHealth + "/" + maxHealth;
            wasDamaged = false;
        }

        if (!alive) SceneManager.LoadScene("Death");
    }

    public void Damaged(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth < 0)
        {
            alive = false;
        }
        wasDamaged = true;
    }

}
