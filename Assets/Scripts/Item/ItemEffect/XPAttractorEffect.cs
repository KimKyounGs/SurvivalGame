using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "XPAttractorEffect", menuName = "Item/Effects/XP Attractor")]
public class XPAttractorEffect : ItemEffect
{
    public float attractRange;
    public float attractSpeed;

    public override void Effect(GameObject target)
    {
        // 주변의 모든 경험치 오브젝트를 찾아서 플레이어로 끌어당김
        Collider[] xpOrbs = Physics.OverlapSphere(target.transform.position, attractRange);
        foreach (var orb in xpOrbs)
        {
            if (orb.CompareTag("XP"))
            {
                // 경험치 오브젝트를 플레이어로 이동시키는 로직
                orb.transform.position = Vector3.MoveTowards(orb.transform.position, target.transform.position, attractSpeed * Time.deltaTime);
            }
        }
        Debug.Log("XP attracted.");
    }
}