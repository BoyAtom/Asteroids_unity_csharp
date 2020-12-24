using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exterminate : MonoBehaviour
{
    public GameObject Asteroid_M;
    public GameObject Asteroid_S;
    public Transform[] point_B;
    public Transform[] point_M;
    public float bulletForce = 10f; 

    int Score = 0;

    private void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 100), "Score: " + Score);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            DestroyAsteroids();
            Score+=10;
        }
    }

    private void DestroyAsteroids()
    {
        switch (gameObject.tag)
        {
            case "Asteroid_B":
                Destroy(gameObject);

                GameObject as_M1 = Instantiate(Asteroid_M, point_B[0].position, point_B[0].rotation);
                Rigidbody2D rb1 = as_M1.GetComponent<Rigidbody2D>();
                rb1.AddForce(point_B[0].up * bulletForce, ForceMode2D.Impulse);
                
                GameObject as_M2 = Instantiate(Asteroid_M, point_B[1].position, point_B[1].rotation);
                Rigidbody2D rb2 = as_M2.GetComponent<Rigidbody2D>();
                rb2.AddForce(point_B[1].up * bulletForce, ForceMode2D.Impulse);

                break;

            case "Asteroid_M":
                Destroy(gameObject);

                GameObject as_S1 = Instantiate(Asteroid_S, point_M[0].position, point_M[0].rotation);
                Rigidbody2D rb3 = as_S1.GetComponent<Rigidbody2D>();
                rb3.AddForce(point_M[0].up * bulletForce, ForceMode2D.Impulse);

                GameObject as_S2 = Instantiate(Asteroid_S, point_M[1].position, point_M[1].rotation);
                Rigidbody2D rb4 = as_S2.GetComponent<Rigidbody2D>();
                rb4.AddForce(point_M[1].up * bulletForce, ForceMode2D.Impulse);

                break;

            case "Asteroid_S":
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }
}
