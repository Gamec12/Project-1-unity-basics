using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private int value = 10;
    private bool isCollected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !isCollected)
        {
            GameManager.instance.AddScore(value);
            isCollected = true;
            Destroy(gameObject);
            //gameObject.SetActive(false);

        }
    }
}
