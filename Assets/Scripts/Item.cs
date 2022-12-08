using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [Header("General info")]

    [SerializeField] private string itemName;
    [SerializeField] private Sprite icon;
}
