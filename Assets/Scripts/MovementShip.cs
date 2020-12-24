using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShip : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    public GameObject hitEffect;

    private Vector2 movement;
    private Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Asteroid_B":
                Destroy(gameObject);
                GameObject hit1 = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(hit1, 0.2f);
                break;

            case "Asteroid_M":
                Destroy(gameObject);
                GameObject hit2 = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(hit2, 0.2f);
                break;

            case "Asteroid_S":
                Destroy(gameObject);
                GameObject hit3 = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(hit3, 0.2f);
                break;
        }
    }
}