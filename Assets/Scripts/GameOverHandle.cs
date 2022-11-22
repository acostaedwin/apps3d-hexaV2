using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandle : MonoBehaviour
{
    private GameObject gOtokenCounterText;

    private GameObject gameOver;

    CharacterMove characterMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
        characterMoveScript =
            GameObject.FindObjectOfType(typeof (CharacterMove)) as
            CharacterMove;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame(string sceneName)
    {
        SceneManager.LoadScene (sceneName);
    }

    public void ShowGameOver(string textTokens)
    {
        characterMoveScript.blockMovement = true;

        // Debug.Log("ShowGameOver");
        gameOver.SetActive(true);
        gOtokenCounterText = GameObject.Find("GOTextTokens");
        gOtokenCounterText.GetComponent<TextMeshProUGUI>().text = textTokens;
    }
}
