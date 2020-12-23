using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockInfo
{
    public string Name;
    public GameObject[] Prefabs;
}


public class MapGeneration : MonoBehaviour
{
    public BlockInfo[] Blocks;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //for loop生成地图，判断生成地图材质
    public GameObject BlockChoose(int Index)
    {
        GameObject prefab = null;
        int typenum = Blocks.Length;


        int l = Blocks[Index].Prefabs.Length;
        int x = Random.Range(0, l);
        prefab = Blocks[Index].Prefabs[x];

        return prefab;
    }

}


