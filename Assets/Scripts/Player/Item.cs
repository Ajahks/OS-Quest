using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Texture image;
    public GameObject prefab;

    public bool UpdateData(Transform target)
    {
        Text nameField = target.GetComponentInChildren<Text>();
        RawImage imageField = target.GetComponentInChildren<RawImage>();

        if (nameField && imageField)
        {
            nameField.text = itemName;
            imageField.texture = image;
        }
        else
        {
            Debug.LogError("Name and Image not found: " + itemName);
            return false;
        }

        return true;
    }
}
