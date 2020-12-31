using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator2 : MonoBehaviour
{
    public GameObject[] Prefabs = new GameObject[4];
    public List<GameObject> BlockInstances = new List<GameObject>();

    public Vector3 EndPosition;

    private float LastZValue;
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GenerateBlock();
        }

        LastZValue = PlayerController.instance.transform.position.z;
    }

    private void Update()
    {
        if (PlayerController.instance.transform.position.z - LastZValue > 100)
        {
            LastZValue = LastZValue + 100;
            GenerateBlock();

            Destroy(BlockInstances[0]);
            BlockInstances.RemoveAt(0);
        }
        print(Add(5));
    }

    public void GenerateBlock()
    {
        int randomIndex = Random.Range(0, Prefabs.Length);
        GameObject newBlock = Instantiate(Prefabs[randomIndex], EndPosition, Quaternion.identity);
        EndPosition += new Vector3(0, 0, 100);
        BlockInstances.Add(newBlock);
    } 
    public int Add(int member)
    {
        if (member > 0)
        {
            member--;
            return Add(member);
        }
        else
        {
            return 0;
        }
    }
}
