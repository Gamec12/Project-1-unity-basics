using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool isGrounded = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }


    private void OnTriggerExit0(Collider other)
    {
        isGrounded = false;
    }
}
