using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBoyController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveSpeed = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime);
    }
}
