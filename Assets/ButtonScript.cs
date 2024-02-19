using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject help;
    public void StartButton()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void RankingButton()
    {
        SceneManager.LoadScene("RankingPage");
    } 
    public void HelpButton()
    {
        help.SetActive(!help.activeSelf);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
