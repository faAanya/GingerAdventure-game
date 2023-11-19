using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
   
    [Header("Animation")]
    private Animator anim;
    private enum MovementState { stay, running, jumping, falling }

    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Moving and Shooting")]
    [SerializeField] private float movesSpeed = 8f;
    [SerializeField] private float jumpForce = 16f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] GameObject shotPoint;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private float dirX = 0f;

    [Header("Wall jumping")]
    private Vector2 _wallNormal;
    private bool _canWallJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;

      
    }
    private void Update()
    {


            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * movesSpeed, rb.velocity.y); //moving


            if (Input.GetButtonDown("Jump") && IsGrounded()) //also checks is there is a ground
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); //jump
            }
        


    
        UpdateAnumationState();
    }

    private void UpdateAnumationState()
    {
        float rotationScale = 0f;
        sprite.transform.rotation = Quaternion.Euler(0f, 0f, rotationScale);
        MovementState state;
        if (dirX > 0f )
        {
            //shotPoint.transform.Rotate(0f, 180f, 0f);
            state = MovementState.running;  //going right animation
            sprite.flipX = false;   
        }
        else if (dirX < 0f )
        {
            //shotPoint.transform.Rotate(0f, 180f, 0f);
            state = MovementState.running; //going left animation
            sprite.flipX = true;

        }
        else
        {
            state = MovementState.stay; //static animation
        }

        if(rb.velocity.y > .1f)
        {
           
            state = MovementState.jumping;
            if(rb.velocity.x > 0)
            {
                rotationScale = 7f;
                sprite.transform.rotation = Quaternion.Euler(0f, 0f, rotationScale); //rotation while jumping to right
 
            }
           
            else if (rb.velocity.x < 0)
            {
                rotationScale = -7f;
                sprite.transform.rotation = Quaternion.Euler(0f, 0f, rotationScale); //rotation while jumping to left
            }
            else sprite.transform.rotation = Quaternion.Euler(0f, 0f, rotationScale);

        }
        if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        if (Input.GetKey("s") && IsGrounded()) //also checks is there is a ground
        {
            state = MovementState.falling; //jump
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded() //checks the ground
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size,0f,Vector2.down, .1f, jumpableGround);
    }

   
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("TriggerDeath");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
