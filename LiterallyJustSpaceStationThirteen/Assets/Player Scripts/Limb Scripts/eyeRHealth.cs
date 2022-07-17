using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeRHealth : MonoBehaviour
{
    
    [SerializeField] private float baseEyeRHealth = 100;
    [SerializeField] private float eyeRHealthCurrent;

    private string eyeRID = "EyeR";
    private bool eyeRState = true;
    private bool validTarget = false;
    // Start is called before the first frame update
    void Start()
    {    
        resetHealth();
    }

    private void resetHealth()
    {
        eyeRHealthCurrent = baseEyeRHealth;
    }

    private void OnEnable()
    {
        
        baseHealth.partDamage += takeREyeDamage;
        baseHealth.partName += checkValidTarget;
    }

    private void onDisable()
    {
        baseHealth.partDamage -= takeREyeDamage;
    }
    // Update is called once per frame

    private void checkValidTarget(string targetPart)
    {
        if (String.Equals(eyeRID, targetPart))
            validTarget = true;
    }

    private void takeREyeDamage(float eyeR)
    {
        
        if (validTarget == true)
        {
            eyeRHealthCurrent -= eyeR;
            validTarget = false;
        }
            
    }
    
}