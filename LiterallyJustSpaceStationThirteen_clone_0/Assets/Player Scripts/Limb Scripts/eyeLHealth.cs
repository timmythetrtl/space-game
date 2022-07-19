using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeLHealth : MonoBehaviour
{
    
    [SerializeField] private float baseEyeLHealth = 100;
    [SerializeField] private float eyeLHealthCurrent;

    private string eyeLID = "EyeL";
    private bool eyeLState = true;
    private bool validTarget = false;
    // Start is called before the first frame update
    void Start()
    {    
        resetHealth();
    }

    private void resetHealth()
    {
        eyeLHealthCurrent = baseEyeLHealth;
    }

    private void OnEnable()
    {
        
        baseHealth.partDamage += takeLEyeDamage;
        baseHealth.partName += checkValidTarget;
    }

    private void onDisable()
    {
        baseHealth.partDamage -= takeLEyeDamage;
    }
    // Update is called once per frame

    private void checkValidTarget(string targetPart)
    {
        if (String.Equals(eyeLID, targetPart))
            validTarget = true;
    }

    private void takeLEyeDamage(float eyeL)
    {
        
        if (validTarget == true)
        {
            eyeLHealthCurrent -= eyeL;
            validTarget = false;
        }
            
    }
    
}