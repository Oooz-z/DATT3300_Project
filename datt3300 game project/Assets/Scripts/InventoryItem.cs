using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [Header("UI")] public Image image;

    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;

    private Graphic[] graphics;


    void Awake()
    {
        // Cache all Graphic components in this GameObject and its children
        graphics = GetComponentsInChildren<Graphic>(includeInactive: true);
    }

    void SetRaycasts(bool value)
    {
        foreach (var g in graphics)
        {
            g.raycastTarget = value;
        }
    }


    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        image.enabled = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Begin drag");
        SetRaycasts(false);
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();


    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        SetRaycasts(true);

        // Get the slot we are dropping onto (if any)
        DeductionPanelSlots dropTarget = eventData.pointerCurrentRaycast.gameObject?.GetComponent<DeductionPanelSlots>();

        // Get the previous slot (if the item was in a slot before dragging)
        DeductionPanelSlots previousSlot = parentAfterDrag != null ? parentAfterDrag.GetComponent<DeductionPanelSlots>() : null;

        if (dropTarget != null)
        {
            // If the item was in a previous slot, clear it
            if (previousSlot != null && previousSlot != dropTarget)
                previousSlot.SetItem(null);

            // Reparent the item to the new slot
            transform.SetParent(dropTarget.transform);
            transform.localPosition = Vector3.zero;

            // Assign the item to the new slot
            dropTarget.SetItem(this);

            // Notify the manager about this slot
            DeductionPanelManager.Instance.CheckSlot(dropTarget.slotID, this);
        }
        else
        {
            // Dropped outside any slot
            // Remove from previous slot (if it existed)
            if (previousSlot != null)
                previousSlot.SetItem(null);

            // Return to original parent
            if (parentAfterDrag != null)
            {
                transform.SetParent(parentAfterDrag);
                transform.localPosition = Vector3.zero;
            }
        }
    }
    }
 