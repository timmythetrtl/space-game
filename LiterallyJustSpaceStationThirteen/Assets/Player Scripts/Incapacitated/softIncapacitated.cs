using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class softIncapacitated : MonoBehaviour
{

 private void OnEnable()
    {
        
        baseHealth.softIncap += enableSoftIncap;

    }

    private void onDisable()
    {
        baseHealth.softIncap -= enableSoftIncap;
    }
    // Update is called once per frame

    private void enableSoftIncap()
    {
        
    }
    
}
