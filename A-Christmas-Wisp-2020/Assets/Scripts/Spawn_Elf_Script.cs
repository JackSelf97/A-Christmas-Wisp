using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Elf_Script : MonoBehaviour
{
    // Variables
    public GameObject elf;
    public float timer, timeLimit = 1;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeLimit)
        {
            Instantiate(elf, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            timer = 0;
        }
    }
}
