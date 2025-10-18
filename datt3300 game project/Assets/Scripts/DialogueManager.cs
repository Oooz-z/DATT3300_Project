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
 
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        dialoguePanel.SetActive(false);
    }


    public void ShowDialogue(string dialogueLine) //changed from itemName --> dialogueLine
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueLine;

    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }

}
