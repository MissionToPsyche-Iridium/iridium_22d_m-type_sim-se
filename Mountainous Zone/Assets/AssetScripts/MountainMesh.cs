using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class MountainGenerator : MonoBehaviour
{
    public int width = 500;            
    public int depth = 500;            
    public float height = 100f;       
    public float scale = 0.01f;       
    public int octaves = 4;            
    public float persistence = 0.5f;   
    public float lacunarity = 2.0f;   
    public float roughness = 1.5f;    

    public Material mountainMaterial;  

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    void Start()
    {
        GenerateMountain();

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (mountainMaterial != null)
        {
            meshRenderer.material = mountainMaterial;
        }
        else
        {
            Debug.LogWarning("No material assigned to the Mountain!");
        }
    }

    void GenerateMountain()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

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
                float y = GenerateRidgeNoise(x, z) * height;

                y = Mathf.Clamp(y, 0f, height); 
                if (!float.IsFinite(y))
                {
                    Debug.LogWarning($"Non-finite value detected at vertex {i}: {y}. Clamping to 0.");
                    y = 0f; 
                }

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

    float GenerateRidgeNoise(int x, int z)
    {
        float noiseValue = 0f;
        float amplitude = 1f;
        float frequency = 1f;
        float maxNoiseValue = 0f;

        for (int i = 0; i < octaves; i++)
        {
            float sampleX = x * scale * frequency;
            float sampleZ = z * scale * frequency;

            float perlinValue = Mathf.PerlinNoise(sampleX, sampleZ);

            float ridgeValue = 1f - Mathf.Abs(perlinValue * 2f - 1f);  

            
            ridgeValue = Mathf.Max(0f, ridgeValue);  
            
            ridgeValue = Mathf.Pow(ridgeValue, roughness);

            noiseValue += ridgeValue * amplitude;
            maxNoiseValue += amplitude;

            amplitude *= persistence;
            frequency *= lacunarity;
        }

        float finalValue = noiseValue / maxNoiseValue;

       
        if (!float.IsFinite(finalValue))
        {
            Debug.LogWarning($"Non-finite noise value: {finalValue}. Clamping to 0.");
            finalValue = 0f;  
        }

        return Mathf.Clamp(finalValue, 0f, 1f);
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}