using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    public float LagSpeed;
    private Vector3 offset;

    private void Start()
    {
        followTransform = PlayerController.instance.transform;
        offset = transform.position - followTransform.position;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, followTransform.position + offset, LagSpeed);
    }
}
