using System;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private int worldSizeX = 10;
    [SerializeField] private int worldSizeY = 10;
    [SerializeField] private int gridOffset = 2;

    private void Start()
    {
        Generate();
    }

    
    private void Generate()
    {
        for (int x = 0; x < worldSizeX; x++)
        {
            for (int z = 0; z < worldSizeY; z++)
            {
                Vector3 pos = new Vector3(x * gridOffset, 0, z * gridOffset);
                
                GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity);
                
                block.transform.SetParent(transform);
            }
        }
    }
}
