using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncollectableInteractables : Interactables
{
    public override void Interact()
    {
        DialogueManager.Instance.ShowCollectableDialogue(itemToPickup.dialogueLine);
 
    }

}
