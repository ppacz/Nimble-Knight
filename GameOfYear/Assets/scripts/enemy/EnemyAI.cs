using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D target;
    public float speed = 10f;
    public float nextWaypointDistance = 3f;
    float distanceFromPlayer;
    public float attackSpeed = 2;
    double timer;

    Path path;
    int currnetWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        player = PlayerManager.instance.player;
        target = player.GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

    }
    void UpdatePath()
    {
        if(seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
        Debug.Log(distanceFromPlayer);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currnetWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += 0.2;
        getDistance();
        if (path == null) return;
        if (distanceFromPlayer > 3) { 
            if (currnetWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }
            Vector2 direction = ((Vector2)path.vectorPath[currnetWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currnetWaypoint]);
            if (distance < nextWaypointDistance)
            {
                currnetWaypoint++;
            }
        }
        else
        {
            if (timer > attackSpeed)
            {
                player.GetComponent<PlayerHP>().Damaged(1);
                timer = 0;
            }
        }
    }

    void getDistance()
    {
        distanceFromPlayer = Mathf.Sqrt((rb.position.x - player.transform.position.x) * (rb.position.x - player.transform.position.x) + (rb.position.x - player.transform.position.x) * (rb.position.x - player.transform.position.x));
    }
}
