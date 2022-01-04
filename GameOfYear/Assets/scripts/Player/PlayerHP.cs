using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public TMP_Text HPtext; //Reference to text in slider
    public bool alive = true;
    public int maxHealth;
    public Slider slider; //Reference to slider
    private int currentHealth;
    private bool wasDamaged;

    // Update is called once per frame
    void Start()
    {   
        //changes values to ones that are set in editor
        wasDamaged = true;
        slider.maxValue = maxHealth;
        currentHealth = maxHealth;

    }
    void Update()
    {   
        //updates slider and health
        if (wasDamaged)
        {
            HPtext.text = "HP " + currentHealth + "/" + maxHealth;
            wasDamaged = false;
            slider.value = currentHealth;
        }
        //shows death scene
        if (!alive) SceneManager.LoadScene("Death");
    }

    public void Damaged(int dmg)//Decreses health
    {
        currentHealth -= dmg;
        if (currentHealth < 0)
        {
            alive = false;
        }
        wasDamaged = true;
    }

}
