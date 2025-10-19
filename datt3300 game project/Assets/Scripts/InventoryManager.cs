using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlot;
    public GameObject inventoryItemPrefab;


    private List<Item> collectedItems = new List<Item>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public bool AddItem(Item item)
    {

        if (collectedItems.Contains(item))
        {
           // Debug.Log("Item already collected: " + item.itemName);
            return false;
        }

        for (int i = 0; i < inventorySlot.Length; i++)
        {
            InventorySlot slot = inventorySlot[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                collectedItems.Add(item); // Track it
                return true;
            }
        }

        return false;

    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}
