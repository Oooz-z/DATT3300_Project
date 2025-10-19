using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CollectableInteractables : Interactables
{
    [SerializeField] private InventoryManager inventoryManager;

    private void Awake()
    {
        DontDestroyOnLoad(transform.root.gameObject);
   
    }

    public override void Interact()
    {
        DialogueManager.Instance.ShowCollectableDialogue(itemToPickup.dialogueLine);
        inventoryManager.AddItem(itemToPickup);
    }
}
