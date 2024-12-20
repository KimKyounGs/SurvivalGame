using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    private void Awake() 
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (!other.CompareTag("Area")) return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float dx = Mathf.Abs(playerPos.x - myPos.x); // 절대값 적용
        float dy = Mathf.Abs(playerPos.y - myPos.y); // 절대값 적용

        Vector3 playerDir = GameManager.instance.player.moveInput;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag) 
        {
            case "Ground": 
            {
                if (dx > dy) 
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (dx < dy)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            }
            case "Enemy":
            {
                if (coll.enabled) 
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f)); // 맵 하나만큼 이동
                }
                break;
            }
        }
    }
}
