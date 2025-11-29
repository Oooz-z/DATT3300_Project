using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    private static DialogueManager instance;
    public static DialogueManager Instance => instance;
 
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        //dialoguePanel.SetActive(false);

    }



    // for collectable items
    public void ShowCollectableDialogue(string dialogueLine) //changed from itemName --> dialogueLine
    {
        if (NPCDialogueController.Instance != null)
        {
            NPCDialogueController.Instance.ResetUI();
        }
        
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueLine;

    }

    // For NPC
    public void ShowNPCDialogue(string dialogueLine)
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueLine;
    }


    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
      
    }



}
