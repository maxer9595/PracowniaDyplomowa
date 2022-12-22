using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color focused, unfocused;

    private void Awake()
    {
        Unfocus();
    }
    public void Focus()
    {
        image.color = focused;
    }
    public void Unfocus()
    {
        image.color = unfocused;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            ItemInInventory itemInInventory = dropped.GetComponent<ItemInInventory>();
            itemInInventory.afterParent = transform;
        }
    }

}
