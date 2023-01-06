using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour
{
    public Item item;
    GameObject player;
    [SerializeField] float animationSpeed = 0.3f;
    public bool isAttacking = false;
    float distanceFromPlayer;
    private void Start()
    {
        Collider col = this.GetComponent<Collider>();
        col.enabled = false;
        player = EqManager.instance.player;
    }
    private void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        AttackContrroller();
        DetectItem(distanceFromPlayer);
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
    private void DetectItem(float distanceFromPlayer)
    {

        if (distanceFromPlayer < item.range && this.gameObject.tag != "EquippedWeapon")
        {
            if (Input.GetKeyDown(KeyCode.E))
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
    }
    private void Collect()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, item.range);
    }
}
