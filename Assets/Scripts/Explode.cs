using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public ParticleSystem explosionParticleSystem;
    public AudioSource explosionSound;

    private void OnTriggerEnter(Collider collider)
    {
        //Destroy this gameobject:
        if (collider.gameObject.CompareTag("projectile"));
        {
            this.explosionSound.Play();
            Destroy(this.gameObject, 0.25f);
            this.explosionParticleSystem.Play();
        }

        //Destroy the colliding gameobject:
    }
}
