using UnityEngine;
[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    [Header("General info")]
    [SerializeField] public Sprite icon;
    [SerializeField] public float actionValue;
    public float range = 1.5f;
    public GameObject asset;
    public itemType itemType;
    public watchBoost watchBoost;
}

public enum itemType
{
    Weapon,
    Food,
    Watch,
    Suit,
    Health
}
public enum watchBoost
{
    None,
    Speed,
    Health,
    Hunger
}