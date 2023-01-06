using UnityEngine;
using UnityEngine.UI;

public class EqManager : MonoBehaviour
{
    public static EqManager instance;
    public Slot[] slots;
    public GameObject itemPrefab;
    public GameObject hand;
    public GameObject newItem;
    public GameObject player;

    public int focusedSlot = -1;
    int lastSlot = -1;
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
    public void SlotMenager()
    {
        ItemInInventory slotValue = slots[focusedSlot].GetComponentInChildren<ItemInInventory>();

        if (lastSlot >= 0)
        {
            ItemInInventory LastSlotValue = slots[lastSlot].GetComponentInChildren<ItemInInventory>();
            if ((LastSlotValue != null && slotValue == null) || (LastSlotValue != null && slotValue != null) || slotValue == null)
            {
                Destroy(newItem);
            }
        }
        if (slotValue != null)
        {
            if (slotValue.item.itemType == itemType.Weapon)
            {
                newItem = Instantiate(slotValue.item.asset, hand.transform);
                newItem.tag = "EquippedWeapon";
                Collider col = newItem.GetComponent<Collider>();
                col.isTrigger = true;
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
        lastSlot = focusedSlot;
        focusedSlot = newValue;
        SlotMenager();
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            ItemInInventory slotValue = slot.GetComponentInChildren<ItemInInventory>();
            if (slotValue == null)
            {
                EqItemSpawner(item, slot);
                return true;
            }
        }
        return false;
    }
    void EqItemSpawner(Item item, Slot slot)
    {
        GameObject newItem = Instantiate(itemPrefab, slot.transform);
        ItemInInventory itemInInventory = newItem.GetComponent<ItemInInventory>();
        itemInInventory.CreateItem(item);
    }
    public ItemInInventory GetSlotValue()
    {
        Slot slot = slots[focusedSlot];
        ItemInInventory slotValue = slot.GetComponentInChildren<ItemInInventory>();
        if (slotValue != null)
        {
            return slotValue;
        }
        return null;
    }

    private void EatAndDestroy(ItemInInventory slotValue)
    {
        if (slotValue.item.itemType == itemType.Food)
        {
            HungerAndHealth.instance.Eating(slotValue.item.actionValue);
            slotValue.count--;
            if (slotValue.count <= 0)
            {
                Destroy(slotValue.gameObject);
            }

        }
    }

    public void useItem()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ItemInInventory slot = GetSlotValue();
            if (slot != null)
            {
                EatAndDestroy(slot);
            }
        }
    }
}

