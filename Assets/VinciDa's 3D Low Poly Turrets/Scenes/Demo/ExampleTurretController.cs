using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTurretController : MonoBehaviour
{
    //---
    //This script is meant only for a demonstration of the turrets movement. This script will not work for all 7 unique turrets in this asset pack. You may use this as a reference if you want to.
    
    //---


    [SerializeField] private GameObject bullet;

    private GameObject turret;
    private GameObject turretHead;

    private GameObject[] cannons;
    private float cannonNormalZ;
    
    [Header("Rotation Variables")]
    [SerializeField] private float horizontalRotationSpeed;
    [SerializeField] private float verticalRotationSpeed;

    [Header("Firing Variables")]
    [SerializeField] private float firerate;
    private float fireTimer = 0;
    private int cannonIndex = 0;
    [SerializeField] private float cannonReturnSpeed;

    void Start()
    {
        //Getting the turret for horizontal control, and the turrethead for vertical control
        turret = transform.GetChild(0).GetChild(0).gameObject;
        turretHead = turret.transform.GetChild(0).gameObject;

        //Getting all cannon childobjects from the turrethead
        cannons = new GameObject[turretHead.transform.childCount];
        for (int i = 0; i < turretHead.transform.childCount; i++) {
            cannons[i] = turretHead.transform.GetChild(i).gameObject;
        }
        //Setting the normal position for the cannon barrels
        cannonNormalZ = cannons[0].transform.localPosition.z;
    }

    void Update()
    {
        //Horizontal rotation control
        turret.transform.Rotate(0, Input.GetAxisRaw("Horizontal") * horizontalRotationSpeed * Time.deltaTime, 0);

        //Vertical rotation control, with maximum and minimum angles of rotation
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (turretHead.transform.localRotation.eulerAngles.x < 15 || turretHead.transform.localRotation.eulerAngles.x > 304)
            {
                turretHead.transform.Rotate(verticalRotationSpeed * Time.deltaTime, 0, 0);
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (turretHead.transform.localRotation.eulerAngles.x < 16 || turretHead.transform.localRotation.eulerAngles.x > 305)
            {
                turretHead.transform.Rotate(-verticalRotationSpeed * Time.deltaTime, 0, 0);
            }
        }

        //Checking firerate and firing the next cannnon
        if (Input.GetKey(KeyCode.Space) && fireTimer >= firerate)
        {
            Shoot();
            fireTimer = 0;
        }
        else if (fireTimer < firerate)
        {
            fireTimer += Time.deltaTime;
        }

        //Returning cannon barrels to their default positions, if they have been moved by firing
        for (int i = 0; i < cannons.Length; i++)
        {
            if (cannons[i].transform.localPosition.x != cannonNormalZ)
            {
                cannons[i].transform.localPosition = Vector3.MoveTowards(cannons[i].transform.localPosition, new Vector3(cannons[i].transform.localPosition.x, cannons[i].transform.localPosition.y, cannonNormalZ), cannonReturnSpeed * Time.deltaTime);
            }
        }
    }

    private void Shoot()
    {
        //Instantiating bullet prefab at the correct barrel, and moving the cannon barrel for visual impact
        Instantiate(bullet, cannons[cannonIndex].transform.position, cannons[cannonIndex].transform.rotation);
        cannons[cannonIndex].transform.localPosition -= new Vector3(0, 0, 0.25f);
        cannonIndex++;
        if (cannonIndex >= cannons.Length)
        {
            cannonIndex = 0;
        }
    }
}
