using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.3f;
    public LayerMask enemyLayers;
    public int dmg = 20;
    [SerializeField]
    private Camera _cam;
    [SerializeField]
    private Transform _centerTransform;

    // Update is called once per frame
    void Update()
    {
        Vector3 _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (_mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        _centerTransform.eulerAngles = new Vector3(0, 0, angle);
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        
    }

    void Attack()
    {
        //TODO add player attack animation
        //damage enemies

        Collider2D[] hitEnemies =Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHP>().getsDamaged(dmg);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}