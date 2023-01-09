using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Watch")]
public class Watch : Item
{

    [Header("Watch Booster")]
    public watchBoost watchBoost;
    private void Awake()
    {
        itemType = itemType.Watch;
    }

}
public enum watchBoost
{
    Speed,
    Health,
    Hunger,
    Jump
}
