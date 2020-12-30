using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Cursor_Script : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Wisp Sprite
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = (cursorPos - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    // Killing the Elves
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Elf")
        {
            FindObjectOfType<GameManager_Script>().score++;
            // Play sound
            AkSoundEngine.PostEvent("Pop", gameObject);
            Destroy(other.gameObject);
        }
    }
}
