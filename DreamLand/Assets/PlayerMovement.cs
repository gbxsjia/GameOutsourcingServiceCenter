using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 30f;
    public float sidewaysForce = 50f;
    //public float jumpForce = 50f;
    public Vector3 jump;

    void Start()
    {
      
    }

 
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if ( Input.GetKey(KeyCode.D) )
        {
            rb.AddForce(sidewaysForce * Time.deltaTime , 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0 ,ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //rb.velocity = Vector3.up * jumpFroce;
            transform.position = transform.position + jump;
            //rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
  

    }




}
