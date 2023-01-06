using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropFromInventory : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        ItemInInventory itemInInventory = dropped.GetComponent<ItemInInventory>();
        Spawner.instance.SpawnItemOnMap(itemInInventory.pushItem().asset);
        Destroy(dropped);
        EqManager.instance.SlotMenager();
    }
}
