using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
   // 아이템 타입을 정의
    enum ItemType { Heal, FreezeEnemy, AttractXP }
    
    // 힐, 적 얼리기, 경험치 아이템을 연결할 오브젝트
    public GameObject healItem;
    public GameObject freezeEnemyItem;
    public GameObject attractXPItem;

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Break();
        }
    }

    void SpawnRandomItem()
    {
        ItemType randomItem = (ItemType)Random.Range(0, 3);

        switch (randomItem)
        {
            case ItemType.Heal:
                Instantiate(healItem, transform.position, Quaternion.identity);
                Debug.Log("healItem 생성됨");
                break;

            case ItemType.FreezeEnemy:
                Instantiate(freezeEnemyItem, transform.position, Quaternion.identity);
                Debug.Log("freezeEnemyItem 생성됨");
                break;

            case ItemType.AttractXP:
                Instantiate(attractXPItem, transform.position, Quaternion.identity);
                Debug.Log("attractXPItem 생성됨");
                break;
        }

        Destroy(gameObject);
    }
    // 상자가 부서질 때 호출될 메소드
    public void Break()
    {
        SpawnRandomItem();
    }
}
