using UnityEngine;

public class EnemiesMenager : MonoBehaviour
{
    public GameObject EndGameDoors;
    public EndLevel endingWall;
    Enemy[] enemies;

    void Update()
    {
        enemies = this.GetComponentsInChildren<Enemy>();
        if (enemies.Length <= 0)
        {
            Destroy(EndGameDoors);
            endingWall.col.enabled = true;
        }
    }
}
