using System;
using UnityEngine;

[Serializable]
public class ItemData
{
    [SerializeField] public int Id { get; private set; }
    [SerializeField] public string Name { get; private set; }
    [SerializeField] public string Discription { get; private set; }
    [SerializeField] public int MaxAmountInCell { get; private set; }
    [SerializeField] public Sprite Sprite { get; private set; }

    [SerializeField] public Boolean CanEquip { get; private set; }

}
