using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAppearenceManager : MonoBehaviour
{
    public SkinnedMeshRenderer BodyRenderer;
    public SkinnedMeshRenderer ClothRenderer;

    public Mesh[] BodyMeshLib;
    public Mesh[] ClothMeshLib;

    private void Start()
    {
        if (BodyRenderer)
        {
            BodyRenderer.sharedMesh = BodyMeshLib[Random.Range(0, BodyMeshLib.Length)];
        }
        if (ClothRenderer)
        {
            ClothRenderer.sharedMesh = ClothMeshLib[Random.Range(0, ClothMeshLib.Length)];
        }
    }
}
