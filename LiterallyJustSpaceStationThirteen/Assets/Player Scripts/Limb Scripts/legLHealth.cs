using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legLHealth : MonoBehaviour
{
    
    [SerializeField] private float baseLegLHealth = 100;
    private float legLHealthCurrent;
    private bool legLState = true;
    // Start is called before the first frame update
    void Start()
    {    
        resetHealth();
    }

    private void resetHealth()
    {
        // Initialise the player's limb current health
        legLHealthCurrent = baseLegLHealth;
    }

    private void OnEnable()
    {
        baseHealth.legLDamage += takeLLegDamage;
    }

    private void onDisable()
    {
        baseHealth.legLDamage -= takeLLegDamage;
    }
    // Update is called once per frame

    public void takeLLegDamage(float legL)
    {
        if (legL <= 0)
            return;
        legLHealthCurrent -= legL;
    }

}
