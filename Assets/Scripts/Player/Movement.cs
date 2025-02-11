using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public int speed = 7;
    Vector2 movement;
    Rigidbody2D rb;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0.1f || Input.GetAxis("Horizontal") < -0.1f)
        {
            move(movement);
        }
    }
    private void move(Vector2 direcion)
    {
        rb.position += direcion * speed * Time.fixedDeltaTime;
    }
}