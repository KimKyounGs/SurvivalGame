using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    private Transform target;
    private float speed;
    private bool isAttracting = false;

    public void StartAttraction(Transform playerTransform, float attractionSpeed)
    {
        target = playerTransform;
        speed = attractionSpeed;
        isAttracting = true;
    }

    void Update()
    {
        if (isAttracting && target != null)
        {
            // 플레이어 쪽으로 이동
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // 일정 거리 안에 도달하면 파괴
            if (Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                Player player = target.GetComponent<Player>();
                if (player != null)
                {
                    player.AddXP(10); 
                    Debug.Log("플레이어가 10의 경험치를 획득했습니다.");
                }

                Destroy(gameObject);
            }
        }
    }
}
