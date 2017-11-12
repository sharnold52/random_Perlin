using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderGenerator : MonoBehaviour
{
    // prefab object
    public GameObject preFab;
    public float averageSize = 1f;
    public float stdDevSize = 2f;
    private GameObject current;
    private float size;
    private float skelHeight;

    // determine starting position
    public float zStart = 10;
    public float xStart = 0;
    float zPosition;

    // amount and spacing
    public int leaderNum = 8;
    public float spacing = 0.5f;

    // stuff to get terrain height at location
    float height;
    public Terrain myTerrain;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < leaderNum; i++)
        {
            // determines zPosition
            zPosition = zStart + Gaussian(0, 1);

            // determines size values for skeleton
            size = Gaussian(averageSize, stdDevSize);
            skelHeight = Gaussian(averageSize, stdDevSize);

            // gets the height of the terrain
            height = myTerrain.SampleHeight(new Vector3( xStart + (i*spacing), 0, zPosition));

            //positions the skeletons
            Vector3 pos = new Vector3(xStart + (i * spacing), height + (skelHeight * 0.2f), zPosition);
            current = Instantiate(preFab, pos, Quaternion.identity);

            // changes the size of the skeleton
            current.transform.localScale = new Vector3(size, skelHeight, size);
        }
	}
	

    // gets gaussian value
    float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);
        float gaussValue = Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * Mathf.Sin(2.0f * Mathf.PI * val2);
        return mean + stdDev * gaussValue;
    }
}
