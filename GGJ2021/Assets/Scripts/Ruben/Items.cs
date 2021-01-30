using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Beach,
    Camp,
    Holiday,
}

public abstract class Items: ScriptableObject
{
    public Sprite sprite;
    public new string name;
    public ItemType type;
}