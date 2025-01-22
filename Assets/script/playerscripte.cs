using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f; // Speed of the player
    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * speed; // Apply movement to the Rigidbody2D
    }
    void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("FishFood"))
    {
        Destroy(collision.gameObject); // Destroy the food
        // Optionally, increase score or trigger an effect
    }
}

}
