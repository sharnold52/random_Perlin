using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    public Terrain myTerrain;

	// Use this for initialization
	void Start ()
    {
        // gets height at position
        float x = player.transform.position.x;
        float z = player.transform.position.z;
        float y = myTerrain.SampleHeight(new Vector3(x, 0, z));

        // sets position
        player.transform.position = new Vector3(x, y, z);
	}
}
