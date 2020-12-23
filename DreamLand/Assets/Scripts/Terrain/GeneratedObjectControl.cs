using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedObjectControl : MonoBehaviour
{
    public static GeneratedObjectControl instance;
    public List<GameObject> generatedObjects = new List<GameObject>();

    public PerlinGenerate perlinGenerator;
    //public GridSpawner gridSpawner;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        ClearAllObjects();
        Generate();
    }
    public void AddObject(GameObject objectToAdd)
    {
        generatedObjects.Add(objectToAdd);
    }

    // Update is called once per frame


    void Generate()
    {
        perlinGenerator.Generate();
        //gridSpawner.Generate();
    }


    void ClearAllObjects()
    {
        for (int i = generatedObjects.Count - 1; i >= 0; i--)
        {
            generatedObjects[i].SetActive(false);
            generatedObjects.RemoveAt(i);
        }
    }
}
