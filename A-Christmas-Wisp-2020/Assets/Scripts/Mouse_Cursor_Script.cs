using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Cursor_Script : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Wisp Sprite
        Cursor.visible = false;
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
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
