using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Item.cs
 * 
 * This abstract class represents every item in the system!
 * Use subclasses for different types of items.
 * */
[System.Serializable]
public abstract class Item : ScriptableObject
{
    public string itemName = "Item";
    public Sprite image;
}
