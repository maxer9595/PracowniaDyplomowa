using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemInInventory : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image itemImage;
    public Item item;
    [HideInInspector] public Transform afterParent;
    [HideInInspector] public int count = 1;


    public void CreateItem(Item newItem)
    {
        item = newItem;
        itemImage.sprite = newItem.icon;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        afterParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        itemImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(afterParent);
        itemImage.raycastTarget = true;
    }
    public Item pushItem()
    {
        return item;
    }

}
