using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] public SphereCollider itemCollider;
    [SerializeField] public float movespeed;

    public Item item;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            bool isAdded = EqManager.instance.AddItem(item);
            if (isAdded) { Collect(); }
            Debug.Log(other.gameObject.tag);

        }
    }
    private void Collect()
    {
        Destroy(itemCollider);
        Destroy(gameObject);
        Debug.Log("Collected");
    }
}
