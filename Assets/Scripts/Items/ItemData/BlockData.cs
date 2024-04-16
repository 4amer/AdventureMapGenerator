using System;
using UnityEngine;

[Serializable]
public class BlockData : ItemData
{
    [SerializeField] public int Strengh { get; private set; }
}
