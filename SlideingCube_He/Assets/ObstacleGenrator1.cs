using UnityEngine;

public class ObstacleGenrator1 : MonoBehaviour
{
    public int CreatAmount;
    public Vector3 StartPosition;
    public Vector3 PositionOffset;

    public GameObject[] Blockprefab;

    void Start()
    {
        for (int i = 0; i < CreatAmount; i++)
        {
            Vector3 position = StartPosition;
            position = position + PositionOffset * i;

            int inx = Random.Range(0, Blockprefab.Length);
            Instantiate(Blockprefab[inx], position, Quaternion.identity);

        }

    }

}