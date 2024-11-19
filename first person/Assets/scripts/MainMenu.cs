using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas main;

    public Canvas options;

     void Start()
    {
        main.enabled = true;
        options.enabled = false;
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnOptions()
    {
        main.enabled = false;
        options.enabled =true;
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnBack()
    {
        main.enabled = true;
        options.enabled = false;
    }
}
