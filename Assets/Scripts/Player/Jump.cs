using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private int jumpForce = 5;
    Rigidbody2D rb;
    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }


        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            {
            Debug.Log("En el suelo");
             isJumping = false;
            }
    }
}
