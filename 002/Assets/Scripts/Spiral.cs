using UnityEngine;

public class Spiral : MonoBehaviour
{
    public Vector3 SpinEuler;
    public Transform spinTransform;

    // Update is called once per frame
    void Update()
    {
        spinTransform.Rotate(SpinEuler * Time.deltaTime);
    }
}
