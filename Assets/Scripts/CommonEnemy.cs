using UnityEngine;

public class CommonEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {

            Debug.Log("I HAVE BEEN HIT");
            Destroy(gameObject);
        }
    }
}
