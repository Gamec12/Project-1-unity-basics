using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 5.0f;
    [SerializeField] float jumpHeight = 5.0f;

    //[SerializeField] LayerMask groundMask;
    //[SerializeField] Transform feetPosition;

    private bool isJumping = false;

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
        //float groundCheckRadius = 0.3f;

        Move();
        if (Input.GetKey(KeyCode.D))
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

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            //Jump();
            anim.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isJumping)
        {

            anim.SetTrigger("Attack");
        }







    }

    private void Jump()
    {
        if (isJumping)
        {
            float moveY = Input.GetAxis("Vertical");

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            isJumping = false;
            
        }
    }
        

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");

        transform.position += Vector3.right* moveX  * speed * Time.deltaTime;
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
