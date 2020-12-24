using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject laserPrefab;
    public float bulletForce = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
