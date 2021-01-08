using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] Prefabs = new GameObject[4];
    public List<GameObject> BlockInstances = new List<GameObject>();

    public Vector3 EndPosition;

    private float LastZvalue;
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GenerateBlock();
        }

        LastZvalue = PlayerMovement.instance.transform.position.z;
    }

    private void Update()
    {
        if (PlayerMovement.instance.transform.position.z - LastZvalue > 100)
        {
            LastZvalue = LastZvalue + 100;
            GenerateBlock();

            Destroy(BlockInstances[0]);
            BlockInstances.RemoveAt(0);
        }
    }

    public void GenerateBlock()
    {
        int randomIndex = Random.Range(0, Prefabs.Length);
        GameObject newBlock = Instantiate(Prefabs[randomIndex], EndPosition, Quaternion.identity);
        EndPosition += new Vector3(0, 0, 100);
        BlockInstances.Add(newBlock);

    }

}
