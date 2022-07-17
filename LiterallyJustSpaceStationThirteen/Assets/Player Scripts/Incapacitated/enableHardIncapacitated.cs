using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableHardIncapacitated : MonoBehaviour
{
    private void OnEnable()
    {
        baseHealth.hardIncap += enableHardIncap;
    }

    private void onDisable()
    {
        baseHealth.hardIncap -= enableHardIncap;
    }

    private void enableHardIncap()
    {
        GetComponent<PlayerMovementTutorial>().enabled = false;
    }

}
