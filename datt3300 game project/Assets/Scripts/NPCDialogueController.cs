using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCDialogueController : MonoBehaviour
{
    [SerializeField] int eventPos = 0;

    public GameObject nextButton;
    public GameObject prevButton;

    public GameObject choice1Button;
    public GameObject choice2Button;

    private static NPCDialogueController instance;
    public static NPCDialogueController Instance => instance;

    private bool flag;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        ResetUI();

    }

    public void NPCEvent()
    {
        JumpToEvent();
            
    }


    private void EventStarter()
    {
        DialogueManager.Instance.ShowNPCDialogue("Line 0");
        nextButton.SetActive(true);
        prevButton.SetActive(false);
        eventPos = 1;
    }

    private void EventOne()
    {
        DialogueManager.Instance.ShowNPCDialogue("Line 1");
        prevButton.SetActive(true);
        nextButton.SetActive(true);
        eventPos = 2;
    }

    private void EventTwo()
    {
        DialogueManager.Instance.ShowNPCDialogue("Line 2");
        prevButton.SetActive(true);
        nextButton.SetActive(true);
        eventPos = 3;
    }


    private void EventThree()
    {
        DialogueManager.Instance.ShowNPCDialogue("Line 3");
        prevButton.SetActive(true);
        nextButton.SetActive(true);
        eventPos = 4;
    }

    private void EventFour()
    {
        DialogueManager.Instance.ShowNPCDialogue("Line 4");
        prevButton.SetActive(false);
        nextButton.SetActive(false);
        choice1Button.SetActive(true);
        choice2Button.SetActive(true);
        eventPos = 5;
    }

    private void EventFive()
    {
        DialogueManager.Instance.ShowNPCDialogue("Choice 1 branch");
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);
        prevButton.SetActive(false);
        nextButton.SetActive(true);
        eventPos = 6;
    }


    private void EventSix()
    {
        DialogueManager.Instance.ShowNPCDialogue("Choice 2 branch");
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);
        prevButton.SetActive(false);
        nextButton.SetActive(true);
        eventPos = 7;
    }

    private void EventSeven()
    {
        DialogueManager.Instance.ShowNPCDialogue("Line 5");
        prevButton.SetActive(true);
        nextButton.SetActive(false);
        eventPos = 8;
    }


    public void Choice1Button()
    {
        if (eventPos == 5)
        {
            flag = false;
            EventFive();
        }
    }

    public void Choice2Button()
    {
        if (eventPos == 5)
        {
            flag = true;
            EventSix();
        }
    }

    public void NextButton()
    {
        switch (eventPos)
        {
            case 1:
                EventOne();
                break;
            case 2:
                EventTwo();
                break;
            case 3:
                EventThree();
                break;
            case 4:
                EventFour();
                break;
            case 6:
                EventSeven();
                break;
            case 7:
                EventSeven();
                break;
            case 8:
                EventSeven(); // stay in eventPos == 8 because this is the last dialogue event for now
                break;
            default:
                break;
        }

    }
    public void PrevButton()
    {

        if (eventPos == 8 && flag == false)
        {
            EventFive();
        }
        else if (eventPos == 8 && flag == true)
        {
            EventSix();
        }
        else if (eventPos == 4)
        {
            EventTwo();
        }
        else if (eventPos == 3)
        {
            EventOne();
        }
        else if (eventPos == 2)
        {
            EventStarter();
        }


    }

    public void ResetUI()
    {
        nextButton.SetActive(false);
        prevButton.SetActive(false);
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);
    }


    private void JumpToEvent()
    {
        switch (eventPos)
        {
            case 0:
                EventStarter(); break;
            case 1:
                EventStarter(); break;
            case 2:
                EventOne(); break;
            case 3:
                EventTwo(); break;
            case 4: 
                EventThree(); break;
            case 5:
                EventFour(); break;
            case 6:
                EventFive(); break;
            case 7: 
                EventSix(); break;
            case 8:
                EventSeven(); break;
        }
    }

}
