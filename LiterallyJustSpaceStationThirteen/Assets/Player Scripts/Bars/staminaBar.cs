using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar : MonoBehaviour
{
    private Image StaminaBar;
    public float CurrentStamina;
    private float MaxStamina = 100f;
    Stamina stamina;

    void Start()
    {
        StaminaBar = GetComponent<Image>();
        stamina = FindObjectOfType<Stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentStamina = stamina.staminaCurrent;
        StaminaBar.fillAmount = CurrentStamina / MaxStamina;
    }
}
