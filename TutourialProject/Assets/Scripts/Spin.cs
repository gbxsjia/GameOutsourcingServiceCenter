using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Vector3 SpinEuler;
    public Transform spinTransform;

    void Update()
    {
        spinTransform.Rotate(SpinEuler * Time.deltaTime);
    }
}
