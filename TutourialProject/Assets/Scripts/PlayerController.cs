using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;
    public float HorizontalSpeed;
    public float HorizontalAcceleration;
    public float JumpForce;
    public float VerticalSpeed;
    public float VerticalAcceleration;

    private int GroundContactCount;

    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        Vector3 newVelocity = rigid.velocity;
        newVelocity.x = Mathf.MoveTowards(newVelocity.x, inputX * HorizontalSpeed, HorizontalAcceleration * Time.deltaTime);
        newVelocity.z = Mathf.MoveTowards(newVelocity.z, VerticalSpeed, VerticalAcceleration * Time.deltaTime);
        rigid.velocity = newVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && GroundContactCount > 0)
        {
            rigid.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            GroundContactCount++;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            GroundContactCount--;
        }
    }
}
