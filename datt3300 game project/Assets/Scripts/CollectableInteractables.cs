using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CollectableInteractables : Interactables
{
    [SerializeField] private InventoryManager inventoryManager;
   public override void Interact()
    {
        inventoryManager.AddItem(itemToPickup);
    }
}
