using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armLHealth : MonoBehaviour
{
    
    [SerializeField] private float baseArmLHealth = 100;
    [SerializeField] private float armLHealthCurrent;

    private string armLID = "ArmL";
    private bool armLState = true;
    private bool validTarget = false;
    // Start is called before the first frame update
    void Start()
    {    
        resetHealth();
    }

    private void resetHealth()
    {
        armLHealthCurrent = baseArmLHealth;
    }

    private void OnEnable()
    {
        
        baseHealth.partDamage += takeLArmDamage;
        baseHealth.partName += checkValidTarget;
    }

    private void onDisable()
    {
        baseHealth.partDamage -= takeLArmDamage;
    }
    // Update is called once per frame

    private void checkValidTarget(string targetPart)
    {
        if (String.Equals(armLID, targetPart))
            validTarget = true;
    }

    private void takeLArmDamage(float armL)
    {
        
        if (validTarget == true)
        {
            armLHealthCurrent -= armL;
            validTarget = false;
        }
            
    }
    
}