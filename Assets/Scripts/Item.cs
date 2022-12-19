using UnityEngine;
[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    [Header("General info")]

    [SerializeField] public string itemName;
    [SerializeField] public Sprite icon;
    public itemType itemType;
    [SerializeField] public float actionValue;
    public Vector3Int range = new Vector3Int(1, 1, 1);
    // public bool 
}

public enum itemType
{
    Weapon,
    Food
}