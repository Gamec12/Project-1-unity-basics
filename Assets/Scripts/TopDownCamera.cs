using UnityEngine;
using UnityEngine.Tilemaps;

public class TopDownCamera : MonoBehaviour
{

    [SerializeField] private Transform playerPosition;
    [SerializeField] private Vector3 offset = new Vector3(-2, 0, -9);
    [SerializeField] private Tilemap tilemap;

    private float minX, maxX, minY, maxY;
 
    void Start()
    {
        Bounds bounds = tilemap.localBounds;

        float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;

        minX = bounds.min.x + camWidth + 1;
        maxX = bounds.max.x - camWidth - 1;
        minY = bounds.min.y + camHeight;
        maxY = bounds.max.y - camHeight;
    }



  


    private void LateUpdate()
    {

        Vector3 targetPos = playerPosition.position + offset;

        float clampedX = Mathf.Clamp(targetPos.x, minX, maxX);

        float clampedY = Mathf.Clamp(targetPos.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, -10);


    }
}
