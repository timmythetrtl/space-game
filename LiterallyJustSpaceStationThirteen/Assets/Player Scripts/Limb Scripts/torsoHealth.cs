using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torsoHealth : MonoBehaviour
{
    
    [SerializeField] private float baseTorsoHealth = 100;
    [SerializeField] private float torsoHealthCurrent;

    private string torsoID = "torso";
    private bool torsoState = true;
    private bool validTarget = false;
    // Start is called before the first frame update
    void Start()
    {    
        resetHealth();
    }

    private void resetHealth()
    {
        torsoHealthCurrent = baseTorsoHealth;
    }

    private void OnEnable()
    {
        
        baseHealth.partDamage += takeTorsoDamage;
        baseHealth.partName += checkValidTarget;
    }

    private void onDisable()
    {
        baseHealth.partDamage -= takeTorsoDamage;
        baseHealth.partName -= checkValidTarget;
    }
    // Update is called once per frame

    private void checkValidTarget(string targetPart)
    {
        if (String.Equals(torsoID, targetPart))
            validTarget = true;
    }

    private void takeTorsoDamage(float torso)
    {
        
        if (validTarget == true)
        {
            torsoHealthCurrent -= torso;
            validTarget = false;
        }
            
    }
    
}