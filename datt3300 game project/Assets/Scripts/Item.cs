using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{

    [Header("Only gameplay")]
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = false;

    [Header("Both")]
    public Sprite image;

    [Header("General Info")]
    public string itemName;

    [Header("Item Type")]
    public string type;

    [Header("Dialogue")]
    [TextArea(2, 5)]
    public string dialogueLine;

}


