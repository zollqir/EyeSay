using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    Renderer texture;
    // Start is called before the first frame update
    void Start()
    {
        texture = GetComponent<Renderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * -0.5f;
        float scaleX = Mathf.Sin(Time.time) * 0.01f + 1;
        //float scaleY = Mathf.Sin(Time.time) * 0.1f + 1;
        texture.material.mainTextureScale = new Vector2(scaleX*70, 70);
        texture.material.mainTextureOffset = new Vector2(offset, offset);

    }
}
