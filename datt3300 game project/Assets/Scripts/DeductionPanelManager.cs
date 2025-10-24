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

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    public void CheckSLot(int slotID, InventoryItem item)
    {

        if (isSlotsFull())
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
        

    public bool isSlotsFull()
    {
        for (int i = 0; i < deductionPanelSlot.Length; i++)
        {
            DeductionPanelSlots slot = deductionPanelSlot[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                //Debug.Log("Not filled");
                return false; 
            }
            
            
        } 
        
        return true;
    }

    private bool AllAnswersCorrect()
    {
        foreach (var slot in deductionPanelSlot)
        {
            int slotID = slot.slotID;
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            if (itemInSlot == null)
            {
                return false; 
            }
               

            bool matchFound = false;

            foreach (var answer in correctAnswers)
            {
                if (answer.slotID == slotID && answer.correctItemNames.Contains(itemInSlot.item.itemName))
                {
                    Debug.Log ("Correct");
                    matchFound = true;
                    break;
                }
            }

            if (!matchFound)
                Debug.Log ("Incorrect");
                return false;
        }

        return true; 
    }





}
