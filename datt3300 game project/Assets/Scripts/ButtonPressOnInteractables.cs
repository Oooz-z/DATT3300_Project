using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressOnInteractables : MonoBehaviour
{
    private Interactables interactable;

    [SerializeField] Animator dialoguePanelAnimator;
    private void Start()
    {
        // Try to find an Interactables component on this object
        interactable = GetComponent<Interactables>();
    }
    private void OnMouseDown()
    {
        if (!isDeductionPanelActive())
        {
            Interaction();
            dialoguePanelAnimator.SetTrigger("Open");
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
        if ( !isDeductionPanelActive())
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
