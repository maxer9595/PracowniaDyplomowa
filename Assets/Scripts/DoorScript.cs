using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    float maxDistancefromPlayer = 2.5f;
    float distanceFromPlayer;
    GameObject player;
    private bool opened = false;
    private Animator anim;

    void Start()
    {
        player = EqManager.instance.player;
    }

    void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position - new Vector3(0, 0, 1), player.transform.position);
        OpenAndClose();
    }

    private void OpenAndClose()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (distanceFromPlayer < maxDistancefromPlayer && this.gameObject.tag == "Door")
            {
                anim = this.transform.GetComponentInParent<Animator>();
                opened = !opened;
                anim.SetBool("Opened", opened);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position - new Vector3(0, 0, 1), maxDistancefromPlayer);
    }
}
