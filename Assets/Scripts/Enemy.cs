using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float enemyHealth = 30f;
    [SerializeField] public float enemyStrength = 10f;
    [SerializeField] public float enemyRadius = 10f;
    [SerializeField] public float enemyAtackRange = 4.5f;
    [SerializeField] public float enemyMoveSpeed = 5f;
    [SerializeField] public float enemyAtackSpeed = 2f;
    public GameObject player;
    public Rigidbody rb;
    float distanceFromPlayer;
    float timer = 0.1f;
    public GameObject enemyObject;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemyRadius);
    }

    void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        DetectAndFollow(distanceFromPlayer);
        Atack();
        if (Input.GetKeyDown(KeyCode.P))
        {
            KillEnemy();
        }
    }

    private void Atack()
    {
        if (distanceFromPlayer < enemyAtackRange)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                HungerAndHealth.instance.GetDamage(enemyStrength);
                timer = enemyAtackSpeed;
            }
        }
        // else
        // {
        //     timer = enemyAtackSpeed;
        // }
    }

    private void DetectAndFollow(float distanceFromPlayer)
    {

        if ((distanceFromPlayer < enemyRadius || this.gameObject.tag == "Triggered") && distanceFromPlayer > enemyAtackRange - 1f)
        {
            this.gameObject.tag = "Triggered";
            Vector3 playerDirection = player.transform.position - transform.position;
            rb.velocity = playerDirection.normalized * enemyMoveSpeed;
            transform.LookAt(player.transform.position);

        }
    }
    private void KillEnemy()
    {
        Destroy(enemyObject);
    }
}
