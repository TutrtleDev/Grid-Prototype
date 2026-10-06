using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GenerateGrid : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private int worldSizeX = 10;
    [SerializeField] private int worldSizeY = 10;
    [SerializeField] private int gridOffset = 2;
    [SerializeField] private List<GameObject> blocks;

    private void Start()
    {
        Generate();
    }

    
    [Button("Generate Grid", ButtonSizes.Large)]
    private void Generate()
    {
        DestroyBlocks();
        
        for (int x = 0; x < worldSizeX; x++)
        {
            for (int z = 0; z < worldSizeY; z++)
            {
                Vector3 pos = new Vector3(x * gridOffset, 0, z * gridOffset);
                
                GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity);
                
                block.transform.SetParent(transform);
                
                blocks.Add(block);
            }
        }
    }
    
    [Button("Destroy Grid", ButtonSizes.Large)]
    private void DestroyBlocks()
    {
        if (blocks != null)
        {
            foreach (GameObject block in blocks)
            {
                Destroy(block);
            }
            
            blocks.Clear();
        }
    }

    private void OnApplicationQuit()
    {
        DestroyBlocks();
    }
}
