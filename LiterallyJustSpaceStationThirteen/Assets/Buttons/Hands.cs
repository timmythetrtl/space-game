using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    private Renderer renderer;
    private bool color=false;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        FindObjectOfType<Pickup>().hand = !FindObjectOfType<Pickup>().hand;
        print("Success!");

        color = !color;

        if (color)
        {
            renderer.material.color = new Color(0f, 1f, 0f, 1f);
        }
        else
        {
            renderer.material.color = new Color(1f, 0f, 0f, 1f);
        }

    }
}
