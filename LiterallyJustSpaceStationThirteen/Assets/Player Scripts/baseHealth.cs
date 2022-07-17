using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class baseHealth : MonoBehaviour 
{

    #region Properties
    [SerializeField] private float startingHealth = 100; 
    [SerializeField] private float healthCurrent;

    public static event Action hardIncap;
    public static event Action softIncap;
    public static event Action softIncapOff;
    public static event Action hardIncapOff;
    public static event Action playerDeath;
    public static event Action<float> legLDamage;
    public static event Action<float> legRDamage;
    public static event Action<float> eyeLDamage;
    public static event Action<float> eyeRDamage;
    public static event Action<float> armLDamage;
    public static event Action<float> armRDamage;
    public static event Action<float> headDamage;
    public static event Action<float> torsoDamage;

    #endregion

    #region Initialisation methods
        // Start is called before the first frame update
    void Start()
    {
        // Initialiase the player's current health
        resetHealth();
    }

        // Sets the player's current health back to its initial value
    private void resetHealth()
    {
        // Initialise the player's current health
        healthCurrent = startingHealth;
    }
 
    #endregion

    #region Gameplay methods

    public void Heal(int healAmount)
    {
        healthCurrent += healAmount;
        if (healthCurrent > startingHealth)
        {
            // Reset the player's current health
            resetHealth();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
        playerDeath?.Invoke();
    }

    public void TakeDamage(string bodyPart, float damageAmount, float limbDamage)
    {

        if (damageAmount <= 0)
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + damageAmount );

        switch(bodyPart)
        {
            case "legL":
                legLDamage?.Invoke(limbDamage);
                healthCurrent -= damageAmount;
                break;
            case "legR":
                healthCurrent -= damageAmount;
                legLDamage.Invoke(limbDamage);
                break;
            case "eyeL":
                healthCurrent -= damageAmount;
                eyeLDamage?.Invoke(limbDamage);
                break;
            case "eyeR":
                healthCurrent -= damageAmount;
                eyeRDamage?.Invoke(limbDamage);
                break;
            case "armL":
                healthCurrent -= damageAmount;
                armLDamage?.Invoke(limbDamage);
                break;
            case "armR":
                healthCurrent -= damageAmount;
                armRDamage?.Invoke(limbDamage);
                break;
            case "head":
                healthCurrent -= damageAmount;
                headDamage?.Invoke(limbDamage);
                break;
            case "torso":
                healthCurrent -= damageAmount;
                torsoDamage?.Invoke(limbDamage);
                break;
            default:
                print("ERROR: NONEXISTENT BODY PART");
                break;
        }

            if (healthCurrent <= 0 && healthCurrent > -50)
            {
                hardIncapOff?.Invoke();
                softIncap?.Invoke();
            }
            else if (healthCurrent <= -50 && healthCurrent > -100)
                hardIncap?.Invoke();
            else if (healthCurrent <= -100)
                Die();
        
    }

    
    #endregion

    void Update()
    {
        
        if (healthCurrent <= 0 && healthCurrent > -50)
        {
            hardIncapOff?.Invoke();
            softIncap?.Invoke();
            print ("Player is soft incapacitated!");
        }
        else if (healthCurrent <= -50 && healthCurrent > -100)
        {
           hardIncap?.Invoke();
           print ("Player is hard incapacitated!");
        }
        else if (healthCurrent <= -100)
        {
            Die();
            print("Player Died!");
        }   
        
    }
    }

