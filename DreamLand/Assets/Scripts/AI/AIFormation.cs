using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFormation : MonoBehaviour
{
    public Transform CoreTransform;

    private void Update()
    {
        transform.position = CoreTransform.position;
    }
}
