using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 direction;
    private int dmg;
    private Rigidbody2D rb;
    private double dies;
    void Start()
    {
        rotate();
        dies = Time.time + 3;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;
        if (dies < Time.time)
        {
            Destroy(gameObject);
        }
    }

    public void setDmg(int damage)
    {
        dmg = damage;
    }

    private void rotate()
    {
        Vector2 position = PlayerManager.instance.center.transform.position;
        direction = (new Vector3 (position.x, position.y-0.2f) - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerManager.instance.player.GetComponent<PlayerHP>().Damaged(dmg);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}