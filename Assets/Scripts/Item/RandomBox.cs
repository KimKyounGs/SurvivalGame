using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    public ItemData[] itemDatas; // 아이템 프리팹
    // 상자가 부서질 때 호출될 메소드
    public void Break()
    {
        int randomIndex = Random.Range(0, itemDatas.Length);
        ItemData selectedItemData = itemDatas[randomIndex];
        // 아이템 생성 생성 -> '스크립터블 오브젝트'는 게임 오브젝트처럼 위치와 회전을 가지고 있지 않아서 Instantiate함수를 사용하지 못한다.
        Instantiate(selectedItemData.itemPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Break();
        }
    }
}
