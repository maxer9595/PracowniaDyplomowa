using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour
{
    public Item item;
    [SerializeField] float animationSpeed = 0.3f;
    public bool isAttacking = false;
    private void Start()
    {
        Collider col = this.GetComponent<Collider>();
    }
    private void Update()
    {
        Collider col = this.GetComponent<Collider>();
        AttackContrroller();
        if (this.gameObject.tag == "EquippedWeapon")
        {

        }
    }

    private void AttackContrroller()
    {
        if (this.gameObject.tag == "EquippedWeapon" && Input.GetMouseButtonDown(0))
        {
            Collider col = this.GetComponent<Collider>();
            Animator animator = this.GetComponent<Animator>();
            animator.SetTrigger("Attack");
            animator.SetFloat("Speed", animationSpeed);
            StartCoroutine(ResetAttack());
            col.enabled = true;
        }
    }
    IEnumerator ResetAttack()
    {
        Collider col = this.GetComponent<Collider>();
        yield return new WaitForSeconds(animationSpeed);
        col.enabled = false;
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
