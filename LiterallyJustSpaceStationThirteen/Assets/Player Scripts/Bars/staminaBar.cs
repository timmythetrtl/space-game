using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar : MonoBehaviour
{
    private Image StaminaBar;
    public float CurrentStamina;
    private float MaxStamina = 100f;
    PlayerMovementTutorial Player;

    void Start()
    {
        StaminaBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerMovementTutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentStamina = Player.curStamina;
        StaminaBar.fillAmount = CurrentStamina / MaxStamina;
    }
}
