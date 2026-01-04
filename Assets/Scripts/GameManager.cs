using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

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
        UIManagerPlatformer.Instance.SetScoreUI(this.score);
        Debug.Log(this.score);
    }

    
}
