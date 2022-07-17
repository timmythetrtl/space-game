using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armLHealth : MonoBehaviour
{
    [SerializeField] private float baseArmLHealth = 100;
    private float armLHealthCurrent;
    private bool armLState = true;
    // Start is called before the first frame update
    void Start()
    {    
        resetHealth();
    }

    private void resetHealth()
    {
        // Initialise the player's limb current health
        armLHealthCurrent = baseArmLHealth;
    }

    private void OnEnable()
    {
        baseHealth.armLDamage += takeLArmDamage;
    }

    private void onDisable()
    {
        baseHealth.armLDamage -= takeLArmDamage;
    }
    // Update is called once per frame

    public void takeLArmDamage(float armL)
    {
        armLHealthCurrent -= armL;
    }
}
