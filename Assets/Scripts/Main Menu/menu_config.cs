using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_config : MonoBehaviour
{
    void Start()
    {

    }

    public void LoadGame()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void Game()
    {
        SceneManager.LoadScene("game");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("how_to_play");
    }

    public void Credits()
    {
        SceneManager.LoadScene("credits");
    }

    public void Back()
    {
        SceneManager.LoadScene("main_menu");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
