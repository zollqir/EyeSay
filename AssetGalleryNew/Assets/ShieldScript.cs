using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Script attached to shield object
/// How to use:
///     Shield object should exist as inactive object within the gameworld already
///     Once shield is activated via the spell, it will deactivate itself after
///         the specified duration
/// Written by: Sammy Chan
/// ----------
/// 

public class ShieldScript : MonoBehaviour
{
    Renderer[] _material;
    float duration = 10;
    float colorTick = 0;
    Color originalColour;

    // Start is called before the first frame update
    void Awake()
    {
        _material = GetComponentsInChildren<Renderer>();
        originalColour = _material[0].material.color;
    }

    public void ResetShield()
    {
        foreach (Renderer texture in _material)
        {
            texture.material.color = originalColour;
        }
        colorTick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Change Colour over time
        float offset = Time.time * -0.9f;
        foreach (Renderer texture in _material) {
            texture.material.mainTextureOffset = new Vector2(0, offset);
            texture.material.color = Color.Lerp(originalColour, Color.red, colorTick);
        }
        if (colorTick < 0.5)
        {
            colorTick += (Time.deltaTime / duration) / 2;
        }
        else
        {
            ResetShield();
            this.gameObject.SetActive(false);
        }

        //if (Time.time - startTime > 5){
          //this.gameObject.SetActive(false);
        //}

    }
}
