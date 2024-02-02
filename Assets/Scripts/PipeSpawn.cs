using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject Pipeprefab;
    public float spawnRate = 0.05f;
    float timer = 0;
    void Start()
    {
        Instantiate(Pipeprefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new pipe
        if (timer >= spawnRate)
        {
            // Spawn a new pipe and reset the timer
            Instantiate(Pipeprefab, transform.position, Quaternion.identity);
            transform.position = new Vector2(transform.position.x, Random.Range(-9, 9));
            timer = 0;
        }
    }
}
