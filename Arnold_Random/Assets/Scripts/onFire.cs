using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onFire : MonoBehaviour
{
    // used to determine burning time
    int burnTime = 200;

	void FixedUpdate()
    {
        burnTime--;

        // destroys the fire
        if(burnTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
