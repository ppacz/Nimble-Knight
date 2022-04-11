using UnityEngine;
using Pathfinding;

public class EnemyAIRanged : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField]
    [Range(1, 100)]
    private int dmg;
    [SerializeField]
    [Range(50,150)]
    private float speed;
    [SerializeField]
    private float nextWaypointDistance = 3;
    [SerializeField]
    [Range(0, 50)]
    private float followRange;
    [SerializeField]
    [Range(0.5f, 10)]
    private float attackSpeed;
    [SerializeField]
    [Range(20,50)]
    private float range = 4;
    [SerializeField]
    private Transform enemyCenter;
    [SerializeField]
    private GameObject projectile;

    [Header("Attacking layer")]
    [SerializeField]
    private LayerMask playerMask;


    private bool reachedEndOfPath = false;
    private int currentWaypoint = 0;
    private float recoveryFromAttacks = 0.5f;
    private float distanceFromPlayer;
    private double nextAttack;
    private double ableToMove;

    private GameObject center;
    private Seeker seeker;
    private Rigidbody2D rb;
    private Path path;
    private Transform target;
   



    // Start is called before the first frame update
    void Start()
    {
        ableToMove = Time.time;
        nextAttack = Time.time;
        center = PlayerManager.instance.center;
        target = center.GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

    }
    void UpdatePath()
    {
        //updates path every .5 seconds
        if (seeker.IsDone())
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
        if (ableToMove > Time.time) return;
        getDistance();
        if (path == null) return;
        if (distanceFromPlayer > followRange) return;
        else if (!canHit() && distanceFromPlayer < followRange)
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
            Debug.Log(rb.drag);
            Vector2 force = direction * speed * 4 * Time.deltaTime;
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
                GameObject shot = Instantiate(projectile, enemyCenter);
                shot.GetComponent<Projectile>().setDmg(dmg);
                nextAttack = Time.time + attackSpeed;
                ableToMove = Time.time + recoveryFromAttacks;
            }
        }
    }

    private void getDistance()
    {
        distanceFromPlayer = Vector3.Distance(rb.position, target.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private bool canHit()
    {
        Vector3 aimDirection = (center.transform.position - enemyCenter.position).normalized;
        return !Physics2D.CircleCast(enemyCenter.position,.5f,new Vector2(aimDirection.x, aimDirection.y), distanceFromPlayer,playerMask);
    }

}