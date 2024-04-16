using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items/Item", order = 1)]
[Serializable]
public class Item : ScriptableObject
{
    [SerializeField] public ItemData ItemData { get; private set; }
}
