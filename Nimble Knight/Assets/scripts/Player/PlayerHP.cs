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
    public int regen = 1;
    [Range(0f,1f)]
    [SerializeField] private float alpha;
    private Image panel;

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
        slider.maxValue = maxHealth;
        updateUI();
        InvokeRepeating("Heal", 0f, 3f);
        panel = GameObject.Find("HitEffect").GetComponent<Image>();
    }
    /// <summary>
    /// loads death scene if player dies
    /// </summary>
    void Update()
    {   
        if (!alive) SceneManager.LoadScene("Death");
    }

    private void FixedUpdate()
    {
        if (panel.color.a > 0)
        {
            Debug.Log(panel.color.a);
            panel.color = new Color(255, 0, 0, panel.color.a-0.01f);
        }
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
        panel.color = new Color(255, 0, 0, alpha);
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
        updateUI();
    }
    public void Heal()
    {
        if (currentHealth + regen >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += regen;
        }
        updateUI();
    }
    public int HP() => currentHealth;
    /// <summary>
    /// updates UI
    /// </summary>
    private void updateUI()
    {
        HPtext.text = currentHealth + "/" + maxHealth;
        slider.value = currentHealth;
    }

}
