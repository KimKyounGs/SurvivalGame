using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    private List<GameObject>[] pools;

    private void Awake() {
        pools = new List<GameObject>[prefabs.Length]; // 크기 할당

        for (int i = 0; i < pools.Length; i ++) {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index) 
    {
        GameObject select = null;
        // .. 선택한 풀의 비활성화 되어있는 게임오브젝트 접근
        // 발견하면 select 변수에 할당
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf) {
                // 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 못 찾으면
        // 새롭게 생성하고 select 변수에 할당
        if (!select) {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        } 

        // Debug.Log("GetSelect");
        return select;
    }
}
