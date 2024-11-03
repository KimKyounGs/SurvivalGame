using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float per;

    Rigidbody2D rigid;

    private void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();    
    }

    public void Init(float damage, float per, Vector3 dir) 
    {
        this.damage = damage;
        this.per = per;

        if (per > -1) // 원거리는 -1보다 크다.
        {
            rigid.velocity = dir * 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Enemy") || per == -1) return;

        per--;

        if (per == -1)
        {
            rigid.velocity = Vector2.zero; // 혹시 나중에 다시 쓸 수 있으니깐 0으로 낫두기.
            gameObject.SetActive(false);
        }
    }
}
