using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseHealth : MonoBehaviour 
{

    #region Properties
    [SerializeField] private float health= 100; 
    private float healthCurrent;

    public static event Action playerDeath;
    public static event Action<float> legLDamage;
    public static event Action<float> legRDamage;
    public static event Action<float> eyeLDamage;
    public static event Action<float> eyeRDamage;
    public static event Action<float> armLDamage;
    public static event Action<float> armRDamage;
    public static event Action<float> headDamage;
    public static event Action<float> torsoDamage;

    void Start()
    {
        mustUpdate = false;
    }

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
            resetHealth();
        }
    }

    public void TakeDamage(string bodyPart, string damageType, int armorClass, float damageAmount, float limbDamage)
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
         
          
          if (health <= -400)
        {
            Die();// Kill the player
        }

    }

    public void Die()
    {
        Destroy(this.gameObject);
        playerDeath?.Invoke();
    }
    #endregion

    void Update()
    {
        if (healthCurrent <= -100 and >= -199)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
                if (randomNumber <= 25)
                    Die();
        }
    }

}

