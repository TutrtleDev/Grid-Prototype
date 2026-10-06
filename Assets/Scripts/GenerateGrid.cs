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
    private List<GameObject> _blocksList = new();

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
                
                _blocksList.Add(block);
            }
        }
    }
    
    [Button("Destroy Grid", ButtonSizes.Large)]
    private void DestroyBlocks()
    {
        if (_blocksList != null)
        {
            foreach (GameObject block in _blocksList)
            {
                Destroy(block);
            }
            
            _blocksList.Clear();
        }
    }

    private void OnApplicationQuit()
    {
        DestroyBlocks();
    }
}
