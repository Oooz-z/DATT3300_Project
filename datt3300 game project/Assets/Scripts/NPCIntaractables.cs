using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIntaractables : Interactables
{
    public override void Interact()
    {
        NPCDialogueController.Instance.NPCEvent();
    }
}
