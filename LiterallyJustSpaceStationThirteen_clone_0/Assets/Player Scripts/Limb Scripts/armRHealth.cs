using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armRHealth : MonoBehaviour
{
    
    [SerializeField] private float baseArmRHealth = 100;
    [SerializeField] private float armRHealthCurrent;

    private string armRID = "ArmR";
    private bool armRState = true;
    private bool validTarget = false;
    // Start is called before the first frame update
    void Start()
    {    
        resetHealth();
    }

    private void resetHealth()
    {
        armRHealthCurrent = baseArmRHealth;
    }

    private void OnEnable()
    {
        
        baseHealth.partDamage += takeRArmDamage;
        baseHealth.partName += checkValidTarget;
    }

    private void onDisable()
    {
        baseHealth.partDamage -= takeRArmDamage;
    }
    // Update is called once per frame

    private void checkValidTarget(string targetPart)
    {
        if (String.Equals(armRID, targetPart))
            validTarget = true;
    }

    private void takeRArmDamage(float armR)
    {
        
        if (validTarget == true)
        {
            armRHealthCurrent -= armR;
            validTarget = false;
        }
            
    }
    
}