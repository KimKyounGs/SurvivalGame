using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeStopEffect", menuName = "Item/Effects/Time Stop")]
public class TimeStopEffect : ItemEffect
{
    public float duration;
    private List<Rigidbody2D> affectedObjects = new List<Rigidbody2D>();

    public override void Effect(GameObject target)
    {
        // 모든 적 또는 대상 오브젝트의 Rigidbody2D를 찾음
        foreach (var obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log("Kinematic Stop!!");
                affectedObjects.Add(rb);
                rb.velocity = Vector2.zero; // 속도 멈춤
                rb.isKinematic = true; // 물리 연산 멈춤
            }
        }

        target.GetComponent<MonoBehaviour>().StartCoroutine(ResumeTimeAfterDelay(duration));
    }

    private IEnumerator ResumeTimeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 모든 오브젝트의 움직임 복원
        foreach (var rb in affectedObjects)
        {
            rb.isKinematic = false; // 물리 연산 재개
        }

        affectedObjects.Clear();
    }
}

