using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject preIntro;

    private void Start()
    {
        menu.SetActive(true);
        preIntro.SetActive(false);
    }

    public void StartGame()
    {

        SceneManager.LoadScene(1);

    }

    public void ShowPreIntro()
    {

        menu.SetActive(false);
        preIntro.SetActive(true);

    }
}
