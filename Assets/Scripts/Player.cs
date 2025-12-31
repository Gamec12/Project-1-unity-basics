using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 5.0f;
    [SerializeField] float jumpHeight = 5.0f;

    private bool isGrounded = false;

    Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {


        Move();
        if (Input.GetKey(KeyCode.D) )
        {
            anim.SetBool("IsRunning", true);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("IsRunning", true);

        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded)
        {

            anim.SetTrigger("Attack");
        }







    }

    private void Jump()
    {
        
        float moveY = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
        isGrounded = false;
            
        
    }
        

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");

        //transform.position += Vector3.right* moveX  * speed * Time.deltaTime;
        float newVelocity = moveX * speed;
        rb.linearVelocity = new Vector2(newVelocity, rb.linearVelocity.y); 
        if (moveX > 0) 
        {
            spriteRenderer.flipX = false;
            
        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        }
    }



}
