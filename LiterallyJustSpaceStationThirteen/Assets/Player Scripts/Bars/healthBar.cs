using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    private Image HealthBar;
    public float currentHealthBar
    {
        get {return _currentHealthBar;}
        set {_currentHealthBar = Mathf.Clamp(value, -100, 100);}
    }
    [SerializeField, Range(-100, 100)] private float _currentHealthBar;
    private float MaxHealth = 100f;

    void Start()
    {
        HealthBar = GetComponent<Image>();
    }

    void onEnable()
    {
        baseHealth.healthPctDamage += lowerHealthBar;
        baseHealth.healthPctHeal += raiseHealthBar;
    } 

    void onDisable()
    {
        baseHealth.healthPctDamage -= lowerHealthBar;
        baseHealth.healthPctHeal += raiseHealthBar;
    }

    private void lowerHealthBar(float low)
    {
        HealthBar.fillAmount = currentHealthBar - low;
    }

    private void raiseHealthBar(float raise)
    {
        HealthBar.fillAmount = currentHealthBar + raise;
    }

}
