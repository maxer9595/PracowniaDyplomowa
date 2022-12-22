using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WatchSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        ItemInInventory itemInInventory = dropped.GetComponent<ItemInInventory>();
        if (itemInInventory.item.itemType == itemType.Watch)
        {
            itemInInventory.afterParent = transform;
        }
    }
}
