using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadSceneOutro()
    {
        SceneManager.LoadScene("Outro");
    }

    public void LoadSceneIntro()
    {
        SceneManager.LoadScene("Intro");
    }

}