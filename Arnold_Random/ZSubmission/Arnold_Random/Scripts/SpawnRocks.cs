using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{
    // objects to spawn randomly across terrain
    public GameObject[] prefabs;
    private GameObject current;
    public int amount;

    // int to track array position
    int tracker = 0;

    // terrain 
    public Terrain myTerrain;

    // Use this for initialization
    void Start()
    {
        // get the size of the terrain
        Vector3 terrainSize = myTerrain.terrainData.size;

        // instantiate each object
        for (int i = 0; i < amount; i ++)
        {
            // randomly generate position of object
            float x = Random.Range(1, terrainSize.x);
            float z = Random.Range(1, terrainSize.z);
            float y = myTerrain.SampleHeight(new Vector3(x, 0, z));

            // instantiate object
            current = Instantiate(prefabs[tracker], new Vector3(x, y, z), Quaternion.identity);

            // increment array tracker
            tracker++;
            
            // reset tracker if necessarry
            if (tracker > prefabs.Length - 1)
            {
                tracker = 0;
            }
        }
    }
}
