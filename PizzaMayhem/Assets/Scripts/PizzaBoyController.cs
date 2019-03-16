using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBoyController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveSpeed;
    bool faceRight;
    bool faceLeft;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        faceRight = true;
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveSpeed = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime);
        Flip();
    }

    private void Flip()
    {
        if ((faceRight && Input.GetKey(KeyCode.LeftArrow)))
        {
            faceLeft = true;
            faceRight = false;
            transform.Rotate(0f, 180f, 0f);
        }
        if ((faceLeft && Input.GetKey(KeyCode.RightArrow)))
        {
            faceRight = true;
            faceLeft = false;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
