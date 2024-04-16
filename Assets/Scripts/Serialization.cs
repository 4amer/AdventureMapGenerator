using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Serialization<T>
{
    [SerializeField]
    private List<T> target;

    public List<T> ToSerializableList()
    {
        return target;
    }

    public Serialization(List<T> target)
    {
        this.target = target;
    }
}
