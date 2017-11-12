using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySkeletons : MonoBehaviour
{
    public float health = 100;
    public GameObject firePrefab;
    bool onFire = false;
    GameObject current;
    int burnTime = 200;

    // takes fire damage
    private void FixedUpdate()
    {
        if (onFire)
        {
            health -= .5f;
        }
        
        // increments burnTime 
        burnTime--;

        // checks to see if object still burning
        if (burnTime <= 0)
        {
            onFire = false;
            burnTime = 200;
        }
    }

    //creates a fire at skeleton hit with flamethrower
    void OnParticleCollision()
    {
        if (onFire == false)
        {
            current = Instantiate(firePrefab, gameObject.transform.position, Quaternion.Euler(-90, 0 ,0));
            current.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

            onFire = true;
        }

        health -= 1;
        
        // destroys the object
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
