using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneSwitch : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
 
        if (SceneManager.GetActiveScene().name == "MapScene")
            bgMusic.instance.GetComponent<AudioSource>().Pause();
            //bgMusic.instance.GetComponent<AudioSource>().Play();
 
    }
}