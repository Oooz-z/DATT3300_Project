using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpeningSceneEvent : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TMP_Text dialogue;
    public GameObject skipButton;

    void Start()
    {
        StartCoroutine(EvenStarter());
    }


    IEnumerator EvenStarter()
    {
        yield return new WaitForSeconds(1);
        dialoguePanel.SetActive(true);
        yield return new WaitForSeconds(1);
        dialogue.text = "this is a dialogue.";
        skipButton.SetActive(true);
    }

}
