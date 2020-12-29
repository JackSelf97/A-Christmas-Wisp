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
    public Player_Script P_Script;
    private Canvas GameOver_Canvas;
    private Text deathText;
    public bool timeFlow = true;
    private bool checkOnce = false;
    public Animator SceneSwitchAnim;

    // Update speed
    public float globalTimer, globalTimeLimit = 10;
    public GameObject elf, small_Obs, med_Obs, big_Obs;
    public GameObject BG_1, BG_2, BG_3, BG_4, BG_5, BG_6;


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
            // Get the player script
            P_Script = FindObjectOfType<Player_Script>();

            // Get the animator
            SceneSwitchAnim = GameObject.Find("UI_Canvas/LoadingAnim").GetComponent<Animator>();

            // Play the animation
            SceneSwitchAnim.SetBool("Game_1", true);

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


            // Get the screen
            GameOver_Canvas = GameObject.Find("UI_Canvas/GameOver_Panel").GetComponent<Canvas>();
            deathText = GameObject.Find("UI_Canvas/GameOver_Panel/Score").GetComponent<Text>();
            // Off
            GameOver_Canvas.enabled = false;
        }

        

    }




    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "Game_1")
        {
            // Get the player script
            P_Script = FindObjectOfType<Player_Script>();

            // Get the screen
            GameOver_Canvas = GameObject.Find("UI_Canvas/GameOver_Panel").GetComponent<Canvas>();
            deathText = GameObject.Find("UI_Canvas/GameOver_Panel/Score").GetComponent<Text>();

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

            // Death
            if (P_Script.currentHealth <= 0 && checkOnce == false)
            {
                //Gameover
                GameOver_Canvas.enabled = true;
                deathText.text = "" + score;
                timeFlow = false;
                checkOnce = true;

            }

            if (timeFlow == false)
            {
                Time.timeScale = 0;
            }
            else if (timeFlow == true)
            {
                Time.timeScale = 1;
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

    public void ResetTime()
    {
        //P_Script.currentHealth = P_Script.maxHealth;
        timeFlow = true;
    }
}
