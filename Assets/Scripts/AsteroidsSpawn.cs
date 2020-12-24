using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawn : MonoBehaviour
{
    public float bulletForce = 1f;

    public Transform[] spawners  = new Transform[8];
    public GameObject[] asteroids = new GameObject[3];

    public int timer = 360;
    private int time = 0;

    // Update is called once per frame
    void Update()
    {
        if (timer != 40) {
            if (time == timer) {
                SpawnAsteroid();
                time = 0;
                timer-=5;
            }
            else time++;
        }
        else {
            if (time == timer) { 
                SpawnAsteroid();
                time = 0;
            }
            else time++;
        }
    }

    void SpawnAsteroid() {

        int rndSpawn = Random.Range(0, 8);
        int rndAster = Random.Range(0, 3);

        GameObject astro;

        if (rndAster == 0) {
            astro = Instantiate(asteroids[0], spawners[rndSpawn].position, spawners[rndSpawn].rotation);
        }
        else if (rndAster == 1) {
            astro = Instantiate(asteroids[1], spawners[rndSpawn].position, spawners[rndSpawn].rotation);
        }
        else astro = Instantiate(asteroids[2], spawners[rndSpawn].position, spawners[rndSpawn].rotation);

        Rigidbody2D rb = astro.GetComponent<Rigidbody2D>();
        rb.AddForce(spawners[rndSpawn].up * bulletForce, ForceMode2D.Impulse);
    }
}
