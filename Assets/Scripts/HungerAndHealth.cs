using UnityEngine;
using UnityEngine.UI;


public class HungerAndHealth : MonoBehaviour
{
    public SceneMenager sceneMenager;
    public static HungerAndHealth instance;
    public Slider HungerBar;
    public Slider HealthBar;
    public SuitSlot suitSlot;
    public WatchSlot watchslot;
    public float hungerSpeed = 1f;
    public float hungerSprintSpeed = 2f;
    public float hungerJumpSpeed = 1f;
    [SerializeField] float hungerDamage = 1f;
    public float maxHealth = 100f;
    float maxHunger = 100f;
    float hunger;
    bool isJumping;
    float damageReduction;
    float newDamage;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        hunger = maxHunger;
        HungerBar.maxValue = maxHunger;

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
            hunger -= hungerSprintSpeed * Time.deltaTime * watchslot.hungerReduction;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            hunger -= hungerJumpSpeed * watchslot.hungerReduction;
            isJumping = true;
        }
        else
        {
            hunger -= hungerSpeed * Time.deltaTime * watchslot.hungerReduction;
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
        if (HealthBar.value > HealthBar.maxValue)
        {
            HealthBar.value = HealthBar.maxValue;
        }
    }

    public void GetDamage(float damage)
    {
        if (damageReduction != 0)
        {
            newDamage = damage - ((damage / 100) * damageReduction);
        }
        else
        {
            newDamage = damage;
        }
        HealthBar.value -= newDamage;
    }
    public void Death()
    {
        if (HealthBar.value <= 0)
        {
            sceneMenager.DeathScreen();
        }
    }
}
