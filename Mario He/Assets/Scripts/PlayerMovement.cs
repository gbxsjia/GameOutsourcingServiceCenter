using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float MaxHorizontalSpeed;
    public float HorizontalAcceleration;

    public float JumpForce;
    public int GroundContactCount;
    

    void FixedUpdate()
    {
        Vector3 newvelocity = rb.velocity;

        //左右
        float Inputx = Input.GetAxis("LR");
        newvelocity.x = Mathf.MoveTowards(newvelocity.x, Inputx * MaxHorizontalSpeed, HorizontalAcceleration * Time.fixedDeltaTime);
        
        //前进
        float Inputy = Input.GetAxis("FB");
        newvelocity.z = Mathf.MoveTowards(newvelocity.z, Inputy * MaxHorizontalSpeed, HorizontalAcceleration * Time.fixedDeltaTime);

        rb.velocity = newvelocity;

    }

    private void Update()
    {
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
