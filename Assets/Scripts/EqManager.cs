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
    float timer = 1f;
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
        ItemController itemInHand = ItemHand.GetComponentInChildren<ItemController>();
        ItemController weaponInHand = WeaponHand.GetComponentInChildren<ItemController>();
        HandMenager(slotValue, itemInHand);
        HandMenager(slotValue, weaponInHand);

        if (slotValue != null)
        {
            AddItemToHand(slotValue);
        }

    }

    private static void HandMenager(ItemInInventory slotValue, ItemController itemInHand)
    {
        if ((slotValue == null && itemInHand != null) || (slotValue != null && itemInHand != null))
        {
            Destroy(itemInHand.gameObject);

        }
        else if (slotValue == null && itemInHand != null)
        {
            if (slotValue.item != itemInHand.item)
            {
                Destroy(itemInHand.gameObject);
            }
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
        ItemInInventory slotValue = GetSlotValue();
        if (slotValue != null)
        {
            if (slotValue.item.itemType == itemType.Health || slotValue.item.itemType == itemType.Food)
            {
                Animator animator = ItemHand.GetComponentInChildren<Animator>();
                if (Input.GetMouseButton(1))
                {
                    if (animator != null && animator.isActiveAndEnabled)
                    {
                        animator.SetBool("Use", true);
                    }
                    timer -= Time.deltaTime;
                    if (timer <= 0f)
                    {
                        UseAndDestroy(slotValue);
                        timer = 1f;
                    }
                }
                else
                {
                    timer = 1f;
                    animator.SetBool("Use", false);
                }
            }
        }
    }
}

