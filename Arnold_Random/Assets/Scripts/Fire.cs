using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public ParticleSystem[] fires;
    private int current = 0;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // get player position
        fires[current].transform.rotation = transform.rotation;
      

        // go through fires array
        if (Input.GetMouseButton(0))
        {
            fires[current].Play();
        }
        else
        {
            fires[current].Stop();
            
            // increment current
            if(current < fires.Length - 1)
            {
                current++;
            }
            else
            {
                current = 0;
            }
        }
	}
}
