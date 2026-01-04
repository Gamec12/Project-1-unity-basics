using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private int value = 10;
    private bool isCollected = false;
    
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            GameManager.instance.AddScore(value);
       
            
            Destroy(gameObject);
            //gameObject.SetActive(false);

        }
    }
}
