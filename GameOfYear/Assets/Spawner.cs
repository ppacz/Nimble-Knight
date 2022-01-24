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
    
    //private List<GameObject> enemies = new List<GameObject>();
    //private float time;
    private List<List<GameObject>> enemiesList = new List<List<GameObject>>();
    private Transform[] spawnPoints;
    #region singleton
    public static Spawner instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion


    private void Start()
    {
        //time = timeBetweenSpawns;
        spawnPoints = gameObject.GetComponentsInChildren<Transform>(false);
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            enemiesList.Add(new List<GameObject>());
        }
        InvokeRepeating("Spawning", 5f, timeBetweenSpawns);
    }
    /*
    // this one is one that works with single spanwer
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
    }*/
    private void Spawning()
    {
        for(int i = 0; i < enemiesList.Count; i++)
        {
            while (enemiesList[i].Count < amountOfEnemies)
            {
                createEnemy(spawnPoints[i], enemiesList[i]);
            }
        }
    }

    /*
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
    }*/
    /*
     * this one should work with more than one spawner, each spawner needs to have same parent
     */
    private void createEnemy(Transform spawnPoint,List<GameObject> enemies)
    {
        int tryes = 0;
        float rx = Random.Range(-10f, 10f);
        float ry = Random.Range(-10f, 10f);
        Vector3 position = new Vector3(spawnPoint.position.x + rx, spawnPoint.position.y + ry);
        Collider2D[] hitObstacle;
        hitObstacle = Physics2D.OverlapCircleAll(position, 1f, nonSpawnableLayers);
        while (hitObstacle.Length != 0)
        {
            if (tryes > 10) return; 
            rx = Random.Range(-5f, 5f);
            ry = Random.Range(-5f, 5f);
            position = new Vector3(spawnPoint.position.x + rx, spawnPoint.position.y + ry);
            hitObstacle = Physics2D.OverlapCircleAll(position, 1f, nonSpawnableLayers);
            tryes++;
        }
        GameObject enemy = (GameObject)Instantiate(enemyToSpawn, position, new Quaternion(0, 0, 0, 0));
        enemies.Add(enemy);
    }



    /*public void deleteEnemy(GameObject enemy)
    {
            enemies.Remove(enemy);
    }*/

    public void deleteEnemy(GameObject enemy)
    {
        foreach(List<GameObject> enemies in enemiesList)
        {
            enemies.Remove(enemy);
        }
    }
}
