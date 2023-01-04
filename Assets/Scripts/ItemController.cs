using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    private void Update()
    {
        AttackContrroller();
    }

    private void AttackContrroller()
    {
        if (this.gameObject.tag == "EquippedWeapon" && Input.GetMouseButtonDown(0))
        {
            Animator animator = this.GetComponent<Animator>();
            animator.SetTrigger("Attack");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag != "EquippedWeapon")
        {
            ItemInInventory slotValue = EqManager.instance.slots[EqManager.instance.focusedSlot].GetComponentInChildren<ItemInInventory>();
            if (slotValue == null)
            {
                bool isAdded = EqManager.instance.AddItem(item);
                if (isAdded) { Collect(); }
                EqManager.instance.SlotMenager();
            }
            else
            {
                bool isAdded = EqManager.instance.AddItem(item);
                if (isAdded) { Collect(); }
            }


        }
    }
    private void Collect()
    {
        Destroy(gameObject);
    }
}
