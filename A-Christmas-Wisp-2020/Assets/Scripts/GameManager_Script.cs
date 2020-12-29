using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_Script : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public GameManager_Script GM_Script;

    // Update speed
    public float globalTimer, globalTimeLimit = 10;
    public GameObject elf, small_Obs, med_Obs, big_Obs;
    public GameObject BG_1, BG_2, BG_3, BG_4, BG_5, BG_6;
    public GameObject[] BG;

    // READ-ONLY Speeds
    public int speedBoostLevel = 0;
    public int currentElfSpeed = 4;
    public int currentObsticleSpeed = 4;
    public int currentBG1_2Speed = 7, currentBG3_4Speed = 4, currentBG5_6Speed = 2;

    public bool increaseCheck = false;

    // Only have one GameManager at any one time
    void Awake()
    {
        if (GM_Script == null)
        {
            DontDestroyOnLoad(gameObject);
            GM_Script = this;
        }

        // If theres more than one instance
        else if (GM_Script != null)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game_1")
        {
            scoreText = GameObject.Find("UI_Canvas/Kills").GetComponent<Text>();

            //Start the speeds
            // NOTE - Grab the elf and obsticle prefabs (as they spawn), otherwise assign BG from the hirecahy and NOT thier prefabs
            elf.GetComponent<Elf_Script>().speed = 4;
            small_Obs.GetComponent<Obsticle_Script>().speed = 4;
            med_Obs.GetComponent<Obsticle_Script>().speed = 4;
            big_Obs.GetComponent<Obsticle_Script>().speed = 4;
            BG_1.GetComponent<RepeatingBG_Script>().speed = 7;
            BG_2.GetComponent<RepeatingBG_Script>().speed = 7;
            BG_3.GetComponent<RepeatingBG_Script>().speed = 4;
            BG_4.GetComponent<RepeatingBG_Script>().speed = 4;
            BG_5.GetComponent<RepeatingBG_Script>().speed = 2;
            BG_6.GetComponent<RepeatingBG_Script>().speed = 2;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game_1")
        {
            // Score
            scoreText.text = "Elves Killed " + score;

            // Update speed
            globalTimer += Time.deltaTime;

            if (globalTimer >= globalTimeLimit && increaseCheck == false)
            {
                increaseCheck = true;

                //Increase speed of everything
                IncreaseGameSpeed();

                // Reset
                globalTimer = 0;
            }

        }
    }

    public void IncreaseGameSpeed()
    {
        if (increaseCheck == true)
        {
            // Elf
            elf.GetComponent<Elf_Script>().speed++;
            currentElfSpeed++;

            // Obsticles
            small_Obs.GetComponent<Obsticle_Script>().speed++;
            med_Obs.GetComponent<Obsticle_Script>().speed++;
            big_Obs.GetComponent<Obsticle_Script>().speed++;
            currentObsticleSpeed++;

            // Background
            //BG_1.GetComponent<RepeatingBG_Script>().speed++;
            //BG_2.GetComponent<RepeatingBG_Script>().speed++;
            //BG_3.GetComponent<RepeatingBG_Script>().speed++;
            //BG_4.GetComponent<RepeatingBG_Script>().speed++;
            //BG_5.GetComponent<RepeatingBG_Script>().speed++;
            //BG_6.GetComponent<RepeatingBG_Script>().speed++;
            currentBG1_2Speed++;
            currentBG3_4Speed++;
            currentBG5_6Speed++;


            // Checks
            speedBoostLevel++;
            Debug.Log("Increase Speed!");
            increaseCheck = false;
        }
    }
}
