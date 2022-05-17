using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleBullet : MonoBehaviour
{
    //---
    //This script is meant only for a demonstration of the turrets movement. This script will not work for all 7 unique turrets in this asset pack. You may use this as a reference if you want to.

    //---

    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifetime;
    private float lifeTimer;

    void Update()
    {
        //Moving the bullet in the forward direction
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        //Destroying the object after a lifetime, in seconds
        if (lifeTimer >= lifetime)
        {
            Destroy(gameObject);
        }

        lifeTimer += Time.deltaTime;
    }
}
