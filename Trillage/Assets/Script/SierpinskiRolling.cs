using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SierpinskiRolling : MonoBehaviour 
{
    public int depth = 5;
    public float size = 5f;
    public Material material;
    public Color color;


    private GameObject CreateTriangleRolling(Vector2 a, Vector2 b, Vector2 c)
    {
        GameObject triangleObject = new GameObject("Triangle");
        MeshFilter meshFilter = triangleObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = triangleObject.AddComponent<MeshRenderer>();
        TransformObject transform = triangleObject.AddComponent<TransformObject>();

        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] { a, b, c };
        mesh.triangles = new int[] { 0, 1, 2 };
        meshFilter.mesh = mesh;

        meshRenderer.material = material;

        return triangleObject;
    }

    private void CreateSierpinskiRolling(Vector2 a, Vector2 b, Vector2 c, int depth)
    {
        if (depth == 0)
        {
            CreateTriangleRolling(a, b, c);
        }
        else
        {
            Vector2 ab = (a + b) / 2f;
            Vector2 bc = (b + c) / 2f;
            Vector2 ca = (c + a) / 2f;

            CreateSierpinskiRolling(a, ab, ca, depth - 1);
            CreateSierpinskiRolling(ab, b, bc, depth - 1);
            CreateSierpinskiRolling(ca, bc, c, depth - 1);
        }
    }

    private void CreateSierpinskiRollingSolidSurface(Vector2 a, Vector2 b, Vector2 c, int depth)
    {
        if (depth == 0)
        {
        }
        else
        {
            Vector2 ab = (a + b) / 2f;
            Vector2 bc = (b + c) / 2f;
            Vector2 ca = (c + a) / 2f;
            Vector2 center = (a + b + c) / 3f;

            CreateSierpinskiRollingSolidSurface(a, ab, ca, depth - 1);
            CreateSierpinskiRollingSolidSurface(ab, b, bc, depth - 1);
            CreateSierpinskiRollingSolidSurface(ca, bc, c, depth - 1);
            CreateSierpinskiRollingSolidSurface(ab, bc, center, depth - 1);
        }
    }
    void Start()
    {
        Vector2 a = new Vector2(-size, -size);
        Vector2 b = new Vector2(size, -size);
        Vector2 c = new Vector2(0f, size * Mathf.Sqrt(3f) - size);

        CreateSierpinskiRolling(a, b, c, depth);
        
        CreateSierpinskiRollingSolidSurface(a, b, c, depth);
    }





}

