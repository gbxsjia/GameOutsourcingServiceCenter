﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Base : MonoBehaviour
{
    private Rigidbody rb;

    [Header("能力")]
    public float WalkSpeed;
    public float SprintSpeed;
    public float MoveAcceleration;
    public Vector3 LastMoveDirection;
    public Vector3 InputDirection;
    public float JumpForce;

    // 状态
    private bool onGround;
    private Behaviour currentBehaviour;

    public Animator animator;

    public float RotationSpeed;
    private Transform FocusTransform;

    public Weapon_Base Weapon;

    public int Camp;

    // 事件
    public event System.Action<Behaviour> BehaviourFinishEvent;
    public event System.Action<Behaviour> BehaviourInterruptEvent;
    public event System.Action<Behaviour> BehaviourEndEvent;
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
        UpdateVelocity();
        if (FocusTransform)
        {
            RotateToFocusTarget();
        }
        if (currentBehaviour!=null)
        {
            currentBehaviour.UpdateBehaviour(this);
        }
    }
    private void LateUpdate()
    {
        UpdateAnimation();
    }

    public void AttackCommand()
    {
        Weapon.AttackCommand();
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
    }
    public void UpdateVelocity()
    {
        Vector3 v = Vector3.MoveTowards(rb.velocity, InputDirection * WalkSpeed, MoveAcceleration);
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

    public float RotateTowards(Vector3 targetPos)
    {
        Vector3 direction = targetPos - transform.position;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        if (!FocusTransform)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
        return Quaternion.Angle(transform.rotation, targetRotation);
    }
    public void RotateToFocusTarget()
    {
        Vector3 direction = FocusTransform.position - transform.position;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }
    public void SetFocusTransform(Transform target)
    {
        FocusTransform = target;
    }
    public void PlayAnimation(string animationName)
    {
        animator.CrossFade(animationName, 0.1f);
    }
    public Behaviour StartBehaviour(string animName, float duration, BehaviourType type, float[] eventTiming)
    {
        Behaviour newBehaviour = new Behaviour(animName, duration, type, eventTiming);
        return StartBehaviour(newBehaviour);
    }
    public Behaviour StartBehaviour(Behaviour behaviour)
    {
        if (currentBehaviour != null)
        {
            InterruptBehaviour();
        }
        currentBehaviour = behaviour;
        currentBehaviour.StartBehaviour(this);
        return behaviour;
    }
    public void InterruptBehaviour()
    {
        Behaviour lastBehaviour = currentBehaviour;
        currentBehaviour.BehaviourInterrpt();
        currentBehaviour = null;
        if (BehaviourInterruptEvent != null)
        {
            BehaviourInterruptEvent(lastBehaviour);
        }
        if (BehaviourEndEvent != null)
        {
            BehaviourEndEvent(lastBehaviour);
        }
    }
    public void FinishBehaviour()
    {
        Behaviour lastBehaviour= currentBehaviour;
        currentBehaviour = null;
        if (BehaviourFinishEvent != null)
        {
            BehaviourFinishEvent(lastBehaviour);
        }
        if (BehaviourEndEvent != null)
        {
            BehaviourEndEvent(lastBehaviour);
        }
    }
    #endregion

}
