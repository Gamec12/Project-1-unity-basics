using System;
using System.Collections;
using Unity.Collections;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    [SerializeField] float speed = 5.0f;
    [SerializeField] float jumpHeight = 5.0f;
    [SerializeField] GroundCheck groundCheck;
    private int health = 100;

    private bool isGrounded = false;
    private bool isInvulnerable = false;
    private float maxHealth = 100;
    Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private float flashDuration = 0.5f;




    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
       

    }
    void Update()
    {

        if(health <= 0)
        {
            ReloadScene();
        }

        isGrounded = groundCheck.isGrounded;
        anim.SetBool("IsJumping", !isGrounded);

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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
        }



    }

    private void shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Bullet bulletScript = newBullet.GetComponent<Bullet>();

        float directionX = spriteRenderer.flipX ? -1f : 1f;

        Vector2 launchDirection = new Vector2(directionX, 0f);

        bulletScript.Launch(launchDirection);


    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
    }


    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");

        if (Mathf.Abs(moveX) > 0.01f)
        {

            float targetVelocityX = moveX * speed;
            float speedDif = targetVelocityX - rb.linearVelocity.x;


            rb.AddForce(Vector2.right * speedDif * 10f);

            if (moveX > 0) spriteRenderer.flipX = false;
            else if (moveX < 0) spriteRenderer.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KillBarrier")
        {
            ReloadScene();

        }
    }

    private void ReloadScene()
    {
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }


    private void FlashRed()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        isInvulnerable = true;
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(flashDuration);
        isInvulnerable = false;
        spriteRenderer.color = Color.white;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && !isInvulnerable)
        {
            health -= 25;
            health = Mathf.Clamp(health, 0, (int) maxHealth);
            UpdateHealthUI();
            FlashRed();


        }
    }

    private void UpdateHealthUI()
    {
       UIManagerPlatformer.Instance.SetHealthUI(health, maxHealth);
    }
}
