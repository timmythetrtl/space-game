using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    baseHealth Player;

    void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<baseHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Player.healthCurrent;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
