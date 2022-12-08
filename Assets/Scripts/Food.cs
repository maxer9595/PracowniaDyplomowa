using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Food", fileName = "food", order = 2)]
public class Food : Item
{
    [Header("Food info")]

    [SerializeField] private float hungerValue;

}
