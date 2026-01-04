using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManagerPlatformer : MonoBehaviour
{

    public static UIManagerPlatformer Instance;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] Image healthBarFill;
    void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    public void SetScoreUI(int score)
    {
        scoreText.text = score.ToString();
    }
    public void SetHealthUI(int health, float maxHealth)
    {
        
        healthBarFill.fillAmount = (float)(health / maxHealth);
    }
}
