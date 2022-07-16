using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour 
{

    #region Properties
    [SerializeField] public float legL_health= 100;
    [SerializeField] public float legR_health= 100;
    [SerializeField] public float eyeL_health= 100;
    [SerializeField] public float eyeR_health= 100;
    [SerializeField] public float armL_health= 100;
    [SerializeField] public float armR_health= 100;
    [SerializeField] public float head_health= 100;
    [SerializeField] public float torso_health= 100;
    [SerializeField] private float health= 100; 
    private float health_Current;

    public static event Action playerDeath;

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
        health_Current = health;
    }

    #endregion

    #region Gameplay methods
    public void Heal(int heal_Amount)
    {
        health_Current += heal_Amount;
        if (health_Current > health)
        {
            // Reset the player's current health
            ResetHealth();
        }
    }

    public void TakeDamage(string bodyPart, float damage_Amount)
    {
        switch(bodyPart){
            case "legL":
                health_Current -= damage_Amount;
                break;
            case "legR":
                health_Current -= damage_Amount;
                break;
            case "eyeL":
                health_Current -= damage_Amount;
                break;
            case "eyeR":
                health_Current -= damage_Amount;
                break;
            case "armL":
                health_Current -= damage_Amount;
                break;
            case "armR":
                health_Current -= damage_Amount;
                break;
            case "head":
                health_Current -= damage_Amount;
                break;
            case "torso":
                health_Current -= damage_Amount;
                break;
            default:
                print("ERROR: NONEXISTENT BODY PART");
                break;
        }
         
          
          if (health <= 0)
        {
            // Kill the player
            Destroy(this.gameObject);
            playerDeath?.Invoke();

        }
    }
    #endregion

    }

