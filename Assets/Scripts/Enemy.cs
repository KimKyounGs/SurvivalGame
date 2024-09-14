using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriter;
    private bool isLive = true;
    
    private bool isFrozen = false;
    private float freezeTimer = 0f;
    public float speed = 2.0f;
    public float health;
    public float maxHealth;
    public Rigidbody2D target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (isFrozen)
        {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0)
            {
                isFrozen = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (!isLive || isFrozen) return;
        Vector2 dirVec = target.position - rb.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
        rb.velocity = Vector2.zero;
    }

    private void LateUpdate() 
    {
        if (!isLive || isFrozen) return;
        spriter.flipX = target.position.x > rb.position.x ;
    }

    // 스크립트가 활성화될 때 호출되는 함수
    private void OnEnable() {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!other.CompareTag("Weapon")) return;

        health -= other.GetComponent<Bullet>().damage;

        if (health > 0)
        {

        }
        else 
        {
            Dead();
        }
    }

    public void Init(SpawnData spawnData)
    {
        speed = spawnData.speed;
        maxHealth = spawnData.health;
        health = spawnData.health;
    }

    public void Freeze(float duration)
    {
        isFrozen = true;
        freezeTimer = duration;
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

}
