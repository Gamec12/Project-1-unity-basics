using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Vector3 offset = new Vector3(-2,0,-9);
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Background Bounds")]
    [SerializeField] private SpriteRenderer bgTop;
    [SerializeField] private SpriteRenderer bgBottom;

    private float minX, maxX, minY, maxY;
    void Start()
    {
        CalculateCameraLimits();
    }



    void CalculateCameraLimits()
    {
  
        Bounds combinedBounds = bgTop.bounds;
        combinedBounds.Encapsulate(bgBottom.bounds);

        Camera cam = GetComponent<Camera>();
        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        minX = combinedBounds.min.x + camWidth;
        maxX = combinedBounds.max.x - camWidth;
        minY = combinedBounds.min.y + camHeight;
        maxY = combinedBounds.max.y - camHeight;
    }


    private void LateUpdate()
    {
 
        Vector3 targetPos = playerPosition.position + offset;


        float clampedX = Mathf.Clamp(targetPos.x, minX, maxX);
        float clampedY = Mathf.Clamp(targetPos.y, minY, maxY);


        transform.position = new Vector3(clampedX, clampedY, offset.z);
    }
}
