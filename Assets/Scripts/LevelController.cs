using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private GameObject tokenCounterText;

    private int tokensGoal;

    private int tokensCollected;

    private int startTokensGoal = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (GameInformationData.currentLevel == 0)
        {
            tokensGoal = startTokensGoal;
        }
        else
        {
            tokensGoal = startTokensGoal + GameInformationData.currentLevel * 2;
        }

        tokensCollected = 0;
        tokenCounterText = GameObject.Find("TokensCounter");
        updateTokenCounter();

        Debug.Log("---> " + GameInformationData.currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (tokensCollected == tokensGoal)
        {
            // SceneManager.LoadScene("Trivia", LoadSceneMode.Additive);
            SceneManager.LoadScene("Trivia");
            tokensCollected = 0;
        }
    }

    void updateTokenCounter()
    {
        tokenCounterText.GetComponent<TextMeshProUGUI>().text =
            "Nivel " +
            (GameInformationData.currentLevel + 1) +
            " - " +
            tokensCollected +
            "/" +
            tokensGoal +
            " fichas";
    }

    public string getTokenCounterText()
    {
        return tokensCollected + "/" + tokensGoal + " fichas";
    }

    public void tokenCollected()
    {
        tokensCollected = tokensCollected + 1;
        updateTokenCounter();
    }
}
