using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private GameObject tokenCounterText;

    public int tokensGoal;

    private int tokensCollected;

    // Start is called before the first frame update
    void Start()
    {
        if (tokensGoal == 0)
        {
            tokensGoal = 5;
        }
        tokensCollected = 0;
        tokenCounterText = GameObject.Find("TokensCounter");
        updateTokenCounter();
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
        tokenCounterText.GetComponent<TextMeshPro>().text =
            tokensCollected + "/" + tokensGoal + " fichas";
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
