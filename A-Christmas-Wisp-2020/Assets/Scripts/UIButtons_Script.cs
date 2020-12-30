using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtons_Script : MonoBehaviour
{
    public Animator SceneSwitchAnim;

    public enum Buttons
    {
        Play,
        Hardcore,
        Quit,
        Menu,
    }

    public Buttons button;

    // Start is called before the first frame update
    void Start()
    {
        GetAllTheButtons();
    }

    public void ClickPlay()
    {
        StartCoroutine("Play");
    }
    public void ClickMenu()
    {
        StartCoroutine("Menu");
    }
    public void ClickQuit()
    {
        StartCoroutine("Quit");
    }

    public void GetAllTheButtons()
    {
        if (SceneManager.GetActiveScene().name == "Game_1")
        {
            // Get the animator
            SceneSwitchAnim = GameObject.Find("UI_Canvas/LoadingAnim").GetComponent<Animator>();
        }

        if (SceneManager.GetActiveScene().name == "Main_Menu")
        {
            // Get the animator
            SceneSwitchAnim = GameObject.Find("Menu_Canvas/LoadingAnim").GetComponent<Animator>();
        }

        // Get the buttons
        if (button == Buttons.Play)
        {
            Button gameButton = gameObject.GetComponent<Button>();
            gameButton.onClick.AddListener(ClickPlay);
        }
        // Get the buttons
        if (button == Buttons.Menu)
        {
            Button gameButton = gameObject.GetComponent<Button>();
            gameButton.onClick.AddListener(ClickMenu);
        }
        if (button == Buttons.Quit)
        {
            Button gameButton = gameObject.GetComponent<Button>();
            gameButton.onClick.AddListener(ClickQuit);
        }
    }

    private IEnumerator Play()
    {
        // Play the animation
        SceneSwitchAnim.SetBool("Menu", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game_1");
    }

    private IEnumerator Menu()
    {
        // Play the animation
        FindObjectOfType<GameManager_Script>().ResetTime();
        SceneSwitchAnim.SetBool("Game_1", false);
        AkSoundEngine.StopAll();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Main_Menu");
    }

    private IEnumerator Quit()
    {
        // Play the animation
        SceneSwitchAnim.SetBool("Menu", true);
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }

}
