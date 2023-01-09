using UnityEngine;
[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    [Header("General info")]
    [SerializeField] public Sprite icon;
    public itemType itemType;
    [SerializeField] public float actionValue;
    public float range = 1.5f;
    public GameObject asset;
}

public enum itemType
{
    Weapon,
    Food,
    Watch,
    Suit,
    Health
}