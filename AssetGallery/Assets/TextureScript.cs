using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Script to set the texutres of a plane to be the same across all objects regardless of their size and shape
/// How to use: Attach to plane as component
/// Written by: Sammy Chan
/// ----------
/// 

public class TextureScript : MonoBehaviour
{
    Renderer rend;
    public float tileSize = 3;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        float xSize = transform.localScale.x;
        float zSize = transform.localScale.z;
        rend.material.mainTextureScale = new Vector2(tileSize * xSize, tileSize * zSize);
    }

}

