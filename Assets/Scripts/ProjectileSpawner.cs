using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private InputActionReference shootRightHandActionReference;
    public Rigidbody projectile;
    private float speed = 50.0f;

    void Start()
    {
        shootRightHandActionReference.action.performed += OnShoot;
    }

    private void OnShoot(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
    }
}
