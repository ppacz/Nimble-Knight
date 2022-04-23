using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private LayerMask dashLayerMask;
    private const float MOVEMENTSPEED = 130f ;
    private Rigidbody2D rigidBody2D;
    private Vector3 moveDirection;
    private Vector3 dashPosition;
    private Vector3 lastDirection;
    private float moveY, moveX;
    private float dashAmount;
    private SkillUnlocking skillsSet;
    
    /// <summary>
    /// sets skill if there are none and thase needed references
    /// </summary>
    private void Start()
    {   
        skillsSet = gameObject.GetComponent<SkillUnlocking>();
        skillsSet.setSkills("dash");
        skillsSet.setSkills("smash");
        skillsSet.setSkills("fireball");
        rigidBody2D = GetComponent<Rigidbody2D>();
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            rigidBody2D.MovePosition(new Vector2(data.position[0], data.position[1]));
        }
    }
    /// <summary>
    /// manages inputs and takes care if other instant actions
    /// </summary>
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
        if (Input.GetKeyUp(KeyCode.F))
        {
            PlayerManager.instance.skillTree.SetActive(!PlayerManager.instance.skillTree.activeSelf);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            SaveSystem.SavePlayer(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
        moveDirection = new Vector3(moveX, moveY).normalized;
    }

    /// <summary>
    /// physics update
    /// </summary>
    private void FixedUpdate()
    {
        rigidBody2D.velocity = 4 * MOVEMENTSPEED * Time.deltaTime * moveDirection;
        if(moveDirection!=new Vector3(0, 0))
        {
            lastDirection = moveDirection;
        }
    }
    /// <summary>
    /// dash ability that uses stamine and needs to be unlocked in skillTree
    /// </summary>
    private void Dash()
    {
        if (skillsSet.getState("dash") && PlayerManager.instance.player.GetComponent<PlayerStamina>().useAbility(10))
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

            Debug.Log("Skill is not unlocked yet!");
            return;
        }
    }
}
