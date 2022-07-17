using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableHardIncapacitated : MonoBehaviour
{
    private void OnEnable()
    {
        baseHealth.hardIncapOff += disableHardIncap;

    }

    private void onDisable()
    {
        baseHealth.hardIncapOff -= disableHardIncap;
    }

    private void disableHardIncap()
    {
        GetComponent<PlayerMovementTutorial>().enabled = true;
    }

}
