using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public ParticleSystem explosionParticleSystem;
    public AudioSource explosionSound;

    private void OnTriggerEnter(Collider other)
    {
        //Destroy this gameobject:
        if (other.gameObject.CompareTag("projectile"));
        {
            this.explosionSound.Play();
            Destroy(this.gameObject, 0.25f);
            Destroy(other.gameObject);
            this.explosionParticleSystem.Play();
        }

        //Destroy the colliding gameobject:
    }
}
