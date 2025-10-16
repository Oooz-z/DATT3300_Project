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
        //Debug.Log("End drag");
        SetRaycasts(true);
        transform.SetParent(parentAfterDrag);
        transform.localPosition = Vector3.zero;


    }

}
 