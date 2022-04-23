using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int maxHealt = 100;
    [Header("Enemy attributes")]
    [SerializeField] 
    private string _nameOfEnemy;
    [SerializeField]
    [Range(3,50)]
    private int _XP;

    public bool isAlive = true;
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealt;
    }
    /// <summary>
    /// enemy gets damaged
    /// </summary>
    /// <param name="dmg"></param>
    public void getsDamaged(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Death();
            isAlive = false;
        }
    }
    /// <summary>
    /// enemy dies and gives player exp
    /// </summary>
    public void Death()
    {
        PlayerManager.instance.player.GetComponent<PlayerXP>().addExp(_XP);
        Debug.Log(_nameOfEnemy + " died!");
    }
}   
