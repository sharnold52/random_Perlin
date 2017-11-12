using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeGenerator : MonoBehaviour
{
    // prefab object and terrain
    public GameObject preFab;
    private GameObject current;
    public Terrain myTerrain;

    // customizable size values
    public float sizeAverage = 1;
    public float sizeDeviation = 0;

    // amount to spawn and how dense
    public int hordeCount = 50;
    public int maxInColumn = 10;
    public int minInColumn = 5;

    // positions to start  and end spawning
    public float xStart = 50;
    public float zStart = 50;
    public float xEnd = 200;
    public float zEnd = 200;
    public float spacing = 5;

	// Use this for initialization
	void Start ()
    {
        // spawns the skeletons
        SpawnHorde();
	}

    // gets gaussian value
    float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);
        float gaussValue = Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * Mathf.Sin(2.0f * Mathf.PI * val2);
        return mean + stdDev * gaussValue;
    }

    // method to generate the large horde and place them
    void SpawnHorde()
    {
        // control values
        int colCurrent = 0;
        float size = 1f;

        while (hordeCount > 0)
        {
            // decides how many to spawn in current collumn, then updates horde count
            int numColumn = Random.Range(minInColumn, maxInColumn);
            hordeCount -= numColumn;

            // checks hordecount to make sure it is not below zero
            if (hordeCount < 0)
            {
                numColumn += hordeCount;
            }

            // spawns column
            for (int i = 0; i < numColumn; i++)
            {
                // get x y and z values
                float x = Random.Range(xStart, xEnd);
                float z = zEnd - (colCurrent * spacing) + Gaussian(2, 1f);
                float y = myTerrain.SampleHeight(new Vector3(x, 0, z));

                // determines size values for skeleton
                size = Gaussian(sizeAverage, sizeDeviation);

                // spawn the skeletons, positions them, and sizes them
                Vector3 pos = new Vector3(x, y + (size *.2f), z);
                current = Instantiate(preFab, pos, Quaternion.identity);
                current.transform.localScale = new Vector3(size, size, size);
            }

            // spawns less and less minions by reducing max and min values
            if (minInColumn > 2)
            {
                minInColumn -= 2;
            }
            else
            {
                minInColumn = 0;
            }

            if (maxInColumn > 3)
            {
                maxInColumn -= 1;
            }
            else
            {
                maxInColumn = 3;
            }

            colCurrent++;
        }
    }
}
