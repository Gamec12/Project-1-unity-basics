using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{

    Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [SerializeField] float speed = 5.0f;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Move();
    }


    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * moveX * speed * Time.deltaTime;
        if (moveX > 0)
        {
            spriteRenderer.flipX = false;

        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        }

        float moveY = Input.GetAxis("Vertical");



        transform.position += Vector3.up * moveY * speed * Time.deltaTime;

        if (moveY > 0)
        {
            spriteRenderer.flipY = false;

        }
        else if (moveY < 0)
        {
            spriteRenderer.flipY = true;
        }


    }
}
