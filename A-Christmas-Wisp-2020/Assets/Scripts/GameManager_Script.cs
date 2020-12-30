using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_Script : MonoBehaviour
{
    // Variables
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
    public GameObject obs_spawner1, obs_spawner2, obs_spawner3;

    // READ-ONLY Speeds
    public int speedBoostLevel = 0;
    public float currentElfSpeed = 4;
    public float currentObsticleSpeed = 4;
    public float currentBG1_2Speed = 7, currentBG3_4Speed = 4, currentBG5_6Speed = 2;
    public bool increaseCheck = false;

    // Only have one GameManager at any one time
    //void Awake()
    //{
    //    if (GM_Script == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        GM_Script = this;
    //    }

    //    // If theres more than one instance
    //    else if (GM_Script != null)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        // X-Mas Mode (Game_1)
        if (SceneManager.GetActiveScene().name == "Game_1")
        {
            // Get the player script
            P_Script = FindObjectOfType<Player_Script>();

            // Get the animator
            SceneSwitchAnim = GameObject.Find("UI_Canvas/LoadingAnim").GetComponent<Animator>();

            // Play the animation
            SceneSwitchAnim.SetBool("Game_1", true);

            scoreText = GameObject.Find("UI_Canvas/Kills").GetComponent<Text>();

            obs_spawner1 = GameObject.Find("Obsticle_Spawner_1");
            obs_spawner2 = GameObject.Find("Obsticle_Spawner_2");
            obs_spawner3 = GameObject.Find("Obsticle_Spawner_3");

            //Start the speeds
            // NOTE - Grab the elf and obsticle prefabs (as they spawn), otherwise assign BG from the hirecahy and NOT thier prefabs
            elf.GetComponent<Elf_Script>().speed = 4f;
            small_Obs.GetComponent<Obsticle_Script>().speed = 4f;
            med_Obs.GetComponent<Obsticle_Script>().speed = 4f;
            big_Obs.GetComponent<Obsticle_Script>().speed = 4f;
            BG_1.GetComponent<RepeatingBG_Script>().speed = 7f;
            BG_2.GetComponent<RepeatingBG_Script>().speed = 7f;
            BG_3.GetComponent<RepeatingBG_Script>().speed = 4f;
            BG_4.GetComponent<RepeatingBG_Script>().speed = 4f;
            BG_5.GetComponent<RepeatingBG_Script>().speed = 2f;
            BG_6.GetComponent<RepeatingBG_Script>().speed = 2f;


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
            //// Get the player script
            //P_Script = FindObjectOfType<Player_Script>();

            //// Get the screen
            //GameOver_Canvas = GameObject.Find("UI_Canvas/GameOver_Panel").GetComponent<Canvas>();
            //deathText = GameObject.Find("UI_Canvas/GameOver_Panel/Score").GetComponent<Text>();

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
            elf.GetComponent<Elf_Script>().speed += 0.5f;
            currentElfSpeed++;

            // Obsticles
            small_Obs.GetComponent<Obsticle_Script>().speed += 0.5f;
            med_Obs.GetComponent<Obsticle_Script>().speed += 0.5f;
            big_Obs.GetComponent<Obsticle_Script>().speed += 0.5f;
            currentObsticleSpeed++;

            // Background does not need to speed up (will tear the illusion)
            currentBG1_2Speed++;
            currentBG3_4Speed++;
            currentBG5_6Speed++;

            // Spawn rate (has been clamped already)
            obs_spawner1.GetComponent<Spawn_Obsticle_Script>().timeLimit -= 0.1f;
            obs_spawner2.GetComponent<Spawn_Obsticle_Script>().timeLimit -= 0.1f;
            obs_spawner3.GetComponent<Spawn_Obsticle_Script>().timeLimit -= 0.1f;


            // Checks
            speedBoostLevel++;
            Debug.Log("Increase Speed!");
            increaseCheck = false;
        }
    }

    public void ResetTime()
    {
        timeFlow = true;
    }
}
