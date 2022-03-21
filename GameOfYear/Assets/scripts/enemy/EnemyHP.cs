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

    private void Death()
    {
        PlayerManager.instance.GetComponent<PlayerXP>().addExp(_XP);
        Debug.Log(_nameOfEnemy+" died!");
        Spawner.instance.deleteEnemy(gameObject);
        if(gameObject)  Destroy(gameObject);
    }

}   
