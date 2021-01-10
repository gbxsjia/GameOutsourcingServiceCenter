using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float MaxForwardSpeed;
    public float ForwardAcceleration;
    public float MaxHorizontalSpeed;
    public float HorizontalAcceleration;

    public float JumpForce;
    public int GroundContactCount;

    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
    }


    void FixedUpdate()
    {
        Vector3 newvelocity = rb.velocity;

        //左右
        float Inputx = Input.GetAxis("Horizontal");
        newvelocity.x = Mathf.MoveTowards(newvelocity.x, Inputx * MaxHorizontalSpeed, HorizontalAcceleration * Time.fixedDeltaTime);
       
        //前进
        newvelocity.z = Mathf.MoveTowards(newvelocity.z, MaxForwardSpeed, ForwardAcceleration*Time.fixedDeltaTime);

        rb.velocity = newvelocity;

        //跳跃
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (GroundContactCount > 0)
            {
                rb.AddForce(new Vector3(0, JumpForce, 0));
            }
        }
    }

    //跳跃碰撞检测
    private void OnCollisionEnter(Collision collision)
    {
        GroundContactCount++;
    }
    private void OnCollisionExit(Collision collision)
    {
        GroundContactCount--;
    }
}
 