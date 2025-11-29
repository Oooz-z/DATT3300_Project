using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCDialogueController : MonoBehaviour
{
    [SerializeField] int eventPos = 0;

    public GameObject nextButton;

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
        DialogueManager.Instance.ShowNPCDialogue("???: You're not like the others... You can SEE me. But what difference does it make? Can you feel what I feel?");
        nextButton.SetActive(true);
        eventPos = 1;
    }

    private void EventOne()
    {
        DialogueManager.Instance.ShowNPCDialogue("???: I don't want to leave. Not yet. I don't want to go to that place...alone. I'm not ready. I can't just let it end like this... I hate it...I hate that...that...");
        nextButton.SetActive(true);
        eventPos = 2;
    }

    private void EventTwo()
    {
        DialogueManager.Instance.ShowNPCDialogue("???: I can't remember anything clearly. But the pain-- it's still here. Sharp. Real. Why? What kind of memory leaves only pain behind?");

        nextButton.SetActive(true);
        eventPos = 3;
    }


    private void EventThree()
    {
        DialogueManager.Instance.ShowNPCDialogue("???: Something was pressing on my chest...");

        nextButton.SetActive(true);
        eventPos = 4;
    }

    private void EventFour()
    {
        DialogueManager.Instance.ShowNPCDialogue("???: If I can't even remember who I was... then whose pain is this?");

        nextButton.SetActive(false);
        choice1Button.SetActive(true);
        choice2Button.SetActive(true);
        eventPos = 5;
    }

    private void EventFive()
    {
        DialogueManager.Instance.ShowNPCDialogue("???: Then... I've become part of the pain.");
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);

        nextButton.SetActive(true);
        eventPos = 6;
    }


    private void EventSix()
    {
        DialogueManager.Instance.ShowNPCDialogue("???: That anger... it's still burning. I can't rest.");
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);

        nextButton.SetActive(true);
        eventPos = 7;
    }

    private void EventSeven()
    {
        DialogueManager.Instance.ShowNPCDialogue("???: Whatever's holding me back... it's still hiding from me.");

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
   

    public void ResetUI()
    {
        nextButton.SetActive(false);
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
