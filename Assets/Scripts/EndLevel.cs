using UnityEngine;
public class EndLevel : MonoBehaviour
{
    [HideInInspector] public Collider col;
    public SceneMenager sceneMenager;
    void Start()
    {
        col = this.GetComponent<Collider>();
        col.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sceneMenager.EndLevelScene();
        }
    }

}
