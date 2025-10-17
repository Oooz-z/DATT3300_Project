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
        if (gameObject.name == "Thermostat")
        {
            DialogueManager.Instance.ShowDialogue("This is a Thermostat.");
        }
        else if (gameObject.name == "Fan")
        {
            DialogueManager.Instance.ShowDialogue("This is a Fan.");
        }
        else if (gameObject.name == "Body")
        {
            DialogueManager.Instance.ShowDialogue("This is a Body.");
        }
        else if (gameObject.name == "Lightbulb_L" || gameObject.name == "Lightbulb_R")
        {
            DialogueManager.Instance.ShowDialogue("This is a Light bulb.");
        }
        else if (gameObject.name == "Window")
        {
            DialogueManager.Instance.ShowDialogue("This is a Window.");
        }
        else if (gameObject.name == "Handprints")
        {
            DialogueManager.Instance.ShowDialogue("This is a Handprint.");
        }
        else if (gameObject.name == "Door_knob")
        {
            DialogueManager.Instance.ShowDialogue("This is a Door knob.");
        }
        else if (gameObject.name == "Mirror")
        {
            DialogueManager.Instance.ShowDialogue("This is a Mirror.");
        }
        else if (gameObject.name == "Toothbrushes")
        {
            DialogueManager.Instance.ShowDialogue("This is a Toothbrush.");
        }
        else if (gameObject.name == "Shower_head")
        {
            DialogueManager.Instance.ShowDialogue("This is a Shower head.");
        }
        else if (gameObject.name == "Footprints")
        {
            DialogueManager.Instance.ShowDialogue("This is a FootPrint.");
        }
        else if (gameObject.name == "Footprints (1)")
        {
            DialogueManager.Instance.ShowDialogue("This is a Footprint (1).");
        }


        if (interactable != null)
        {
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
