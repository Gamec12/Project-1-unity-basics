using UnityEngine;

public class Oscilate : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] private float speed = 2f;
    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPos +  new Vector3(offset, 0, 0) ;
    }
}
