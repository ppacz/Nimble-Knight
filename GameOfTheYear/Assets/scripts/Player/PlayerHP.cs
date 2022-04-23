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

    /// <summary>
    /// If save loads save
    /// 
    /// </summary>
    void Start()
    {
        PlayerData player = SaveSystem.LoadPlayer();
        if(player==null) currentHealth = maxHealth;
        else
        {
            maxHealth = player.maxHealth;
            currentHealth = player.currentHealth;
        }
        wasDamaged = true;
        slider.maxValue = maxHealth;
        updateUI();

    }
    /// <summary>
    /// loads death scene if player dies
    /// </summary>
    void Update()
    {   
        if (!alive) SceneManager.LoadScene("Death");
    }

    /// <summary>
    /// damages player and manages death;
    /// </summary>
    /// <param name="dmg"></param>
    public void Damaged(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            alive = false;
        }
        wasDamaged = true;
        updateUI();
    }

    /// <summary>
    /// heals player for desired amount
    /// </summary>
    /// <param name="amount"></param>
    public void Heal(int amount)
    {
        if (currentHealth + amount >= maxHealth) 
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        wasDamaged = true;
    }
    public int HP() => currentHealth;
    /// <summary>
    /// updates UI
    /// </summary>
    private void updateUI()
    {
        HPtext.text = currentHealth + "/" + maxHealth;
        wasDamaged = false;
        slider.value = currentHealth;
    }

}
