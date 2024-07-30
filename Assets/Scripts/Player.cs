using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriter;
    public float moveSpeed = 5f;
    public Vector2 moveInput;
    public Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        moveVelocity = moveInput * moveSpeed *  Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveVelocity);
    }

    void LateUpdate() 
    {
        if (moveInput.x != 0) 
        {
            spriter.flipX = moveInput.x > 0;
        }
    }

    void OnMove(InputValue value) 
    {
        moveInput = value.Get<Vector2>();
    }
}
