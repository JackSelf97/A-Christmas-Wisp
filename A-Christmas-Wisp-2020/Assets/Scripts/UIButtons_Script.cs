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
        Controls,
        Quit,
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

    public void GetAllTheButtons()
    {
        // Get the animator
        SceneSwitchAnim = GameObject.Find("Menu_Canvas/LoadingAnim").GetComponent<Animator>();

        // Get the buttons
        if (button == Buttons.Play)
        {
            Button gameButton = gameObject.GetComponent<Button>();
            gameButton.onClick.AddListener(ClickPlay);
        }
    }

    private IEnumerator Play()
    {
        // Play the animation
        SceneSwitchAnim.SetTrigger("SwitchScene");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Game_1");
    }
}
