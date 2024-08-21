using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    public ItemData[] items; // 아이템 프리팹

    // 상자가 부서질 때 호출될 메소드
    public void Break()
    {
        int randomIndex = Random.Range(0, items.Length);
        ItemData selectedItem = items[randomIndex];
        // 아이템 생성 생성
        Instantiate(selectedItem, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Break();
        }
    }
}
