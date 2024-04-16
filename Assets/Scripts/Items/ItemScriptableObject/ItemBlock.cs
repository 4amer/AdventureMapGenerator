using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Block", menuName = "ScriptableObjects/Items/Block", order = 2)]
[Serializable]
public class ItemBlock : ScriptableObject
{
    [SerializeField] public BlockData BlockData { get; private set; }
}
