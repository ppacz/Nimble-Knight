using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private int enemyCount = 1;
    [SerializeField]
    private bool showGizmos = false;
    [SerializeField]
    private GameObject enemyTospawn;
    [SerializeField]
    private float spawnRadius=2f;
    [SerializeField]
    private float spawnRate=10f;
    [SerializeField]
    private LayerMask nonSpawnableLayers;
    private double time;
    private List<GameObject> enemies;

    private void Start()
    {
        time = Time.time;
        enemies = new List<GameObject>();
    }

    /// <summary>
    /// removes dead enemies and takes care of when to spawn more of them
    /// </summary>
    private void Update()
    {
        removeDeadEnemies();
        if (time < Time.time)
        {
            spawnEnemies(enemyCount-enemies.Count);
            time = Time.time + spawnRate;

        }
    }
    /// <summary>
    /// deleting emnemies from the list
    /// </summary>
    private void removeDeadEnemies()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].GetComponent<EnemyHP>().isAlive) 
            { 
                Destroy(enemies[i]);
                enemies.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// spawns enemies on random spots in certain radius on valid spots
    /// </summary>
    /// <param name="amount">spawn amount</param>
    private void spawnEnemies(int amount)
    {   
        for(int i = 0; i < amount; i++) { 
            int tryes = 0;
            float rx = Random.Range(spawnRadius * -.5f, spawnRadius * .5f);
            float ry = Random.Range(spawnRadius * -.5f, spawnRadius * .5f);
            Vector3 position = new Vector3(transform.position.x + rx, transform.position.y + ry);
            Collider2D[] hitObstacle;
            hitObstacle = Physics2D.OverlapCircleAll(position, 1f, nonSpawnableLayers);
            while (hitObstacle.Length != 0)
            {
                if (tryes > 10) return;
                rx = Random.Range(-5f, 5f);
                ry = Random.Range(-5f, 5f);
                position = new Vector3(transform.position.x + rx, transform.position.y + ry);
                hitObstacle = Physics2D.OverlapCircleAll(position, 1f, nonSpawnableLayers);
                tryes++;
            }
            GameObject enemy = (GameObject)Instantiate(enemyTospawn, position, new Quaternion(0, 0, 0, 0));
            enemies.Add(enemy);
        }
    }
    /// <summary>
    /// draws spawn radius
    /// </summary>
    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }
}
