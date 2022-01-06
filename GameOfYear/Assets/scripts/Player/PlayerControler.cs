using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private LayerMask dashLayerMash;
    private const float MOVEMENTSPEED = 10f ;
    private Rigidbody2D rigidBody2D;
    private Vector3 moveDirection;
    private float moveY, moveX;
    private bool isDashing = false;
    private float dashAmount = 5f;

    private void Awake()
    {   
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
            isDashing = true;
        }
        moveDirection = new Vector3(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = moveDirection * MOVEMENTSPEED;

        if (isDashing)
        {
            Vector3 dashPosition = transform.position + moveDirection * dashAmount;

            RaycastHit2D rayCastHit2D = Physics2D.Raycast(transform.position, moveDirection, dashAmount, dashLayerMash);
            if (rayCastHit2D.collider != null)
            {
                dashPosition = rayCastHit2D.point;
            }
            rigidBody2D.MovePosition(dashPosition);
            isDashing = false;
        }

    }
}
