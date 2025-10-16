using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressOnInteractables : MonoBehaviour
{
    private Interactables interactable;

    private void Start()
    {
        // Try to find an Interactables component on this object
        interactable = GetComponent<Interactables>();
    }
    private void OnMouseDown()
    {
        Interaction();

    }


    void Interaction()
    {
        if (gameObject.name == "Thermostat")
        {
            Debug.Log("Thermostat"); // do something else;
        }
        else if (gameObject.name == "Fan")
        {
            Debug.Log("Fan");
        }
        else if (gameObject.name == "Body")
        {
            Debug.Log("Body");
        }
        else if (gameObject.name == "Lightbulb_L" || gameObject.name == "Lightbulb_R")
        {
            Debug.Log("Lightbulb");
        }
        else if (gameObject.name == "Window")
        {
            Debug.Log("Window");
        }
        else if (gameObject.name == "Handprints")
        {
            Debug.Log("Handprints");
        }
        else if (gameObject.name == "Door_knob")
        {
            Debug.Log("Door_knob");
        }
        else if (gameObject.name == "Mirror")
        {
            Debug.Log("Mirror");
        }
        else if (gameObject.name == "Toothbrushes")
        {
            Debug.Log("Toothbrushes");
        }
        else if (gameObject.name == "Shower_head")
        {
            Debug.Log("Shower_head");
        }
        else if (gameObject.name == "Footprints")
        {
            Debug.Log("Footprints");
        }
        else if (gameObject.name == "Footprints (1)")
        {
            Debug.Log("Footprints (1)");
        }


        if (interactable != null)
        {
            interactable.Interact();
        }

    }




    public void OnMouseEnter()
    {
        MouseControl.instance.Clickable();
    }

    public void OnMouseExit()
    {
        MouseControl.instance.Default();
    }



}
