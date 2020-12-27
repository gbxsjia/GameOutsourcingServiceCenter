using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float VerticalSpeed;
    public float VerticalAcceleration;
    public float HorizontalSpeed;
    public float HorizontalAcceleration;

    public float JumpForce;
    public int GroundContactCount;

    void FixedUpdate()
    {
        Vector3 newVelocity = rb.velocity;

        float inputX = Input.GetAxis("Horizontal");
        newVelocity.x = Mathf.MoveTowards(newVelocity.x, inputX * HorizontalSpeed, HorizontalAcceleration * Time.fixedDeltaTime);
        newVelocity.z = Mathf.MoveTowards(newVelocity.z, VerticalSpeed, VerticalAcceleration * Time.fixedDeltaTime);
        rb.velocity = newVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && GroundContactCount > 0)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        GroundContactCount++;
    }

    private void OnCollisionExit(Collision collision)
    {
        GroundContactCount--;
    }


}
