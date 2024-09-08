using UnityEngine;

public class FreezeEnemyItem : MonoBehaviour
{
    public float freezeDuration = 5f; // 얼리기 지속 시간

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 모든 적을 찾아서 얼리기
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                enemy.Freeze(freezeDuration);
                Debug.Log("적이 " + freezeDuration + "초 동안 얼려졌습니다.");
            }

            Destroy(gameObject);
        }
    }
}
