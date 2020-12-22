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
    void Update()
    {
        // Wisp Sprite
        Cursor.visible = false;
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = (cursorPos - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);

        //transform.position = cursorPos;
    }

    // Killing the Elves
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Elf")
        {
            FindObjectOfType<GameManager_Script>().score++;
            Destroy(other.gameObject);
        }
    }
}
