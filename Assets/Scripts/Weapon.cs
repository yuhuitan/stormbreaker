using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public string attackKey;
    public GameObject bulletPrefab;
   // public GameObject newBulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(attackKey))
        {
            Shoot(bulletPrefab);
        }
    }
/*if (Input.GetButtonDown("Fire1"))
        {
            Shoot(bulletPrefab);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot(newBulletPrefab);
        }

    }*/

    void Shoot(GameObject prefab)
    {
        // before shooting, set the property of the prefab first
        Instantiate(prefab, firePoint.position, firePoint.rotation);
    }
}
