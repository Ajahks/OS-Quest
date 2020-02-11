using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;

    // Where item children are created
    public Transform listParent;

    // The UI element for the list panel
    public GameObject inventoryUIPrefab;

    // Start is called before the first frame update
    void Start()
    {
        UpdateItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this when the user interacts with the inventory!
    bool UpdateItems()
    {
        // Error check
        if (!listParent || !inventoryUIPrefab) { return false; }

        for(int i = 0; i < inventory.inventory.Length; i++)
        {
            Transform itemUI = null;

            Item item = inventory.GetItem(i);

            if (!item)
            {
                continue;
            }

            if(i < listParent.childCount)
            {
                itemUI = listParent.GetChild(i);
            }

            // If no child exists to represent this item, create one
            if (!itemUI)
            {
                itemUI = Instantiate(inventoryUIPrefab, listParent).transform;
            }

            item.UpdateData(itemUI);
        }

        return true;
    }
}
