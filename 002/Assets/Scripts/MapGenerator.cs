using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int CreateAmount;
    public Vector3 StartPosition;
    public Vector3 PositionOffset;

    public GameObject[] BlockPerfabs;

    void Start()
    {
        for (int i = 0; i < CreateAmount; i++)
        {
            Vector3 position = StartPosition;
            position = position + PositionOffset * i;

            int inx = Random.Range(0, BlockPerfabs.Length);

            Instantiate(BlockPerfabs[inx], position, Quaternion.identity);
        }
        

    }


}
