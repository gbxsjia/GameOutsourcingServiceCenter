using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] BlockPrefabs;
    public List<GameObject> BlockInstances;

    public float lastZ;
    private void Start()
    {
        lastZ = PlayerController.instance.transform.position.z;
        for (int i = 0; i < 3; i++)
        {
            GenerateNewBlock();
        }
    }
    private void Update()
    {
        if (PlayerController.instance.transform.position.z - lastZ >= 100)
        {
            lastZ += 100;
            Destroy(BlockInstances[0]);
            BlockInstances.RemoveAt(0);
            GenerateNewBlock();
        }
    }
    public void GenerateNewBlock()
    {
        int randomIndex = Random.Range(0, BlockPrefabs.Length);
        Vector3 newPosition = BlockInstances[BlockInstances.Count - 1].transform.position + Vector3.forward * 100;
        GameObject newBlock = Instantiate(BlockPrefabs[randomIndex], newPosition, Quaternion.identity);
        BlockInstances.Add(newBlock);
    }
}
