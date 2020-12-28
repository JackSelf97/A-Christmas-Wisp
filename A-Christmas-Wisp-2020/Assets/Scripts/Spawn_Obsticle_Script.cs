using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Obsticle_Script : MonoBehaviour
{
    public GameObject smallObs, medObs, bigObs, randomObs;
    private bool sentObs = false;
    public float timer, timeLimit = 4;

    // Update is called once per frame
    void Update()
    {
        if (sentObs == false)
        {
            // Pick a random number
            int randomNum = Random.Range(1, 4);
            Debug.Log(randomNum);

            if (randomNum == 1)
            {
                randomObs = smallObs;
            }
            else if (randomNum == 2)
            {
                randomObs = medObs;
            }
            else if (randomNum == 3)
            {
                randomObs = bigObs;
            }

            sentObs = true;
        }

        // Timer
        timer += Time.deltaTime;
        if (timer >= timeLimit)
        {
            // Spawn Small
            if (randomObs == smallObs)
            {
                Instantiate(randomObs, new Vector2(transform.position.x, transform.position.y + 1.35f), Quaternion.identity);
                timer = 0;
                sentObs = false;
            }
            // Spawn Medium
            if (randomObs == medObs)
            {
                Instantiate(randomObs, new Vector2(transform.position.x, transform.position.y + 1.85f), Quaternion.identity);
                timer = 0;
                sentObs = false;
            }
            // Spawn Big
            if (randomObs == bigObs)
            {
                Instantiate(randomObs, new Vector2(transform.position.x, transform.position.y + 2.35f), Quaternion.identity);
                timer = 0;
                sentObs = false;
            }
        }
    }
}
