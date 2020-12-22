using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Elf_Script : MonoBehaviour
{
    public GameObject elf;
    private float timer, timeLimit = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
