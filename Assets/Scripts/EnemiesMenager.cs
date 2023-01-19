using UnityEngine;

public class EnemiesMenager : MonoBehaviour
{
    public GameObject wall;
    public EndLevel endingWall;
    Enemy[] enemies;

    void Update()
    {
        enemies = this.GetComponentsInChildren<Enemy>();
        if (enemies.Length <= 0)
        {
            Destroy(wall);
            endingWall.col.enabled = true;
        }
    }
}
