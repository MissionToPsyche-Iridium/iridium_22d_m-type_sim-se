using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject pipePrefab;
    public float spawnRate;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
       spawnPipe(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < spawnRate) 
        {
            spawnTimer += Time.deltaTime;
        }
        else 
        {
            spawnRate = Random.Range(2,6);
            if (spawnRate < spawnTimer) {
                spawnPipe();
            }
            spawnTimer = 0;
        }
    }

    void spawnPipe() 
    {
        // randomize the y position of top pipe
        float y = Random.Range(-2.5f, 2.5f);
        // spawn the top pipe
        Instantiate(pipePrefab, new Vector3(transform.position.x, y, transform.position.z), transform.rotation);
        // spawn the bottom pipe
        Instantiate(pipePrefab, new Vector3(transform.position.x, y - 5, transform.position.z), transform.rotation); 
    }
}
