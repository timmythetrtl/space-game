using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField] public float startingStamina = 100;
    [SerializeField] public float staminaCurrent;

    public static event Action zeroStamina;

    private bool running = false;
    private bool regaining = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialiase the player's current health
        resetStamina();
    }

    // Sets the player's current health back to its initial value
    private void resetStamina()
    {
        // Initialise the player's current health
        staminaCurrent = startingStamina;
    }

    void Update()
    {

    }

    private void OnEnable()
    {
        PlayerMovementTutorial.sprinting += StaminaHandler;
        PlayerMovementTutorial.notSprinting += RegenHandler;
    }

    private void onDisable()
    {
        PlayerMovementTutorial.sprinting -= StaminaHandler;
        PlayerMovementTutorial.notSprinting -= RegenHandler;
    }

    private void StaminaHandler()
    {
        if (running==false)
        {
            StartCoroutine(DepleteStamina());
        }
        //else if(regaining==false && running == false)
        //{
        //   StartCoroutine(RegainStamina());
        //}

        //Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && 
    }

    private void RegenHandler()
    {
        running = false;
        if (!regaining)
        {
            StartCoroutine(RegainStamina());
        }
    }

    private IEnumerator DepleteStamina()
    {
        running = true;
        while (staminaCurrent > 0 && running)
        {
            staminaCurrent -= startingStamina / 25;
            yield return new WaitForSeconds(0.1f);
        }
        zeroStamina?.Invoke();
        running = false;
    }

    private IEnumerator RegainStamina()
    {
        regaining = true;
        yield return new WaitForSeconds(1);
        while (!running && staminaCurrent <= 100)
        {
            staminaCurrent += startingStamina / 25;
            yield return new WaitForSeconds(0.1f);
        }
        regaining = false;
    }
}
