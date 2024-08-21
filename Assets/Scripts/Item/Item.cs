using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ItemEffect : ScriptableObject
{
    public abstract GameObject Prefab { get; }
    public abstract void Effect(GameObject target);
}
