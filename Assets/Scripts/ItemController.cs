using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour
{
    public Item item;
    GameObject player;
    [SerializeField] float animationSpeed = 0.3f;
    bool labelDraw = false;
    GUIStyle style = new GUIStyle();
    string labeltext = "Press 'E' to pickUp";

    float distanceFromPlayer;
    bool showLabel;
    private void Start()
    {
        Collider col = this.GetComponent<Collider>();
        col.enabled = false;
        player = EqManager.instance.player;

    }
    private void Update()
    {
        PlayerMovment playerMovment = player.GetComponent<PlayerMovment>();
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (!playerMovment.isEqVisible)
        {
            AttackContrroller();
        }

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
        if (distanceFromPlayer < item.range && this.gameObject.tag != "EquippedWeapon" && this.gameObject.tag != "EquippedItem")
        {
            labelDraw = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                ItemInInventory slotValue = EqManager.instance.GetSlotValue();
                if (slotValue == null)
                {
                    bool isAdded = EqManager.instance.AddItem(item);
                    if (isAdded) { Collect(); }
                    else { labeltext = "Inventory is Full"; }
                    EqManager.instance.SlotMenager();
                }
                else
                {
                    bool isAdded = EqManager.instance.AddItem(item);
                    if (isAdded) { Collect(); }
                    else { labeltext = "Inventory is Full"; }
                }
            }
        }
        else
        {
            labelDraw = false;
            labeltext = "Press 'E' to pickUp";
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
    void OnGUI()
    {
        style.fontSize = 40;
        if (labelDraw)
        {
            GUI.Label(new Rect(50, Screen.height / 2, 500, 500), labeltext, style);
        }
    }
}
