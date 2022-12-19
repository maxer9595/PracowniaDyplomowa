using UnityEngine;
using UnityEngine.UI;

public class EqManager : MonoBehaviour
{
    public static EqManager instance;
    public Slot[] slots;
    public GameObject itemPrefab;
    int focusedSlot = -1;
    public Hunger hunger;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ChangeFocusOnSlot(0);
    }
    private void Update()
    {
        SelectSlot();
        useItem();
    }

    private void SelectSlot()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int num);
            if (isNumber && num > 0 && num <= 6)
            {
                ChangeFocusOnSlot(num - 1);
            }
        }
    }


    void ChangeFocusOnSlot(int newValue)
    {
        if (focusedSlot >= 0)
        {
            slots[focusedSlot].Unfocus();
        }
        slots[newValue].Focus();
        focusedSlot = newValue;
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            ItemInInventory slotValue = slot.GetComponentInChildren<ItemInInventory>();
            if (slotValue == null)
            {
                ItemSpawner(item, slot);
                return true;
            }
        }
        return false;
    }
    void ItemSpawner(Item item, Slot slot)
    {
        GameObject newItem = Instantiate(itemPrefab, slot.transform);
        ItemInInventory itemInInventory = newItem.GetComponent<ItemInInventory>();
        itemInInventory.CreateItem(item);
    }
    public Item GetItem()
    {
        Slot slot = slots[focusedSlot];
        ItemInInventory slotValue = slot.GetComponentInChildren<ItemInInventory>();
        if (slotValue != null)
        {
            EatAndDestroy(slotValue);
            return slotValue.item;
        }
        return null;
    }

    private void EatAndDestroy(ItemInInventory slotValue)
    {
        if (slotValue.item.itemType == itemType.Food)
        {
            hunger.Eating(slotValue.item.actionValue);
            slotValue.count--;
            if (slotValue.count <= 0)
            {
                Destroy(slotValue.gameObject);
            }

        }
    }

    public void useItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetItem();
        }
    }
}

