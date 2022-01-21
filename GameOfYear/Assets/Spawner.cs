using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    
    [Header("Spawner atributes")]
    [SerializeField]
    private GameObject enemyToSpawn;
    [SerializeField]
    private int amountOfEnemies;
    [SerializeField]
    private float timeBetweenSpawns;
    [SerializeField]
    private LayerMask nonSpawnableLayers;//layers where enemy shouldnt be able to spawn at all
    
    private List<GameObject> enemies = new List<GameObject>();
    private float time;

    #region singleton
    public static Spawner instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion


    private void Start()
    {
        time = timeBetweenSpawns;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = timeBetweenSpawns;
            while (enemies.Count != amountOfEnemies)
            {
                createEnemy();
            }

            
        }
    }



    private void createEnemy()
    {
        float rx = Random.Range(-10f, 10f);
        float ry = Random.Range(-10f, 10f);
        Vector3 position = new Vector3(gameObject.transform.position.x+rx, gameObject.transform.position.y+ry);
        Collider2D[] hitObstacle; 
        hitObstacle = Physics2D.OverlapCircleAll(position, 1f, nonSpawnableLayers);
        while (hitObstacle.Length != 0)
        {
            rx = Random.Range(-5f, 5f);
            ry = Random.Range(-5f, 5f);
            position = new Vector3(gameObject.transform.position.x + rx, gameObject.transform.position.y + ry);
            hitObstacle = Physics2D.OverlapCircleAll(position, 1f, nonSpawnableLayers);
        }
        GameObject enemy = (GameObject)Instantiate(enemyToSpawn, position, new Quaternion(0,0,0,0));
        enemies.Add(enemy);
    }

    public void deleteEnemy(GameObject enemy)
    {
        try
        {
            enemies.Remove(enemy);
        }
        catch
        {
            Debug.Log("This enemy wasn't spawned by spawner");
        }
    }
}
