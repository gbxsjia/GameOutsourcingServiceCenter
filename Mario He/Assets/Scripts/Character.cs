using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected int HitPoint;
    public float MoveSpeed;
    protected Rigidbody rb;

    public float JumpForce;
    public int GroundContactCount;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        direction.Normalize();

        Vector3 newVelocity = rb.velocity;
        newVelocity = Vector3.Lerp(newVelocity, direction * MoveSpeed, 0.1f);
        newVelocity.y = rb.velocity.y;

        rb.velocity = newVelocity;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
        }
    }

    public virtual void Attack()
    {
        
    }

    void Update()
    {
        Vector3 newvelocity = rb.velocity;

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
