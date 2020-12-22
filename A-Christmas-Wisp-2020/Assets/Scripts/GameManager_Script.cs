using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Script : MonoBehaviour
{
    public Text scoreText;
    public int score;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("UI_Canvas/Kills").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Elves Killed: " + score;
    }
}
