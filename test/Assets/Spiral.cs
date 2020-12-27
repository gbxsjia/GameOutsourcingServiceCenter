using UnityEngine;

public class Spiral : MonoBehaviour
{
    public Vector3 SpinEuler;
    public Transform spinTransform;

    void Update()
    {
        spinTransform.Rotate(SpinEuler * Time.deltaTime);
    }
}
