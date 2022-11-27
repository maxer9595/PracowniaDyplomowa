using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hunger : MonoBehaviour
{
    public Slider HungerBar;
    public Slider HealthBar;

    [SerializeField] float hungerSpeed = 1f;
    [SerializeField] float hungerSprintSpeed = 2f;
    [SerializeField] float hungerJumpSpeed = 1f;
    [SerializeField] float hungerDamage = 1f;

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
        if (hunger <= 0)
        {
            HealthBar.value -= hungerDamage * Time.deltaTime;
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
            hunger -= hungerSprintSpeed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            hunger -= hungerJumpSpeed;
            isJumping = true;
        }
        else
        {
            hunger -= hungerSpeed * Time.deltaTime;
        }
    }
}
