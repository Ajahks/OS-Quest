using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Inventory.cs
 * Holds items for player.
 * See tutorial: https://toqoz.svbtle.com/a-unity-inventory-system-that-actually-works
 * */
[System.Serializable]
[CreateAssetMenu(menuName = "Items/Inventory", fileName = "Inventory.asset")]
public class Inventory : ScriptableObject
{
    // How much money is in this inventory's wallet
    public int money = 0;

    // Store items in this array. (Use list?)
    public Item[] inventory;

    // Checks if a slot is empty
    public bool IsSlotEmpty(int index) {
        if (inventory[index] == null)
            return true;

        return false;
    }

    // Get an item if it exists.
    public Item GetItem(int index) {
        // inventory[index] doesn't return null, so check item instead.
        if (IsSlotEmpty(index)) {
            return null;
        }

        return inventory[index];
    }

    // Remove an item at an index if one exists at that index.
    public bool RemoveItem(int index) {
        if (IsSlotEmpty(index)) {
            // Nothing existed at the specified slot.
            return false;
        }

        inventory[index] = null;

        return true;
    }

    // Insert an item, return the index where it was inserted.  -1 if error.
    public int InsertItem(Item item) {
        for (int i = 0; i < inventory.Length; i++) {
            if (IsSlotEmpty(i)) {
                inventory[i] = item;
                return i;
            }
        }

        // Couldn't find a free slot.
        return -1;
    }
}
