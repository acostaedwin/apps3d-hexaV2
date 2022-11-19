using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MapaN1");
    }

    public void Back()
    {
        // SceneManager.LoadScene("MapaN1", LoadSceneMode.Additive);
        SceneManager.LoadScene("MapaN1");
    }

    public void QuitG()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
