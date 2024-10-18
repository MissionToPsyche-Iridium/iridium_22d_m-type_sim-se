using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class MountainGenerator : MonoBehaviour
{
    public int width = 500;    // Width of the mountain range
    public int depth = 500;    // Depth of the mountain range
    public float height = 10f;  // Height of the mountains
    public float scale = 0.05f; // Scale for Perlin noise

    public Material mountainMaterial;  // Reference to the material for the mesh

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    void Start()
    {
        GenerateMountain();

        // Assign the material to the MeshRenderer
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (mountainMaterial != null)
        {
            meshRenderer.material = mountainMaterial;
        }
        else
        {
            Debug.LogWarning("No material assigned to the Mountain!");
        }

        // Ensure this object is tagged as "Ground" for player detection
        gameObject.tag = "Ground";
    }

    void GenerateMountain()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

        // Add MeshCollider to make the mesh solid
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }

    void CreateShape()
    {
        vertices = new Vector3[(width + 1) * (depth + 1)];
        for (int i = 0, z = 0; z <= depth; z++)
        {
            for (int x = 0; x <= width; x++, i++)
            {
                float y = Mathf.PerlinNoise(x * scale, z * scale) * height;
                vertices[i] = new Vector3(x, y, z);
            }
        }

        triangles = new int[width * depth * 6];
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + width + 1;
                triangles[tris + 2] = vert + 1;

                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + width + 1;
                triangles[tris + 5] = vert + width + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    void OnDrawGizmos()
    {
        if (vertices == null) return;

        for (int i = 0; i < vertices.Length; i += 100)  // Draw every 100th vertex to prevent performance issues
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}

