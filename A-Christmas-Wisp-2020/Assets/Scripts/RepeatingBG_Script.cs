using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG_Script : MonoBehaviour
{
    // Repeating Background (BlackThornProd Video: Endless Runner: https://www.youtube.com/watch?v=5M7vX_z6B9I&t=354s&ab_channel=Blackthornprod)
    // Variables
    public float speed;
    public float endX, startX;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
    }
}
