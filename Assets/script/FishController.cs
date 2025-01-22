using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For loading the next level
using TMPro; // Import TextMeshPro namespace

public class FishController : MonoBehaviour
{
    public float speed = 10f; // Fish speed
    public int score = 0; // Tracks the score
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro UI element
    public string nextLevelName; // Name of the next level scene to load
    public string winCoinTag = "WinCoin"; // Tag for the special coin
    public string foodTag = "Food"; // Tag for food objects

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Initialize the score display
        UpdateScoreText();
    }

    void Update()
    {
        // Control the fish movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the fish touches a food object
        if (collision.CompareTag(foodTag))
        {
            // Increment the score
            score++;
            Debug.Log("Food collected! Current Score: " + score);

            // Destroy the food object
            Destroy(collision.gameObject);

            // Update the score UI
            UpdateScoreText();
        }

        // Check if the fish touches the special win coin
        if (collision.CompareTag(winCoinTag))
        {
            Debug.Log("Win Coin collected! Level Complete!");
            // Destroy the coin object
            Destroy(collision.gameObject);

            // Load the next level after a short delay
            StartCoroutine(LoadNextLevel());
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the TextMeshPro UI text
        }
    }

    IEnumerator LoadNextLevel()
    {
        Debug.Log("Loading next level...");
        yield return new WaitForSeconds(2f); // Optional delay before loading the next level
        SceneManager.LoadScene(nextLevelName); // Load the next level
    }
}
