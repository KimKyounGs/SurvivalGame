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
        if(!GameManager.instance.isLive) return;
        
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
        if(!GameManager.instance.isLive) return;

        if (!isLive || isFrozen) return;
        Vector2 dirVec = target.position - rb.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
        rb.velocity = Vector2.zero;
    }

    private void LateUpdate() 
    {
        if(!GameManager.instance.isLive) return;
        
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
        if(!other.CompareTag("Weapon") || !isLive) return;

        health -= other.GetComponent<Bullet>().damage;
        // 넉백

        if (health > 0)
        {
            // Hit 애니메이션 등등
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
        isLive = false;
        gameObject.SetActive(false);
        GameManager.instance.kill++;
        // 경험치 아이템 생성.
        GameManager.instance.GetExp();
    }

}
