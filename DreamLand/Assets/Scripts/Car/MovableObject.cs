using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D mainCollider;

    private float StopTimer;
    private float LastCheckTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        UpdateStopTimer();
    }
   
    public float GetStopTime()
    {
        return StopTimer;
    }

    private void UpdateStopTimer()
    {
        StopTimer += Time.deltaTime;
        if ((Time.time - LastCheckTime) >= 0.1f)
        {
            LastCheckTime = Time.time;
            if (rb.velocity.magnitude >= 0.1f)
            {
                StopTimer = 0;
            }
        }
    }
}
