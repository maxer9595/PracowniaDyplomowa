using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HungerAndHealth : MonoBehaviour
{
    public static HungerAndHealth instance;
    public Slider HungerBar;
    public Slider HealthBar;
    public SuitSlot suitSlot;

    [SerializeField] float hungerSpeed = 1f;
    [SerializeField] float hungerSprintSpeed = 2f;
    [SerializeField] float hungerJumpSpeed = 1f;
    [SerializeField] float hungerDamage = 1f;
    float maxHealth = 100f;
    float maxHunger = 100f;
    float hunger;
    bool isJumping;
    float damageReduction;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        hunger = maxHunger;
        HealthBar.value = maxHealth;
    }

    void Update()
    {
        HungerBar.value = hunger;
        if (hunger > 0)
        {
            UpdateHunger();
        }
        if (hunger <= 0)
        {
            HealthBar.value -= hungerDamage * Time.deltaTime;
        }
        damageReduction = suitSlot.SuitValue();
        Death();

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "floor")
        {
            isJumping = false;
        }
    }

    private void UpdateHunger()
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
    public void Eating(float value)
    {
        hunger += value;
        if (hunger > maxHunger)
        {
            hunger = maxHunger;
        }
    }

    public void Healing(float value)
    {
        HealthBar.value += value;
        if (HealthBar.value > maxHealth)
        {
            HealthBar.value = maxHealth;
        }
    }

    public void GetDamage(float damage)
    {
        if (damageReduction != 0)
        {
            damage -= (damage / 100) * damageReduction;
        }
        HealthBar.value -= damage;
    }
    public void Death()
    {
        if (HealthBar.value <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
