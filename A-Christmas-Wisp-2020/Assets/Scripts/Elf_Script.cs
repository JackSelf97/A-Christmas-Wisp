using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf_Script : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Die if out of bounds
        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
