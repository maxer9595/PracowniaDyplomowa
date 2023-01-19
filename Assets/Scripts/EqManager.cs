using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EqManager : MonoBehaviour
{
    public static EqManager instance;
    public Slot[] slots;
    public GameObject itemPrefab;
    public GameObject WeaponHand;
    public GameObject ItemHand;
    [HideInInspector] public GameObject newItem;
    public GameObject player;
    public int focusedSlot = -1;
    float timer = 1.5f;
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
        ItemInInventory slotValue = GetSlotValue();
        ItemController itemController = ItemHand.GetComponentInChildren<ItemController>();
        if ((slotValue == null && itemController != null) || (slotValue != null && itemController != null))
        {
            Destroy(itemController.gameObject);

        }
        else if (slotValue == null && itemController != null)
        {
            if (slotValue.item != itemController.item)
            {
                Destroy(itemController.gameObject);
            }
        }

        if (slotValue != null)
        {
            AddItemToHand(slotValue);
        }

    }

    private void AddItemToHand(ItemInInventory slotValue)
    {
        if (slotValue.item.itemType == itemType.Weapon)
        {
            newItem = Instantiate(slotValue.item.asset, WeaponHand.transform);
            newItem.tag = "EquippedWeapon";
            Collider col = newItem.GetComponent<Collider>();
            col.isTrigger = true;
            newItem.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
        }
        else
        {
            newItem = Instantiate(slotValue.item.asset, ItemHand.transform);
            newItem.tag = "EquippedItem";
            newItem.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
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
        ItemInInventory slotValue = slots[focusedSlot].GetComponentInChildren<ItemInInventory>();
        return slotValue;
    }

    private void UseAndDestroy(ItemInInventory slotValue)
    {
        if (slotValue.item.itemType == itemType.Food)
        {
            HungerAndHealth.instance.Eating(slotValue.item.actionValue);
            Destroy(slotValue.gameObject);
            Destroy(newItem);
        }
        else if (slotValue.item.itemType == itemType.Health)
        {
            HungerAndHealth.instance.Healing(slotValue.item.actionValue);
            Destroy(slotValue.gameObject);
            Destroy(newItem);
        }

    }

    public void useItem()
    {
        if (Input.GetMouseButton(1))
        {
            ItemInInventory slot = GetSlotValue();
            if (slot != null)
            {
                timer -= Time.deltaTime;
                if (timer <= 0f)
                {
                    UseAndDestroy(slot);
                    timer = 1.5f;
                }
                Debug.Log(timer);

            }
        }
    }
}

