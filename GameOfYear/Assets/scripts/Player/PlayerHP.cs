using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public TMP_Text HPtext;
    public bool alive = true;
    public int maxHealth;
    public Slider slider;
    private int currentHealth;
    private bool wasDamaged;

    // Update is called once per frame
    void Start()
    {
        wasDamaged = true;
        slider.maxValue = maxHealth;
        currentHealth = maxHealth;

    }
    void Update()
    {
        if (wasDamaged)
        {
            HPtext.text = currentHealth + "/" + maxHealth;
            wasDamaged = false;
            slider.value = currentHealth;
        }
        
        if (!alive) SceneManager.LoadScene("Death");
    }

    public void Damaged(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            alive = false;
        }
        wasDamaged = true;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        wasDamaged = true;
    }

}
