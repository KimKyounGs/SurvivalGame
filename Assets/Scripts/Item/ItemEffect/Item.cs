using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemEffect itemEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (itemEffect != null)
            {
                itemEffect.Effect(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
