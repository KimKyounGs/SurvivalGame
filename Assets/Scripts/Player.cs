using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        moveVelocity = moveInput * moveSpeed *  Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveVelocity);
    }

    void OnMove(InputValue value) 
    {
        moveInput = value.Get<Vector2>();
    }
}
