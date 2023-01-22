using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SuitSlot : MonoBehaviour, IDropHandler
{
    public float SuitValue()
    {
        ItemInInventory suitSlotlotValue = this.GetComponentInChildren<ItemInInventory>();
        if (suitSlotlotValue != null)
        {
            Item item = suitSlotlotValue.item;
            return item.actionValue;
        }
        else
        {
            return 0f;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        ItemInInventory itemInInventory = dropped.GetComponent<ItemInInventory>();
        ItemInInventory slotValue = this.GetComponentInChildren<ItemInInventory>();
        if (itemInInventory.item.itemType == itemType.Suit && slotValue == null)
        {
            itemInInventory.afterParent = transform;
        }
    }
}