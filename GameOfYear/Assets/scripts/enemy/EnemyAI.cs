using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public int dmg = 1;
    private GameObject center;
    private GameObject player;
    private Transform target;
    private float range = 10f;
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
        player = PlayerManager.instance.player; //player reference
        center = PlayerManager.instance.center; //center reference
        target = center.GetComponent<Transform>(); //gets transfrom of center so enemy can navigate to it
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f); //timed repeating of function

    }
    void UpdatePath()
    {
        //updates path every .5 seconds, how often enemy changes path to the closest one
        if(seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
        Debug.Log(distanceFromPlayer);
    }
    void OnPathComplete(Path p)//creates path
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
        //manages time before attacking
        timer += 0.2;
        //updates distance
        getDistance();
        //if player is close enough or path isn't needed yet, returns;
        if (path == null) return;
        if (distanceFromPlayer > 3 && distanceFromPlayer < range) { 
            //choses next waypoint to travel to
            if (currnetWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }
            //calculates direction of enemy that it should move into
            Vector2 direction = ((Vector2)path.vectorPath[currnetWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            //addds force
            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currnetWaypoint]);
            if (distance < nextWaypointDistance)
            {
                currnetWaypoint++;
            }
        }else if (distanceFromPlayer > range) return;//returns if player is too far
        else
        {   
            if (timer > attackSpeed) //attacks only if is close enough to player
            {
                player.GetComponent<PlayerHP>().Damaged(dmg);
                timer = 0;
            }
        }
    }

    private void getDistance()//gets distance between player and enemy in units
    {
        distanceFromPlayer = Vector3.Distance(rb.position, target.position);   
    }
}
