using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class baseHealth : MonoBehaviour 
{

    #region Properties
    [SerializeField] public float startingHealth = 100; 
    [SerializeField] public float healthCurrent;

    public static event Action<float> healthPctDamage;
    public static event Action<float> healthPctHeal;
    public static event Action hardIncap;
    public static event Action softIncap;
    public static event Action softIncapOff;
    public static event Action hardIncapOff;
    public static event Action playerDeath;
    public static event Action<float> partDamage;
    public static event Action<string> partName;


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
        healthPctHeal?.Invoke(healAmount);
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

    public void takeDamage(string bodyPart, float damageAmount)
    {
        partName?.Invoke(bodyPart);

        if (damageAmount < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + damageAmount );
        }
        else
        {
            healthCurrent -= damageAmount;
            partDamage?.Invoke(damageAmount);
            healthPctDamage?.Invoke(damageAmount);
            print("Damaged Player");
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
        //This code is for testing
        /*
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
        */
    }
}

