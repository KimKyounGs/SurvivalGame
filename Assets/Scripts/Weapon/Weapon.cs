using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    private float timer;
    Player player;

    private void Awake() 
    {
        player = GameManager.instance.player;
    }

    private void Update()
    {
        switch(id)
        {
            case 0:
            {
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            }

            default:
            {
                timer += Time.deltaTime;

                if (timer > speed) 
                {
                    timer = 0f;
                    Fire();
                }
                break;
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            LevelUp(20, 5);
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if (id == 0)
        {
            Batch();
        }
    }

    public void Init(ItemData data)
    {
        // 기본 세팅
        name = "Weapon" + data.itemId;
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;

        // 프로퍼티 세팅
        id = data.itemId;
        damage = data.baseDamage;
        count = data.baseCount;

        // prefabID찾기 (독립성을 위해서 인덱스로 맞추기 보단 프리펩으로 설정함.)
        for (int i = 0; i < GameManager.instance.pool.prefabs.Length; i ++)
        {
            if (data.projectile == GameManager.instance.pool.prefabs[i])
            {
                prefabId = i;
                break;
            }
        }

        switch(id)
        {
            case 0:
            {
                speed = 150;
                Batch();
                break;
            }

            default:
            {
                speed = 0.3f; // 연사 속도. 작을수록 더 많이 쏜다.
                break;
            }
        }
    }

    private void Batch()
    {
        for (int i = 0; i < count; i ++) 
        {
            Transform bullet; 
            if (i < transform.childCount)
            {
                bullet = transform.GetChild(i);
            }
            else 
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
            }

            // 부모 설정 후 초기 위치를 부모의 위치로 이동
            bullet.parent = transform;
            bullet.position = transform.position; // 부모(중심)의 위치를 기준으로 총알을 배치

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            float angle = 360f * i / count;
            bullet.Rotate(0, 0, angle);
            bullet.Translate(Vector2.up * -1.5f, Space.Self);
            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero); // -1은 무한
        }
    }

    private void Fire()
    {
        if (!player.scanner.nearestTarget) return;

        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized; // 현재 벡터의 뱡향은 유지되고 크기가 1이 됨.
        
        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir); // 지정된 축을 중심으로 목표를 향해 회전하는 함수
        bullet.GetComponent<Bullet>().Init(damage, count, dir); // -1은 무한
    }
}
