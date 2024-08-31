using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealItem", menuName = "Item/Effects/Heal")]
public class HealEffect : ItemEffect
{
    public int healAmount;
    public override void Effect(GameObject target)
    {
        // 체력 회복
        Player player = target.GetComponent<Player>();
        if (player != null)
        {
            player.HealHP(healAmount);
        }
    }
}
