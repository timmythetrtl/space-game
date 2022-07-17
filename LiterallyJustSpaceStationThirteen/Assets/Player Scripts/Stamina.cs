using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stamina : MonoBehaviour
{
    [Header("Stamina")]
    private float maxStamina = 100;
    private float curStamina;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(curStamina < maxStamina)
        {
            curStamina += maxStamina / 200;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator DepleteStamina()
    {
        yield return new WaitForSeconds(1);
        while (curStamina > 0)
        {
            curStamina -= maxStamina / 200;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
