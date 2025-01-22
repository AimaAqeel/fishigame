using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public float spawnInterval = 2f; // Time interval between spawns
    public int totalEnemies = 5; // Number of enemies to spawn
    public float horizontalSpacing = 2f; // Spacing between enemies
    public float spawnY = 5f; // Y-position of enemy spawn
    public float moveSpeed = 2f; // Speed of enemy movement

    private int spawnedEnemies = 0; // Counter for spawned enemies

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (spawnedEnemies < totalEnemies)
        {
            // Calculate the x-position for the current enemy
            float spawnX = -4f + (spawnedEnemies * horizontalSpacing);

            // Instantiate the enemy at the calculated position
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Make the enemy move downwards
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);

            spawnedEnemies++;
            yield return new WaitForSeconds(spawnInterval); // Wait before spawning the next enemy
        }
    }
}
