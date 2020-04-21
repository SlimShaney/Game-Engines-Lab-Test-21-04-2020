using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carScript : MonoBehaviour
{

    private Renderer colourRenderer;
    
    void Start()
    {
        colourRenderer = GetComponent<MeshRenderer>();
        colourRenderer.material.color = Color.magenta;
    }

}
