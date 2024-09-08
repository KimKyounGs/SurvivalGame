using UnityEngine;

public class HealItem : MonoBehaviour
{
    public int healAmount = 50; // 회복량

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.HealHP(healAmount);
                Debug.Log("플레이어가 " + healAmount + " 만큼 회복되었습니다.");
            }

            Destroy(gameObject);
        }
    }
}
