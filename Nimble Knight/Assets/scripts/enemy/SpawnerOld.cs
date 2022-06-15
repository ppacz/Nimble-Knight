using System.Collections.Generic;
using UnityEngine;

public class SpawnerOld : MonoBehaviour
{

    [Header("Spawner atributes")]
    [SerializeField]
    private GameObject[] enemiesToSpawn; //list of enemies that can be spawned
    [SerializeField]
    private int amountOfEnemies;
    [SerializeField]
    private float timeBetweenSpawns;
    [SerializeField]
    private LayerMask nonSpawnableLayers;//layers where enemy shouldnt be able to spawn at all
    [SerializeField]
    private List<Transform> spawnPoints = new List<Transform>();
    //list that takes care of how many enemies should be spawned by each spawner
    [SerializeField]
    private List<List<GameObject>> enemiesList = new List<List<GameObject>>();
    private float time;

    #region singleton
    public static SpawnerOld instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion


    private void Start()
    {
        time = timeBetweenSpawns;
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            enemiesList.Add(new List<GameObject>());
        }
    }
    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Spawning();
            time = timeBetweenSpawns;
        }
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
        for (int i = 0; i < enemiesList.Count; i++)
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
        GameObject enemy = (GameObject)Instantiate(enemiesToSpawn, position, new Quaternion(0,0,0,0));
        enemies.Add(enemy);
    }*/
    /*
     * this one should work with more than one spawner, each spawner needs to have same parent
     */
    private void createEnemy(Transform spawnPoint, List<GameObject> enemies)
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
        GameObject enemy = (GameObject) Instantiate(enemiesToSpawn[1], position, new Quaternion(0, 0, 0, 0));
        enemies.Add(enemy);
    }



    /*public void deleteEnemy(GameObject enemy)
    {
            enemies.Remove(enemy);
    }*/

    public void deleteEnemy(GameObject enemy)
    {
        foreach (List<GameObject> enemies in enemiesList)
        {
            Debug.Log((enemy as UnityEngine.Object) == null);
        }
    }
}