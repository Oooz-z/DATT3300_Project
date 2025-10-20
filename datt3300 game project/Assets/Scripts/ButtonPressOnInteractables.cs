using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressOnInteractables : MonoBehaviour
{
    private Interactables interactable;

    public GameObject dialoguePanel;
    private void Start()
    {
        // Try to find an Interactables component on this object
        interactable = GetComponent<Interactables>();
    }
    private void OnMouseDown()
    {
        
        if (!dialoguePanel.activeSelf && !isDeductionPanelActive())
        {
            Interaction();
        }
    }

    void Interaction()
    {
        if (interactable != null && interactable.itemToPickup != null)
        {
            var item = interactable.itemToPickup;
            interactable.Interact();
        }

    }

    public void OnMouseEnter()
    {
        if (!dialoguePanel.activeSelf && !isDeductionPanelActive())
        {
            MouseControl.instance.Clickable();
        }
    }

    public void OnMouseExit()
    {
        MouseControl.instance.Default();
    }

    private bool isDeductionPanelActive()
    {
        return DeductionPanelManager.Instance != null && DeductionPanelManager.Instance.deductionPanel.activeSelf;
}

}
