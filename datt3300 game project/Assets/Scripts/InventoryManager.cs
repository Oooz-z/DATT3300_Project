using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    public static InventoryManager Instance => instance;

    public InventorySlot[] inventorySlot;
    public GameObject inventoryItemPrefab;


    private List<Item> collectedItems = new List<Item>();

    private int itemCounter;
    public TMP_Text prompt;
    public GameObject ItemAddedNotice;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        
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
                itemCounter++;
                prompt.text = $"{itemCounter}/12";
                ItemAddedNotice.SetActive(true);
                return true;
            }
        }

        return false;

    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);


        newItemGo.transform.SetParent(slot.transform, false); //
        newItemGo.transform.localScale = Vector3.one; //
        newItemGo.transform.localPosition = Vector3.zero; //




        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);


        LayoutRebuilder.ForceRebuildLayoutImmediate(slot.GetComponent<RectTransform>()); //
    }


    public List<Item> getItemCollected()
    {
        return collectedItems;
    }

}
