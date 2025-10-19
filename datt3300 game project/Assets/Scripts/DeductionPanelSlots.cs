using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeductionPanelSlots : MonoBehaviour, IDropHandler
{
    
    public DeductionPanelManager deductionPanelManager;

    public int slotID;


    private void Awake()
    {
      //  DontDestroyOnLoad(transform.root.gameObject);
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("DROP on slot: " + gameObject.name);

        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;

           // Debug.Log(inventoryItem.item.itemName);


            if (deductionPanelManager != null)
            {
               StartCoroutine(DelayedCheck(inventoryItem));
            }
          
        } 
          
    }

    private IEnumerator DelayedCheck(InventoryItem item)
    {
        yield return new WaitForEndOfFrame();

        deductionPanelManager.CheckSLot(slotID, item);
        
    }


}
