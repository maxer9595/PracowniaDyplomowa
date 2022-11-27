using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hunger : MonoBehaviour
{
    public Slider HungerBar;
    float maxHunger = 100f;
    float hunger;
    bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        hunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        HungerBar.value = hunger;
        if (hunger > 0)
        {
            NewMethod();
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "floor")
        {
            isJumping = false;
        }
    }

    private void NewMethod()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            hunger -= 2f * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            hunger -= 1f;
            isJumping = true;
        }
        else
        {
            hunger -= 1f * Time.deltaTime;
        }
    }
}
