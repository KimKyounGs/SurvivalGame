using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private int hp;
    private int maxHP;
    private Rigidbody2D rb;
    private SpriteRenderer spriter;
    public Scanner scanner;
    public float moveSpeed = 5f;
    public Vector2 moveInput;
    public Vector2 moveVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        scanner = GetComponent<Scanner>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if(!GameManager.instance.isLive) return;

        moveVelocity = moveInput * moveSpeed *  Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveVelocity);
    }

    private void LateUpdate() 
    {
        if(!GameManager.instance.isLive) return;
        
        if (moveInput.x != 0) 
        {
            spriter.flipX = moveInput.x > 0;
        }
    }

    private void OnMove(InputValue value) 
    {
        moveInput = value.Get<Vector2>();
    }

    public void HealHP(int healAmount)
    {
        if (hp + healAmount > maxHP) hp = maxHP;
        else hp += healAmount;
    }

    public void AddXP(int XPAmount)
    {
        // if (XP + XPAmount >= maxXP) {
            // LevelUp;
        //   XP -= maxXP;
        // }
        // XP += XPAmount;
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if (!GameManager.instance.isLive) return;

        GameManager.instance.health -= Time.deltaTime * 10;

        if (GameManager.instance.health < 0)
        {
            for (int index = 2; index < transform.childCount; index ++)
            {
                transform.GetChild(index).gameObject.SetActive(false);
            }
            GameManager.instance.GameOver();
        }    
    }
}
