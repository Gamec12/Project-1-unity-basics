using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 5f;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Destroy(gameObject,lifeTime);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame


    public void Launch(Vector2 direction)
    {

        rb.linearVelocity = direction *speed;
        Debug.Log(rb.linearVelocity);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
