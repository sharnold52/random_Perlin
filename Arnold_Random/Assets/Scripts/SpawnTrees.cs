using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrees : MonoBehaviour
{
    // objects to spawn randomly across terrain
    public GameObject prefab;
    private GameObject current;
    public int amount;

    // terrain 
    public Terrain myTerrain;

    // Use this for initialization
    void Start()
    {
        // get the size of the terrain
        Vector3 terrainSize = myTerrain.terrainData.size;
        
        // instantiate each object
        for (int i = 0; i < amount; i++)
        {
            // randomly generate position of object
            float x = Random.Range(1, terrainSize.x);
            float z = Random.Range(1, terrainSize.z);
            float y = myTerrain.SampleHeight(new Vector3(x, 0, z));

            // check area for possible collisions
            var check = Physics.OverlapSphere(new Vector3(x, y, z), 1);
            
            // instantiate object
            current = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
        }
    }
}
