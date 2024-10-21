using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class MountainGenerator : MonoBehaviour
{
    public int width = 500;            // Width of the mountain range
    public int depth = 500;            // Depth of the mountain range
    public float height = 100f;        // Overall height of the mountains
    public float scale = 0.01f;        // Scale of the noise function
    public int octaves = 4;            // Number of layers of Perlin noise
    public float persistence = 0.5f;   // Persistence controls the amplitude per octave
    public float lacunarity = 2.0f;    // Lacunarity controls the frequency per octave
    public float roughness = 1.5f;     // Roughness factor for rigid mountains

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
                // Apply a combination of noise to create more rigid mountains
                float y = GenerateRidgeNoise(x, z) * height;

                // Ensure all generated values are finite
                y = Mathf.Clamp(y, 0f, height);  // Optional: Clamp to avoid extreme values
                if (!float.IsFinite(y))
                {
                    Debug.LogWarning($"Non-finite value detected at vertex {i}: {y}. Clamping to 0.");
                    y = 0f; // If NaN or Infinity, set to 0 (or some other fallback)
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

    // Generate noise for creating ridged, sharp terrain
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

            // Generate Perlin noise value
            float perlinValue = Mathf.PerlinNoise(sampleX, sampleZ);

            // Convert smooth Perlin noise into ridged noise
            float ridgeValue = 1f - Mathf.Abs(perlinValue * 2f - 1f);  // Ridge function

            // Clamp the ridgeValue to avoid generating holes
            ridgeValue = Mathf.Max(0f, ridgeValue);  // Ensure values stay above zero

            // Apply roughness to make it less smooth and more jagged
            ridgeValue = Mathf.Pow(ridgeValue, roughness);

            noiseValue += ridgeValue * amplitude;
            maxNoiseValue += amplitude;

            amplitude *= persistence;
            frequency *= lacunarity;
        }

        float finalValue = noiseValue / maxNoiseValue;

        // Ensure the final value is finite and clamp to a reasonable range
        if (!float.IsFinite(finalValue))
        {
            Debug.LogWarning($"Non-finite noise value: {finalValue}. Clamping to 0.");
            finalValue = 0f;  // Handle non-finite values
        }

        return Mathf.Clamp(finalValue, 0f, 1f); // Ensure the result stays within a valid range
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}