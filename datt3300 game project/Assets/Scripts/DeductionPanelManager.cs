using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class SlotAnswer
{
    public int slotID;
    public List<string> correctItemNames;
}




public class DeductionPanelManager : MonoBehaviour
{
    private static DeductionPanelManager instance;
    public static DeductionPanelManager Instance => instance;

    public DeductionPanelSlots[] deductionPanelSlot;

    public List<SlotAnswer> correctAnswers = new List<SlotAnswer>();

    public TMP_Text prompt;
    public GameObject deductionPanel;
    public GameObject victimFilePanel;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }


    // helper function 1: get the item currently in the slot
    private InventoryItem GetItemInSlot(DeductionPanelSlots slot)
    {
        return slot.currentItem;
    }

    // helper function 2: check is item name is correct for the given slot
    private bool IsItemCorrect(int slotID, string itemName)
    {
        foreach(var answer in correctAnswers)
        {
            if (answer.slotID == slotID && answer.correctItemNames.Contains(itemName))
            {
                return true;
            }
        }
        return false;
    }

    // helper function 3: get current slot by ID
    private DeductionPanelSlots GetSlotByID(int slotID)
    {
        foreach (var slot in  deductionPanelSlot)
        {
            if (slot.slotID == slotID)
            {
                return slot;
            }
        }
        return null;
    }

    public void CheckSlot(int slotID, InventoryItem item)
    {
        
        DeductionPanelSlots currentSlot = GetSlotByID(slotID);

        if (currentSlot == null) return;
        if (item == null)
        {
            currentSlot.ResetColor();
            return;
        }


        bool isCorrect = IsItemCorrect(slotID, item.item.itemName);
        // check individual slot

  
            Image slotImage = currentSlot.GetComponent<Image>();

        if (slotImage != null)
        {
          if (isCorrect)
          {
           // Debug.Log($"Correct item '{item.item.itemName}' placed in slot {slotID}.");
            currentSlot.SetColor(new Color(0.2431f, 1f, 0.8235f));
          }
          else
          {
           // Debug.Log($"Incorrect item '{item.item.itemName}' placed in slot {slotID}.");
            currentSlot.SetColor(new Color(1f, 0.2157f, 0.5216f));
          }

        }



        // check completion
        if (IsSlotsFull())
        {
            if (AllAnswersCorrect())
            {
                prompt.text = "Deduction Completed!";

            }
            else
            {
                prompt.text = "One or more items placed incorrectly.";
            }
        }

    }

    private bool IsSlotsFull()
    {
        foreach (var slot in deductionPanelSlot)
        {
            if (GetItemInSlot(slot) == null)
            {
                return false;
            }
        }
        return true;
    }

    private bool AllAnswersCorrect()
    {
        foreach(var slot in deductionPanelSlot)
        {
            InventoryItem item = GetItemInSlot(slot);

            if (item == null)
            {
                return false;
            }
            if (!IsItemCorrect(slot.slotID, item.item.itemName))
            {
                return false;
            }
        }
        return true;
    }


}
