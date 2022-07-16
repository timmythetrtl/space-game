using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeg : MonoBehaviour
{
    private Renderer renderer;
    private bool color=false;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        
        print("Success!");

        color = !color;

        if (color)
        {
            renderer.material.color = new Color(0f, 1f, 0f, 1f);
            FindObjectOfType<Legs>().legR = 3;
        }
        else
        {
            renderer.material.color = new Color(1f, 0f, 0f, 1f);
            FindObjectOfType<Legs>().legR = 0;
        }

    }
}
