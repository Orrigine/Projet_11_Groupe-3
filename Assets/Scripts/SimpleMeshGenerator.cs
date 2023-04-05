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
        // TO DO: Vertices array of type Vector3
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f,0f,0f), //0
            new Vector3(1f,0f,0f), //1
            new Vector3(0f,1f,0f) //2
        };
        // TO DO: Indices array of type int
        int[] indices = new int[] 
        {
            0,2,1
        };

        Color[] colors = new Color[] 
        {
            Color.red,
            Color.green,
            Color.blue, 
        };

		// TO DO: appeller la fonction BuildMesh avec les bons paramètres
        BuildMesh("Triangle", vertices, indices, null, colors);
    }
    private void MakeQuad()
    {
        // TO DO: Vertices array of type Vector3
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f,0f,0f), //0
            new Vector3(0f,1f,0f), //1
            new Vector3(1f,0f,0f), //2
            new Vector3(1f,1f,0f), //3
        };
        // TO DO: Indices array of type int
        int[] indices = new int[]
        {
            0,1,2,
            3,2,1
        };
        // TO DO: appeller la fonction BuildMesh avec les bons paramètres
        BuildMesh("Quad", vertices, indices);
    }

    private void MakeDoubleQuad()
    {
        // TO DO: Vertices array of type Vector3
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f,0f,0f), //0
            new Vector3(0f,1f,0f), //1
            new Vector3(1f,0f,0f), //2
            new Vector3(1f,1f,0f), //3

            new Vector3(2f,0f,0f), //4
            new Vector3(2f,1f,0f), //5
            new Vector3(3f,0f,0f), //6
            new Vector3(3f,1f,0f), //7
        };
        // TO DO: Indices array of type int
        int[] indices = new int[]
        {
            0,1,2,
            3,2,1,

            4,5,6,
            7,6,5
        };
        // TO DO: appeller la fonction BuildMesh avec les bons paramètres
        BuildMesh("Quad", vertices, indices);
    }


    protected void BuildMesh(string gameObjectName, Vector3[] vertices, int[] indices, Vector2[] uvs = null, Color[] color = null)
    {
        // Search in the scene if there is a GameObject called "gameObjectName". If yes, we destroy it.
        GameObject oldOne = GameObject.Find(gameObjectName);
        if (oldOne != null)
            DestroyImmediate(oldOne);

        // Create a GameObject
        GameObject primitive = new GameObject(gameObjectName);
        
        // Add the components...
        MeshRenderer meshRenderer = primitive.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = primitive.AddComponent<MeshFilter>();
      
        // ... and set the mesh buffers. 
        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.triangles = indices;
        meshFilter.mesh.uv = uvs;
        meshFilter.mesh.colors = color;

        // Apply the material.
        meshRenderer.material = _MeshMaterial != null ? _MeshMaterial : new Material(Shader.Find("Universal Render Pipeline/Unlit"));
    }
}
