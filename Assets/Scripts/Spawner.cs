using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject itemToSpawn;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 xd = player.transform.position;
            xd.x += 4f;
            Instantiate(itemToSpawn, xd, Quaternion.identity);
        }
    }
}
