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
        float itemY = itemToSpawn.transform.position.y;
        spawnPosition.y = spawnPosition.y - player.transform.lossyScale.y + itemY;
        Instantiate(itemToSpawn, spawnPosition, Quaternion.Euler(-90, 0, 0));
    }

}
