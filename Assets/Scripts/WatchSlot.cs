using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WatchSlot : MonoBehaviour, IDropHandler
{
    public static WatchSlot instance;
    public Slider HealthBar;
    [HideInInspector] public float sprintBoost = 1f;
    [HideInInspector] public float hungerReduction = 1f;
    [HideInInspector] public float healthValue = 1f;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        ItemInInventory itemInInventory = dropped.GetComponent<ItemInInventory>();
        ItemInInventory slotValue = this.GetComponentInChildren<ItemInInventory>();
        if (itemInInventory.item.itemType == itemType.Watch && slotValue == null)
        {
            itemInInventory.afterParent = transform;
        }
    }
    public void BoostMenager()
    {
        ItemInInventory watch = this.GetComponentInChildren<ItemInInventory>();
        SprintBooster(watch);
        HealthBooster(watch);
        HungerReducer(watch);

    }

    private void HungerReducer(ItemInInventory watch)
    {
        if (watch != null && watch.item.watchBoost == watchBoost.Hunger)
        {
            hungerReduction = (watch.item.actionValue / 100);
        }
        else
        {
            hungerReduction = 1f;
        }
    }

    private void HealthBooster(ItemInInventory watch)
    {
        if (watch != null && watch.item.watchBoost == watchBoost.Health)
        {
            HealthBar.maxValue = 100 * ((watch.item.actionValue / 100) + 1);
        }
        else
        {
            HealthBar.maxValue = 100;
        }
    }

    private void SprintBooster(ItemInInventory watch)
    {
        if (watch != null && watch.item.watchBoost == watchBoost.Speed)
        {
            sprintBoost = (watch.item.actionValue / 100) + 1;
        }
        else
        {
            sprintBoost = 1f;
        }
    }

}
