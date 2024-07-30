using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
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

        switch (transform.tag) {
            case "Grond": 
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

                break;
            }
        }
    }
}
