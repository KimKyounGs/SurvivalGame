using UnityEngine;

public class AttractXPItem : MonoBehaviour
{
    public float attractionSpeed = 5f;   // 끌어당기는 속도

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 모든 경험치 오브젝트를 찾아서 플레이어에게 끌어당김
            XP[] xpObjects = FindObjectsOfType<XP>();
            foreach (XP xp in xpObjects)
            {
                xp.StartAttraction(other.transform, attractionSpeed);
                Debug.Log("경험치 오브젝트가 플레이어에게 끌어당겨집니다.");
            }

            // 아이템 파괴
            Destroy(gameObject);
        }
    }
}
