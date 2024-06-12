using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Fase1");

    }
    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");

    }
}
