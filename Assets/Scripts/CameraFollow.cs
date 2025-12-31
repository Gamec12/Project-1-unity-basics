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
        // 1. Find the total bounds of BOTH sprites combined
        Bounds combinedBounds = bgTop.bounds;
        combinedBounds.Encapsulate(bgBottom.bounds);

        // 2. Get camera dimensions
        Camera cam = GetComponent<Camera>();
        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        // 3. Calculate the clamp limits
        // We subtract the camera half-size so the edge of the screen stops at the sprite edge
        minX = combinedBounds.min.x + camWidth;
        maxX = combinedBounds.max.x - camWidth;
        minY = combinedBounds.min.y + camHeight;
        maxY = combinedBounds.max.y - camHeight;
    }


    private void LateUpdate()
    {
        // Target position based on player + offset
        Vector3 targetPos = playerPosition.position + offset;

        // Clamp the target position within our calculated limits
        float clampedX = Mathf.Clamp(targetPos.x, minX, maxX);
        float clampedY = Mathf.Clamp(targetPos.y, minY, maxY);

        // Apply the position (keeping the Z offset for the camera)
        transform.position = new Vector3(clampedX, clampedY, offset.z);
    }
}
