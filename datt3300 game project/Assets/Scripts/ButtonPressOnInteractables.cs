using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressOnInteractables : MonoBehaviour
{
    private Interactables interactable;

    public GameObject dialoguePanel;
    public GameObject deductionPanel;

    private void Start()
    {
        // Try to find an Interactables component on this object
        interactable = GetComponent<Interactables>();
    }
    private void OnMouseDown()
    {
        if (!dialoguePanel.activeSelf && !deductionPanel.activeSelf)
        {
            Interaction();
        }
        

    }


    void Interaction()
    {
        if (interactable != null && interactable.itemToPickup != null)
        {
            var item = interactable.itemToPickup;
            DialogueManager.Instance.ShowDialogue(item.itemName);
            interactable.Interact();
        }

    }

    public void OnMouseEnter()
    {
        if (!dialoguePanel.activeSelf && !deductionPanel.activeSelf)
        {
            MouseControl.instance.Clickable();
        }
    }

    public void OnMouseExit()
    {
        MouseControl.instance.Default();
    }



}
