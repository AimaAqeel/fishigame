using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for reloading the scene or switching to a Game Over screen

public class EnemyCollision : MonoBehaviour
{
    // Method triggered when another Collider2D touches this object's Collider2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Log to check if this method is called
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Check if the object collided with has the "enemy" tag
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Collided with an enemy!");

            // Destroy the enemy object
            Debug.Log("Destroying enemy: " + collision.gameObject.name);
            Destroy(collision.gameObject);

            // Destroy this fish object
            Debug.Log("Destroying Fish: " + gameObject.name);
            Destroy(gameObject);

            Debug.Log("Both fish and enemy destroyed!");

            // Handle Game Over
            GameOver();
        }
        else
        {
            Debug.Log("Collision detected, but not with an enemy!");
        }
    }

    // Game Over logic
    void GameOver()
    {
        Debug.Log("Game Over!");

        // Option 1: Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Option 2: Load a "Game Over" scene (uncomment and use if you have one)
        // SceneManager.LoadScene("GameOverScene");

        // Option 3: Stop the game entirely (useful for testing purposes)
        // Debug.Break();
    }
}

