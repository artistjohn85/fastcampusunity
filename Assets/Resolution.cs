using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    void Update() 
    { 
        var camera = GetComponent<Camera>(); 
        var rect = camera.rect; 
        var scaleheight = ((float)Screen.width / (float)Screen.height) / (16f / 9f);
        var scalewidth = 1f / scaleheight; // 1 / 1
        if (scaleheight < 1f) 
        { 
            rect.height = scaleheight; // 
            rect.y = (1f - scaleheight) / 2f; 
        } 
        else 
        { 
            rect.width = scalewidth; // 1
            rect.x = (1f - scalewidth) / 2f; 
        } 
        camera.rect = rect; 
    }
}
