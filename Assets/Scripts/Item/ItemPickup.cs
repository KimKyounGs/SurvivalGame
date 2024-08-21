using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemEffect item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (item != null)
            {
                item.Effect(collision.gameObject);
            }
        }

        Destroy(gameObject);
    }
}
