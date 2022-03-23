using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private LayerMask dashLayerMask;
    private const float MOVEMENTSPEED = 10f ;
    private Rigidbody2D rigidBody2D;
    private Vector3 moveDirection;
    private Vector3 dashPosition;
    private Vector3 lastDirection;
    private float moveY, moveX;
    private float dashAmount;
    private Dictionary<string,bool> Skills = new Dictionary<string, bool>();

    private void Start()
    {
        Skills.Add("dash", false);
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveX = 0f;
        moveY = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
        moveDirection = new Vector3(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = moveDirection * MOVEMENTSPEED;
        if(moveDirection!=new Vector3(0, 0))
        {
            lastDirection = moveDirection;
        }
        //checks if there is enough Stamina to perform dash
        

    }

    private void Dash() 
    {
        if (Skills["dash"]&&PlayerManager.instance.player.GetComponent<PlayerStamina>().useAbility(10))
        {
            dashAmount = 5f;
            Vector3 centerOfHero = new Vector3(transform.position.x, transform.position.y + 1.2f);
            bool hit = Physics2D.CircleCast(centerOfHero, .5f, lastDirection, dashAmount, dashLayerMask);
            // Casting circular rayCast, only returns bool if it hit something in specified layer, might be used to varify result;
            while (hit)
            {
                dashAmount -= .1f;
                hit = Physics2D.CircleCast(centerOfHero, .5f, lastDirection, dashAmount, dashLayerMask);
                if (dashAmount <= 0) break;
            }
            Debug.Log(centerOfHero);
            dashPosition = transform.position + lastDirection * dashAmount;
            rigidBody2D.MovePosition(dashPosition);
            return;

        }
        else
        {
            Skills["dash"] = true;
            Debug.Log("Skill is not unlocked yet!");
            return;
        }
    }
}
