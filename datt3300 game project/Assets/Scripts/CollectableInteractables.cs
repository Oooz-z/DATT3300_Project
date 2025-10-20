using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CollectableInteractables : Interactables
{

    public override void Interact()
    {
        DialogueManager.Instance.ShowCollectableDialogue(itemToPickup.dialogueLine);
        InventoryManager.Instance.AddItem(itemToPickup);
    }
}
