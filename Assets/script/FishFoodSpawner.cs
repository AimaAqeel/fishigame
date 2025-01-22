using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFoodSpawner : MonoBehaviour
{
    public GameObject fishFoodPrefab; // Reference to the fish food prefab
    public float spawnInterval = 1f; // Time between spawns
    public Vector2 spawnArea; // Width and height of spawn area

    void Start()
    {
        InvokeRepeating("SpawnFishFood", 0f, spawnInterval);
    }

    void SpawnFishFood()
    {
        // Random position within the spawn area
        float spawnX = Random.Range(-spawnArea.x / 1, spawnArea.x / 1);
        float spawnY = Random.Range(-spawnArea.y / 1, spawnArea.y / 1);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        // Instantiate fish food
        Instantiate(fishFoodPrefab, spawnPosition, Quaternion.identity);
    }
}
