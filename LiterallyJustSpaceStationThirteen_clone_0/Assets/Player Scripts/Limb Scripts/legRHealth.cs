using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legRHealth : MonoBehaviour
{
    
    [SerializeField] private float baseLegRHealth = 100;
    [SerializeField] private float legRHealthCurrent;

    private string legRID = "LegR";
    private bool legRState = true;
    private bool validTarget = false;
    // Start is called before the first frame update
    void Start()
    {    
        resetHealth();
    }

    private void resetHealth()
    {
        legRHealthCurrent = baseLegRHealth;
    }

    private void OnEnable()
    {
        
        baseHealth.partDamage += takeRLegDamage;
        baseHealth.partName += checkValidTarget;
    }

    private void onDisable()
    {
        baseHealth.partDamage -= takeRLegDamage;
    }
    // Update is called once per frame

    private void checkValidTarget(string targetPart)
    {
        if (String.Equals(legRID, targetPart))
            validTarget = true;
    }

    private void takeRLegDamage(float legR)
    {
        
        if (validTarget == true)
        {
            legRHealthCurrent -= legR;
            validTarget = false;
        }
            
    }
    
}