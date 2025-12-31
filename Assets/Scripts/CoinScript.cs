using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private int value = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddScore(value);

            //Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }
}
