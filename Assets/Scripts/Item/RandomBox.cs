using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    public GameObject itemPrefab; // 아이템 프리팹
    public Transform dropPosition;  // 아이템이 나타날 위치

    // 상자가 부서질 때 호출될 메소드
    public void Break()
    {
        // 아이템 생성 생성
        Instantiate(itemPrefab, dropPosition.position, dropPosition.rotation);
        Destroy(gameObject); // 상자 오브젝트 제거
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Break();
        }
    }
}
