using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class OpeningSceneEvent : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TMP_Text dialogue;
    public GameObject skipButton;
    [SerializeField] public GameObject nextButton;
    [SerializeField] int eventPos = 0;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject title;

    void Start()
    {
        StartCoroutine(EvenStarter());
    }


    IEnumerator EvenStarter()
    { // event 0;
        dialoguePanel.SetActive(true);
        yield return new WaitForSeconds(1);
        dialogue.text = "this is a dialogue.";
        yield return new WaitForSeconds(1);
        nextButton.SetActive(true);
        yield return new WaitForSeconds(1);
        skipButton.SetActive(true);
        eventPos = 1;
    }

    IEnumerator EventOne()
    {   //event 1
        dialogue.text = "this is the 2nd line.";
        eventPos = 2;
        yield return new WaitForEndOfFrame();
    }

    IEnumerator EventTwo()
    {
        // event 2
        dialogue.text = "this is the 3rd line.";
        yield return new WaitForEndOfFrame();
        eventPos = 3;
    }

    IEnumerator EventThree()
    {
        // event 3
        dialogue.text = "this is the 4th line.";
        yield return new WaitForEndOfFrame();
        eventPos = 4;
    }
    IEnumerator EventFour()
    {
        // event 4
        dialogue.text = "this is the 5th line.";
        yield return new WaitForEndOfFrame();
        eventPos = 5;

    }

    IEnumerator EventFive()
    { // event 5
        dialogue.text = "";
        yield return new WaitForSeconds(1);
        dialoguePanel.SetActive(false);
        nextButton.SetActive(false);
        skipButton.SetActive(false);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        title.SetActive(true);
        yield return new WaitForSeconds(3);
        eventPos = 6;
        gameManager.LoadLevel("SampleScene");
        
    }
    public void NextButton()
    {
        if (eventPos == 1)
        {
            StartCoroutine(EventOne());
        }
        else if (eventPos == 2)
        {
            StartCoroutine(EventTwo());
        }
        else if (eventPos == 3)
        {
            StartCoroutine(EventThree());
        }
        else if (eventPos == 4)
        {
            StartCoroutine(EventFour());
        }
        else if (eventPos == 5)
        {
            StartCoroutine(EventFive());
            
        }
    }

    public void SkipButton()
    {
        StartCoroutine(EventFive());
    }

}
