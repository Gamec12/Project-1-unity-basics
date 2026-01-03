using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int score = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int score)
    { 
        this.score += score;
        Debug.Log(this.score);
    }

    
}
