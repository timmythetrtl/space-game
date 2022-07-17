using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headHealth : MonoBehaviour
{
    
    [SerializeField] private float baseHeadHealth = 100;
    [SerializeField] private float headHealthCurrent;

    private string headID = "Head";
    private bool headState = true;
    private bool validTarget = false;
    // Start is called before the first frame update
    void Start()
    {    
        resetHealth();
    }

    private void resetHealth()
    {
        headHealthCurrent = baseHeadHealth;
    }

    private void OnEnable()
    {
        
        baseHealth.partDamage += takeHeadDamage;
        baseHealth.partName += checkValidTarget;
    }

    private void onDisable()
    {
        baseHealth.partDamage -= takeHeadDamage;
    }
    // Update is called once per frame

    private void checkValidTarget(string targetPart)
    {
        if (String.Equals(headID, targetPart))
            validTarget = true;
    }

    private void takeHeadDamage(float head)
    {
        
        if (validTarget == true)
        {
            headHealthCurrent -= head;
            validTarget = false;
        }
            
    }
    
}