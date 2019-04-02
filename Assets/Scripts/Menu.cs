using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool paused = false;
    GameObject Pause = null, Res, Esc;

    private void Update()
    {
        if (Time.timeSinceLevelLoad < 0.2f && SceneManager.GetActiveScene().name == "PingPong" && Pause == null)
        {
            Pause = GameObject.FindGameObjectWithTag("PAUSE");
            Res = GameObject.FindGameObjectWithTag("RESUME");
            Esc = GameObject.FindGameObjectWithTag("EXIT");
            Res.SetActive(false);
            Esc.SetActive(false);
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PingPong");
    }

    public void PauseGame()
    {
        Pause.SetActive(false);
        Res.SetActive(true);
        Esc.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    public void Resume()
    {
        Pause.SetActive(true);
        Res.SetActive(false);
        Esc.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
