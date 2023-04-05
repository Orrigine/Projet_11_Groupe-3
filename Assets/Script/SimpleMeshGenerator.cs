using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMeshGenerator : MonoBehaviour
{
    public Material _MeshMaterial;

    void Start()
    {
        MakeTriangle();
        //MakeQuad();
        //MakeDoubleQuad();
    }

    void MakeTriangle()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f),    // 0
            new Vector3(1f, 1.5f, 0f),  // 1
            new Vector3(2f, 0f, 0f)     // 2
        };

        int[] indices = new int[]
        {
            0, 1, 2
        };

        Color[] colors = new Color[]
        {
            Color.green,
            Color.red,
            Color.blue
        };

        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0.1f, 0.6f),
            new Vector2(0.25f, 0.9f),
            new Vector2(0.4f, 0.6f),
        };

        BuildMesh("Triangle", vertices, indices, uvs, colors);
    }

    void MakeQuad()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(1f, 1f, 0f),
            new Vector3(1f, 0f, 0f)
        };

        int[] indices = new int[]
        {
            0, 1, 2,
            0, 2, 3
        };

        BuildMesh("Quad", vertices, indices);
    }

    void MakeDoubleQuad()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f), //0
            new Vector3(0f, 1f, 0f), //1
            new Vector3(1f, 1f, 0f),
            new Vector3(1f, 0f, 0f),

            new Vector3(1.5f, 0f, 0f),  //4
            new Vector3(1.5f, 1f, 0f),
            new Vector3(2.5f, 1f, 0f),
            new Vector3(2.5f, 0f, 0f),  //7
        };

        int[] indices = new int[]
        {
            0, 1, 2,
            0, 2, 3,

            4, 5, 6,
            4, 6, 7,
        };

        BuildMesh("DoubleQuad", vertices, indices);
    }

    protected void BuildMesh(string gameObjectName, Vector3[] vertices, int[] indices, Vector2[] uvs = null, Color[] colors = null)
    {
        // Destroy current one if it exists.
        GameObject oldOne = GameObject.Find(gameObjectName);
        if (oldOne != null)
            DestroyImmediate(oldOne);

        // Create a GameObject.
        GameObject go = new GameObject(gameObjectName);

        // Add the components
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        MeshFilter mf = go.AddComponent<MeshFilter>();

        // and set the mesh buffers.. 
        mf.mesh.vertices = vertices;
        mf.mesh.triangles = indices;
        mf.mesh.uv = uvs;
        mf.mesh.colors = colors;

        // Apply the material.
        mr.material = _MeshMaterial != null ? _MeshMaterial : new Material(Shader.Find("Universal Render Pipeline/Unlit"));
    }
}