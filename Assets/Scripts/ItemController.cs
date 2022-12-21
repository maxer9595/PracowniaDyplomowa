using UnityEngine;

public class ItemController : MonoBehaviour
{
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
        Destroy(gameObject);
        Debug.Log("Collected");
    }
}
