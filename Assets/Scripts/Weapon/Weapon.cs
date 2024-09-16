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

    private void Start()
    {
        Init();
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
                break;
            }
        }
    }
    public void Init()
    {
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
                break;
            }
        }
    }

    private void Batch()
    {
        for (int i = 0; i < count; i ++) 
        {
            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;

            // 부모 설정 후 초기 위치를 부모의 위치로 이동
            bullet.parent = transform;
            bullet.position = transform.position; // 부모(중심)의 위치를 기준으로 총알을 배치
            float angle = 360f * i / count;
            bullet.Rotate(0, 0, angle);
            bullet.Translate(Vector2.up * -1.5f, Space.Self);
            bullet.GetComponent<Bullet>().Init(damage, -1); // -1은 무한
        }
    }
}
