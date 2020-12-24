using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{

    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag) {
            case "Asteroid_B":
                GameObject hit1 = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(hit1, 0.2f);
                break;

            case "Asteroid_M":
                GameObject hit2 = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(hit2, 0.2f);
                break;

            case "Asteroid_S":
                GameObject hit3 = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(hit3, 0.2f);
                break;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
