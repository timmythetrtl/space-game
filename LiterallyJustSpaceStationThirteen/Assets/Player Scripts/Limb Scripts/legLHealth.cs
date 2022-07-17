using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legLHealth : MonoBehaviour
{
    
    [SerializeField] private float baseLegLHealth = 100;
    [SerializeField] private float legLHealthCurrent;

    private string legLID = "LegL";
    private bool legLState = true;
    private bool validTarget = false;
    // Start is called before the first frame update
    void Start()
    {    
        resetHealth();
    }

    private void resetHealth()
    {
        legLHealthCurrent = baseLegLHealth;
    }

    private void OnEnable()
    {
        
        baseHealth.partDamage += takeLLegDamage;
        baseHealth.partName += checkValidTarget;
    }

    private void onDisable()
    {
        baseHealth.partDamage -= takeLLegDamage;
    }
    // Update is called once per frame

    private void checkValidTarget(string targetPart)
    {
        if (String.Equals(legLID, targetPart))
            validTarget = true;
    }

    private void takeLLegDamage(float legL)
    {
        
        if (validTarget == true)
        {
            legLHealthCurrent -= legL;
            validTarget = false;
        }
            
    }
    
}