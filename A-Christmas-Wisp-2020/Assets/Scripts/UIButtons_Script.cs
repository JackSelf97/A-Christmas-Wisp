using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtons_Script : MonoBehaviour
{
    // Animators
    public Animator SceneSwitchAnim;

    // Button Enums
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

    // Functions
    #region Button Functions (w/ coroutines)
    public void ClickPlay()
    {
        StartCoroutine("Play");
    }
    public void ClickHardcore()
    {
        StartCoroutine("Hardcore");
    }
    public void ClickMenu()
    {
        StartCoroutine("Menu");
    }
    public void ClickQuit()
    {
        StartCoroutine("Quit");
    }

    #endregion

    // Main Function
    public void GetAllTheButtons()
    {
        if (SceneManager.GetActiveScene().name == "Game_1" || SceneManager.GetActiveScene().name == "Game_2")
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
        if (button == Buttons.Hardcore)
        {
            Button gameButton = gameObject.GetComponent<Button>();
            gameButton.onClick.AddListener(ClickHardcore);
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

    // Coroutines
    #region Button Coroutines

    private IEnumerator Play()
    {
        SceneSwitchAnim.SetBool("Menu", true);
        // Play sound
        AkSoundEngine.PostEvent("Click", gameObject);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game_1");
    }

    private IEnumerator Hardcore()
    {
        SceneSwitchAnim.SetBool("Menu", true);
        // Play sound
        AkSoundEngine.PostEvent("Click", gameObject);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game_2");
    }

    private IEnumerator Menu()
    {
        FindObjectOfType<GameManager_Script>().ResetTime();
        SceneSwitchAnim.SetBool("Game_1", false);
        // Play sound
        AkSoundEngine.PostEvent("Click", gameObject);
        yield return new WaitForSeconds(2.5f);
        AkSoundEngine.StopAll();
        SceneManager.LoadScene("Main_Menu");
    }

    private IEnumerator Quit()
    {
        SceneSwitchAnim.SetBool("Menu", true);
        // Play sound
        AkSoundEngine.PostEvent("Click", gameObject);
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }

    #endregion

}
