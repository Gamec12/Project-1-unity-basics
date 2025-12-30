using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{

    Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [SerializeField] float speed = 5.0f;



    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Move();
        LookAtMouse();

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Shoot");
        }

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

            transform.position += Vector3.right * moveX * speed * Time.deltaTime;


        transform.position += Vector3.up * moveY * speed * Time.deltaTime;



    }

    void LookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2( mousePosition.x - transform.position.x, mousePosition.y - transform.position.y );

        float angle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90f));

    }
}
