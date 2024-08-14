using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Stop!!!!!");
            // 시간 멈추기 기능 실행
            StopEnemiesTime();
            Destroy(gameObject); // 물약 제거
        }
    }

    void StopEnemiesTime()
    {
        // 모든 적 오브젝트를 찾아 시간 멈추기
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            enemy.isFrozen = true;
        }
    }
}
