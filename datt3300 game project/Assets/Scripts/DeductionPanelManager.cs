using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class SlotAnswer
{
    public int slotID;
    public string correctItemName;
}




public class DeductionPanelManager : MonoBehaviour
{
    public DeductionPanelSlots[] deductionPanelSlot;


    public List<SlotAnswer> correctAnswers = new List<SlotAnswer>();


    public TMP_Text prompt;

   [HideInInspector] private bool placedCorrectly = false;

    public void CheckSLot(int slotID, InventoryItem item)
    {
        

        foreach (var answer in correctAnswers)
        {
            if (answer.slotID == slotID)
            {
                if (item.item.itemName == answer.correctItemName)
                {
                   // Debug.Log("Correct");
                    placedCorrectly = true;
                    
                }
                else
                {
                   // Debug.Log("Incorrect");
                    placedCorrectly = false;
                }
                break;
            }
        }

        if (isSlotsFull())
        {
            if (placedCorrectly == true)
            {
               // Debug.Log("Filled correctly");
                prompt.text = "Deduction Completed!";
            }
            else
            {
               // Debug.Log("One or more items placed incorrectly");
                prompt.text = "One or more items placed incorrectly.";
            }
            
        }
        
    }

    public bool isSlotsFull()
    {
        for (int i = 0; i < deductionPanelSlot.Length; i++)
        {
            DeductionPanelSlots slot = deductionPanelSlot[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                return false; // not full yet
            }
            
            
        } 
        
        return true;
    }






}
