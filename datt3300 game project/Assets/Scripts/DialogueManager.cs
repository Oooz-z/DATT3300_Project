using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    private static DialogueManager instance;
    public static DialogueManager Instance => instance;

    public GameObject ghost;
 
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        dialoguePanel.SetActive(false);
        ghost.SetActive(false);
    }


    public void ShowDialogue(string itemName) 
    {
        dialoguePanel.SetActive(true);
        switch (itemName)
        {
            case "Footprints":
                dialogueText.text = "This is Foorprints";
                break;
            case "ShowerHead":
                dialogueText.text = "This is Shower head";
                break;
            case "Thermostat":
                dialogueText.text = "This is a Thermostat.";
                break;
            case "Fan":
                dialogueText.text = "This is a Fan.";
                break;
            case "Body":
                dialogueText.text = "This is a Body.";
                ghost.SetActive(true); // NPC item became available for player
                break;
            case "Lightbulb":
                dialogueText.text = "This is a Light bulb.";
                break;
            case "Window":
                dialogueText.text = "This is a Window.";
                break;
            case "DoorKnob":
                dialogueText.text = "This is a Door knob.";
                break;
            case "Mirror":
                dialogueText.text = "This is a Mirror.";
                break;
            case "Toothbrush":
                dialogueText.text = "This is a Toothbrush.";
                break;
            case "Handprint":
                dialogueText.text = "This is a Handprint.";
                break;
            default:
                dialoguePanel.SetActive(false);
                break;
        }

        
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }

}
