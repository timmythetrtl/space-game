using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour 
{

    #region Properties
    [SerializeField] private float health= 100; 

    public static event Action playerDeath;
    public static event Action legLDamage;
    public static event Action legRDamage;
    public static event Action eyeLDamage;
    public static event Action eyeRDamage;
    public static event Action armLDamage;
    public static event Action armRDamage;
    public static event Action headDamage;
    public static event Action torsoDamage;

    #endregion

    #region Initialisation methods
        // Start is called before the first frame update
    void Start()
    {
        // Initialiase the player's current health
        ResetHealth();
    }

        // Sets the player's current health back to its initial value
    public void ResetHealth()
    {
        // Initialise the player's current health
        healthCurrent = health;
    }

    #endregion

    #region Gameplay methods
    public void Heal(int heal_Amount)
    {
        healthCurrent += heal_Amount;
        if (healthCurrent > health)
        {
            // Reset the player's current health
            ResetHealth();
        }
    }

    public void TakeDamage(string bodyPart, float damageAmount)
    {

        if (damageAmount <= 0)
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + damageAmount );

        switch(bodyPart)
        {
            case "legL":
                legLDamage?.Invoke();
                healthCurrent -= damageAmount;
                break;
            case "legR":
                healthCurrent -= damageAmount;
                legLDamageR.Invoke();
                break;
            case "eyeL":
                healthCurrent -= damageAmount;
                eyeLDamage?.Invoke();
                break;
            case "eyeR":
                healthCurrent -= damageAmount;
                eyeRDamage?.Invoke();
                break;
            case "armL":
                healthCurrent -= damageAmount;
                armLDamage?.Invoke();
                break;
            case "armR":
                healthCurrent -= damageAmount;
                armRDamage?.Invoke();
                break;
            case "head":
                healthCurrent -= damageAmount;
                headDamage?.Invoke()
                break;
            case "torso":
                healthCurrent -= damageAmount;
                torsoDamage?.Invoke();
                break;
            default:
                print("ERROR: NONEXISTENT BODY PART");
                break;
        }
         
          
          if (health <= 0)
        {
            Die();// Kill the player
        }

    }

    private void Die()
    {
        Destroy(this.gameObject);
        playerDeath?.Invoke();
    }
    #endregion

    }

