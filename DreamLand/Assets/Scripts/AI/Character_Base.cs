using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Base : MonoBehaviour
{
    private Rigidbody rb;

    public float WalkSpeed;
    public float SprintSpeed;
    public float MoveAcceleration;
    public Vector3 LastMoveDirection;
    public Vector3 InputDirection;
    public float JumpForce;

    private bool onGround;

    public Animator animator;

    public float RotationSpeed;
    private Transform FocusTransform;

    public int Camp;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        LastMoveDirection = transform.forward;
        SetUp();
    }
    private void SetUp()
    {
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
        
    }
    private void Update()
    {
        CheckGround();
        if (FocusTransform)
        {
            RotateTowards(FocusTransform.position);
        }
    }
    private void LateUpdate()
    {
        UpdateAnimation();
    }
    #region Abilities

    public void Move(Vector3 Direction)
    {
        Direction.Normalize();
        InputDirection = Direction;
        if (Direction != Vector3.zero)
        {
            LastMoveDirection = Direction;           
        }
        Vector3 v = Vector3.MoveTowards(rb.velocity, Direction * WalkSpeed, MoveAcceleration);
        v.y = rb.velocity.y;
        rb.velocity = v;
    }
    private void CheckGround()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position + Vector3.up*0.1f, Vector3.down, out hit, 0.2f);
        if (hit.collider)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
        //Debug.DrawLine(transform.position, transform.position + Vector3.down * 0.1f,Color.red);
    }
    public void Jump(float force)
    {
        if (onGround)
        {
            animator.SetTrigger("jump");
            rb.AddForce(Vector3.up * force,ForceMode.Impulse);
        }
    }
    public void Jump()
    {
        Jump(JumpForce);
    }
    private void UpdateAnimation()
    {
        float moveSpeed = rb.velocity.magnitude;
        float currentSpeed = animator.GetFloat("MoveSpeed");

        animator.SetFloat("MoveSpeed", Mathf.MoveTowards(currentSpeed, moveSpeed, 6f * Time.deltaTime));
        animator.SetBool("onGround", onGround);
    }

    public void RotateTowards(Vector3 targetPos)
    {     
        if (!FocusTransform)
        {
            Vector3 direction = targetPos - transform.position;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
    }
    public void SetFocusTransform(Transform target)
    {
        FocusTransform = target;
    }
    public void PlayAnimation(string animationName)
    {
        animator.CrossFade(animationName, 0.1f);
    }
    #endregion

}
