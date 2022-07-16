using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    private Renderer renderer;
    private bool color = false;
    public Camera cam;
    private int destroyedNum = 0;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {

        //FindObjectOfType<Blinder>().eyes = !FindObjectOfType<Blinder>().eyes;
        print("Success!");

        color = !color;

        if (color)
        {
            renderer.material.color = new Color(0f, 1f, 0f, 1f);
            destroyedNum++;
            
        }
        else
        {
            renderer.material.color = new Color(1f, 0f, 0f, 1f);
            destroyedNum--;
        }

 

    }
    void Update()
    {
        switch (destroyedNum)
        {
            case 1:
                cam.fieldOfView = 30;
                break;
            case 2:
                cam.fieldOfView = 1;
                break;
            default:
                cam.fieldOfView = 60;
                break;
        }
    }
}
