using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }
    public void SpawnItemOnMap(GameObject itemToSpawn)
    {
        Vector3 spawnPosition = player.transform.position;
        spawnPosition.x += 4f;
        Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);
    }

}
