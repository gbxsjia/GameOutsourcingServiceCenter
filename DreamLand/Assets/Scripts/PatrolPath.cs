using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    public Vector3[] Path;
    public Transform[] WayPoints;

    private void Start()
    {
        Path = new Vector3[WayPoints.Length];
        for (int i = 0; i < WayPoints.Length; i++)
        {
            Path[i] = WayPoints[i].position;
        }
    }
}
