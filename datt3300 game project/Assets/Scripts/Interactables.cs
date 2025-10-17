using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item itemToPickup;


    public void Interact()
    {
        if (itemToPickup != null)
        {
           bool result = inventoryManager.AddItem(itemToPickup);
            //Destroy(gameObject); // item can only be added once.

            if (result == true)
            {
               // Debug.Log("Item added");
            }
            else
            {
               // Debug.Log("Item Not added");
            }
           
            
        }
    }
}
