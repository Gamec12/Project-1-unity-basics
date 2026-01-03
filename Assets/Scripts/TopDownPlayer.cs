using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TopDownPlayer : MonoBehaviour
{

    Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isInvulnerable;
    [SerializeField] float speed = 5.0f;
    [SerializeField] Color damageColor = Color.red;
    [SerializeField] float flashDuration = 0.5f;
    [SerializeField] int health = 100;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float fireDelay = 1f;



    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(health <=0) ReloadScene();
            
        Move();
        LookAtMouse();

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Shoot");
            StartCoroutine(DelayedShot());
        }

        

    }


    IEnumerator DelayedShot()
    {
        yield return new WaitForSeconds(fireDelay);

        Shoot();
    
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody2D Temprb = bullet.GetComponent<Rigidbody2D>();
        if (Temprb != null) Temprb.linearVelocity = -firePoint.up * bulletSpeed;

    }


    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if(moveX != 0 || moveY != 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (Mathf.Abs(moveX) > 0.01f || Mathf.Abs(moveY) > 0.01f)
        {

            float targetVelocityX = moveX * speed;
            float speedDifX = targetVelocityX - rb.linearVelocity.x;

            float targetVelocityY = moveY * speed;
            float speedDifY = targetVelocityY - rb.linearVelocity.y;
            


            rb.AddForce(new Vector2(speedDifX, speedDifY));

        }

        


        transform.position += Vector3.up * moveY * speed * Time.deltaTime;



    }

    void LookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2( mousePosition.x - transform.position.x, mousePosition.y - transform.position.y );

        float angle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90f));

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
        if (collision.gameObject.CompareTag("Enemy") && !isInvulnerable)
        {
            health -= 25;
            FlashRed();

        }
    }


}
