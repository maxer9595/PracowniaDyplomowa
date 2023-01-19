using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [HideInInspector] public Collider col;
    void Start()
    {
        col = this.GetComponent<Collider>();
        col.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("EndLevelScene");
        }
    }

}
