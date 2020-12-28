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
            scoreText = GameObject.Find("UI_Canvas/Kills").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game_1")
            scoreText.text = "Elves Killed " + score;
    }
}
