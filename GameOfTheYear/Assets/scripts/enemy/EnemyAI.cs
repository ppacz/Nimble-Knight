using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    private int dmg;
    [SerializeField]
    [Range(0, 200)]
    private float speed;
    [SerializeField]
    private float nextWaypointDistance = 3;
    [SerializeField]
    [Range(0, 50)]
    private float followRange;
    [SerializeField]
    [Range(0.5f,5)]
    private float attackSpeed;
    [SerializeField]
    [Range(1,8)]
    private float range = 4;

    private GameObject center;
    private GameObject player;
    private Transform target;
    private float distanceFromPlayer;
    private double nextAttack;
    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;
    private Seeker seeker;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        nextAttack = Time.time;
        player = PlayerManager.instance.player;
        center = PlayerManager.instance.center;
        target = center.GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

    }
    void UpdatePath()
    {
        //updates path every .5 seconds
        if(seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        getDistance();
        if (path == null) return;
        if (distanceFromPlayer > followRange) return;
        else if (distanceFromPlayer > range && distanceFromPlayer < followRange)
        {
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;
            rb.AddForce(force);
            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            if (nextAttack <= Time.time)
            {
                player.GetComponent<PlayerHP>().Damaged(dmg);
                nextAttack = Time.time + attackSpeed;
            }
        }
    }

    private void getDistance()
    {
        distanceFromPlayer = Vector3.Distance(rb.position, target.position);   
    }
}
