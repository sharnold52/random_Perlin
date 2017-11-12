using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{

    //get terrain data
    private TerrainData myTerrainData;

    // editable data to fiddle with terrain appearance and size
    public Vector3 worldSize = new Vector3(200, 50, 200);
    public int resolution;
    public float pStep = 0.03f;

    // Use this for initialization
    void Start ()
    {
        myTerrainData = gameObject.GetComponent<TerrainCollider>().terrainData;
        myTerrainData.size = worldSize;
        resolution = myTerrainData.heightmapResolution;

        // generate the height array
        Generate();
    }


    // generates and sets the heights of the terrain
    void Generate()
    {

        float[,] heightArray = new float[resolution, resolution];

        float xCoord = 0.0f;
        float yCoord = 0.0f;

        for (int i = 0; i < resolution; i++)
        {
            yCoord = 0.0f;
            for (int j = 0; j < resolution; j++)
            {
                heightArray[i, j] = Mathf.PerlinNoise(xCoord, yCoord);
                yCoord += pStep;
            }
            xCoord += pStep;
        }

        // set the heights
        myTerrainData.SetHeights(0, 0, heightArray);
    }
}
