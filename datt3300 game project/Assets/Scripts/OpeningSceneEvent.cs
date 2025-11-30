using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class OpeningSceneEvent : MonoBehaviour
{
    public TMP_Text dialogue;
    public GameObject skipButton;
    [SerializeField] int eventPos = 0;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject fadeIn;
    [SerializeField] GameObject title;

    [SerializeField] GameObject sb1Group;
    [SerializeField] GameObject sb3Group;
    [SerializeField] GameObject sb1;
    [SerializeField] GameObject sb2;
    [SerializeField] GameObject sb3;
    [SerializeField] GameObject sb4;
    [SerializeField] GameObject sb5;
    [SerializeField] GameObject sb6;
    [SerializeField] GameObject sb7;

    [SerializeField] AudioSource source;

    void Start()
    {
        fadeIn.SetActive(true);
        StartCoroutine(EvenStarter());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            source.Play();
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
            else if (eventPos == 6)
            {
                StartCoroutine(EventSix());

            }
            else if (eventPos == 7)
            {
                StartCoroutine(EventSeven());

            }
            else if (eventPos == 8)
            {
                StartCoroutine(EventEight());

            }
            else if (eventPos == 9)
            {
                StartCoroutine(EventNine());

            }
            else if (eventPos == 10)
            {
                StartCoroutine(EventTen());

            }
            else if (eventPos == 11)
            {
                StartCoroutine(EventEleven());

            }
            else if (eventPos == 12)
            {
                StartCoroutine(EventTwelve());

            }
            else if (eventPos == 13)
            {
                StartCoroutine(EventEnd());
            }
        }
    }

    IEnumerator EvenStarter()
    { // event 0;
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        sb1.SetActive(true);
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
        yield return new WaitForSeconds(1);
        eventPos = 1;
    }

    IEnumerator EventOne()
    {   //event 1
        sb2.SetActive(true);
        eventPos = 2;
        yield return new WaitForEndOfFrame();
    }

    IEnumerator EventTwo()
    {
        // event 2
        sb3.SetActive(true);
        dialogue.text = "I was born with the sight to perceive souls as clearly as others see flesh and bone.";
        yield return new WaitForEndOfFrame();
        eventPos = 3;
    }

    IEnumerator EventThree()
    {
        //event 3
        sb1Group.SetActive(false);
        sb4.SetActive(true);
        dialogue.text = "The living carry their souls within their phyical bodies, vessels I call Containers.";
        yield return new WaitForEndOfFrame();
        eventPos = 4;
    }
    IEnumerator EventFour()
    {
        // event 4
        yield return new WaitForEndOfFrame();
        dialogue.text = "Around each person shimmers an aura, its colour and form are unique.";
        eventPos = 5;

    }

    IEnumerator EventFive()
    { // event 5
        sb4.SetActive(false);
        sb5.SetActive(true);
        dialogue.text = "But death changes everything.";
        yield return new WaitForEndOfFrame();
        eventPos = 6;

        
    }


    IEnumerator EventSix()
    {
        dialogue.text = "When a container fails, the soul slips free. ";
        yield return new WaitForEndOfFrame();
        eventPos = 7;
    }

    IEnumerator EventSeven()
    {
        sb6.SetActive(true);
        yield return new WaitForEndOfFrame();
        eventPos = 8;
    
    }


    IEnumerator EventEight()
    {
        sb7.SetActive(true);
        dialogue.text = "Most are taken swiftly for Recycling: collected, purified, and refined into the raw essence used to shape new life.";
        yield return new WaitForEndOfFrame();
        eventPos = 9;
    }

    IEnumerator EventNine()
    {
        sb3Group.SetActive(false);
        dialogue.text = "Yet some souls resist. They cling to old memories, old wounds. They drift through the world in unrest, staining the air with sorrow, fear, and rage.";
        yield return new WaitForEndOfFrame();
        eventPos = 10;
    }

    IEnumerator EventTen()
    {
       
        dialogue.text = "Those are the ones that fall to me...";
        yield return new WaitForEndOfFrame();
        eventPos = 11;
    }

    IEnumerator EventEleven()
    {
        dialogue.text = "As a Soul Shepherd, I track these wandering spirit, calm their turbulence, and cleanse them so they can return to the cycle.";
        yield return new WaitForEndOfFrame();
        eventPos = 12;
    }
    IEnumerator EventTwelve()
    {
        dialogue.text = "In every case, the body tells one story.\nBut the soul?\nIt tells another. ";
        yield return new WaitForEndOfFrame();
        eventPos = 13;
 
    }

    IEnumerator EventEnd()
    {
        dialogue.text = "";
        skipButton.SetActive(false);
        yield return new WaitForSeconds(1);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        title.SetActive(true);
        yield return new WaitForSeconds(2);
        eventPos = 14;
        gameManager.LoadLevel("SampleScene");
    }
    public void SkipButton()
    {
        StartCoroutine(EventEnd());
    }



}
