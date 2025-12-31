using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    [SerializeField] float speed = 5.0f;
    [SerializeField] float jumpHeight = 5.0f;
    [SerializeField] GroundCheck groundCheck;
    private int health;

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

        if(health == 0)
        {
            ReloadScene();
        }

        isGrounded = groundCheck.isGrounded;
        anim.SetBool("IsJumping", !isGrounded);
        Debug.Log(isGrounded);
        Move();
        if (Input.GetKey(KeyCode.D) && isGrounded)
        {
            anim.SetBool("IsRunning", true);

        }
        else if (Input.GetKey(KeyCode.A) && isGrounded)
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
        rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
    }
        

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KillBarrier")
        {
            ReloadScene();

        }
    }

    private static void ReloadScene()
    {
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }
}
