using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressOnInteractables : MonoBehaviour
{
    private Interactables interactable;

    [SerializeField] Animator dialoguePanelAnimator;
    [SerializeField] AudioSource source;
    private void Start()
    {
        // Try to find an Interactables component on this object
        interactable = GetComponent<Interactables>();

    }


    private void OnMouseDown()
    {
        if (!isDeductionPanelActive() && !isDialougePanelActive() && !isVictimFilePanelActive())
        {
            Interaction();
            source.Play();
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
        if ( !isDeductionPanelActive() && !isDialougePanelActive() && !isVictimFilePanelActive())
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

    private bool isDialougePanelActive()
    {
        if (DialogueManager.Instance == null)
            return false;

        if (!DialogueManager.Instance.dialoguePanel.activeInHierarchy)
            return false;
        var state = dialoguePanelAnimator.GetCurrentAnimatorStateInfo(0);
        return state.IsName("DiaPanelOpened");
    }

    private bool isVictimFilePanelActive()
    {
        return DeductionPanelManager.Instance != null && DeductionPanelManager.Instance.victimFilePanel.activeSelf;
    }

}
