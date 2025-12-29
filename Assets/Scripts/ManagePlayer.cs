using UnityEngine;

public class ManagePlayer : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    [SerializeField] private Transform StartLocation ;
    void Start()
    {
        Instantiate(Player);
        Player.transform.position = StartLocation.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
