using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandle : MonoBehaviour
{
    public void PauseGame()
    {
        Debug.Log("perrisima");
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
