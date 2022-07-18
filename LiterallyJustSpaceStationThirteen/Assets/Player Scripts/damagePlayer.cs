using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            GetComponent<baseHealth>().TakeDamage("torso", 10);
        }
    }
}
