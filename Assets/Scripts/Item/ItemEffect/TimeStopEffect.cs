using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeStopEffect", menuName = "Item/Effects/Time Stop")]
public class TimeStopEffect : ItemEffect
{
    public float duration;

    public override void Effect(GameObject target)
    {
        // 게임 내 시간을 멈추고 일정 시간 후에 원상 복구
        Time.timeScale = 0f;
        Debug.Log($"Time stopped for {duration} seconds.");

        target.GetComponent<MonoBehaviour>().StartCoroutine(ResumeTimeAfterDelay(duration));
    }

    private IEnumerator ResumeTimeAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f;
        Debug.Log("Time resumed.");
    }
}

