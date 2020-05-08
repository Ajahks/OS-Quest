using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;

    public Transform hatParent;
    GameObject hatLast;

    // Where item children are created
    public Transform listParent;

    // The UI element for the list panel
    public Button inventoryUIPrefab;

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
            Button itemUI = null;

            Item item = inventory.GetItem(i);

            if (!item)
            {
                continue;
            }

            // Indexes are associated with inventory
            if(i < listParent.childCount)
            {
                itemUI = listParent.GetChild(i).GetComponent<Button>();
            }

            // If no child exists to represent this item, create one
            if (!itemUI)
            {
                itemUI = Instantiate(inventoryUIPrefab, listParent);
                int a = i;
                itemUI.onClick.AddListener(() => EquipItem(inventory.inventory[a].prefab));
            }

            item.UpdateData(itemUI.transform);
        }

        return true;
    }

    void EquipItem(GameObject obj)
    {
        if(hatLast) Destroy(hatLast);
        hatLast = Instantiate(obj, hatParent);
    }
}
