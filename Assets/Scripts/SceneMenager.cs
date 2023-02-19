using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenager : MonoBehaviour
{
    public void Finish()
    {
        SceneManager.LoadScene("Finish");
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lost");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
