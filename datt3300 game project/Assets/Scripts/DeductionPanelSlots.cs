using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeductionPanelSlots : MonoBehaviour, IDropHandler
{
    
    public DeductionPanelManager deductionPanelManager;

    public int slotID;

    private Image slotImage;

    public InventoryItem currentItem;


    private void Awake()
    {
      slotImage = GetComponent<Image>();
      if (slotImage != null )
        {
            ResetColor();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        var droppedItem = eventData.pointerDrag?.GetComponent<InventoryItem>();
        if (droppedItem == null) return;
        
        SetItem(droppedItem);
        // Notify the manager
        DeductionPanelManager.Instance.CheckSlot(slotID, droppedItem);
    }

    public void ResetColor()
    {
        if (slotImage != null)
        {
            slotImage.color = new Color(0.969f, 0.898f, 0.925f);
        }
    }

    public void SetColor(Color color)
    {
        if (slotImage != null)
        {
            slotImage.color = color;
        }
    }

    public void SetItem(InventoryItem item)
    {
        currentItem = item;
        if (item == null)
        {
            ResetColor();
        }
    }

}
