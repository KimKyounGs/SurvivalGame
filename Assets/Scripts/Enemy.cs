using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriter;
    private bool isLive = true;

    public float speed;
    public Rigidbody2D target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void Start() 
    {
        speed = 2.0f;
    }

    private void FixedUpdate()
    {
        if (!isLive) return;
        Vector2 dirVec = target.position - rb.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
        rb.velocity = Vector2.zero;
    }

    private void LateUpdate() 
    {
        if (!isLive) return;
        spriter.flipX = target.position.x > rb.position.x ;
    }
}
