using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Script to set the texutres of a cube to be the same across all objects regardless of their size and shape
/// How to use: Attach to plane as component
/// Written by: Sammy Chan
/// ----------
/// 


public class TextureScriptBlock : MonoBehaviour
{

    Renderer rend;
    Mesh mesh;
    public float tileSize = 0.1f;
    private Vector2[] uvs;
    private float width;
    private float depth;
    private float height;
    Vector3 dimensions; 

    // Start is called before the first frame update

    void Start()
    {
        //rend = GetComponent<Renderer>();
        //float xSize = transform.localScale.x;
        //float zSize = transform.localScale.z;
        //rend.material.mainTextureScale = new Vector2(tileSize * xSize, tileSize * zSize);

        dimensions = transform.localScale;
        width = dimensions.x / tileSize;
        depth = dimensions.z / tileSize;
        height = dimensions.y / tileSize;

        mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        uvs = new Vector2[vertices.Length];


        RecalculateUV();
        mesh.uv = uvs;


    }

     void RecalculateUV()
    {
        //Front
        uvs[2] = new Vector2(0, height);
        uvs[3] = new Vector2(width, height);
        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(width, 0);

        //Back
        uvs[7] = new Vector2(0, 0);
        uvs[6] = new Vector2(width, 0);
        uvs[11] = new Vector2(0, height);
        uvs[10] = new Vector2(width, height);

        //Left
        uvs[19] = new Vector2(depth, 0);
        uvs[17] = new Vector2(0, height);
        uvs[16] = new Vector2(0, 0);
        uvs[18] = new Vector2(depth, height);

        //Right
        uvs[23] = new Vector2(depth, 0);
        uvs[21] = new Vector2(0, height);
        uvs[20] = new Vector2(0, 0);
        uvs[22] = new Vector2(depth, height);

        //Top
        uvs[4] = new Vector2(width, 0);
        uvs[5] = new Vector2(0, 0);
        uvs[8] = new Vector2(width, depth);
        uvs[9] = new Vector2(0, depth);

        //Bottom
        uvs[13] = new Vector2(width, 0);
        uvs[14] = new Vector2(0, 0);
        uvs[12] = new Vector2(width, depth);
        uvs[15] = new Vector2(0, depth);

    }

}
