using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriviaHandle : MonoBehaviour
{
    private GameObject imageTrivia;

    private int triviaNumber;

    private List<TriviaAnswer> triviasAnswer;

    public AudioSource errorAudio;

    public AudioSource succesAudio;

    // Start is called before the first frame update
    void Start()
    {
        imageTrivia = GameObject.Find("ImageTrivia");

        triviaNumber = Random.Range(1, 11);
        Debug.Log("triviaNumber: " + triviaNumber);
        imageTrivia.GetComponent<Image>().sprite =
            getRandomSprite(triviaNumber);

        initTriviaAnswers();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void answerTrivia(int index)
    {
        hideButtons();
        Debug.Log("index: " + index);
        Debug.Log("triviaNumber: " + triviaNumber);
        foreach (TriviaAnswer triviaAnswer in triviasAnswer)
        {
            if (triviaAnswer.getNumber() == triviaNumber)
            {
                if (triviaAnswer.getIndexCorrectAnswer() == index)
                {
                    Debug.Log("Correcto");
                    playSound (succesAudio);
                    StartCoroutine(nextLevel());
                }
                else
                {
                    Debug.Log("Incorrecto");
                    playSound (errorAudio);
                    StartCoroutine(restartScene());
                }
            }
        }
    }

    private Sprite getRandomSprite(int triviaNumber)
    {
        return Resources.Load<Sprite>("Trivias/" + triviaNumber);
    }

    private void initTriviaAnswers()
    {
        triviasAnswer = new List<TriviaAnswer>();
        triviasAnswer.Add(new TriviaAnswer(1, 1));
        triviasAnswer.Add(new TriviaAnswer(2, 1));
        triviasAnswer.Add(new TriviaAnswer(3, 3));
        triviasAnswer.Add(new TriviaAnswer(4, 1));
        triviasAnswer.Add(new TriviaAnswer(5, 3));
        triviasAnswer.Add(new TriviaAnswer(6, 2));
        triviasAnswer.Add(new TriviaAnswer(7, 3));
        triviasAnswer.Add(new TriviaAnswer(8, 3));
        triviasAnswer.Add(new TriviaAnswer(9, 3));
        triviasAnswer.Add(new TriviaAnswer(10, 1));
    }

    private void playSound(AudioSource audioSource)
    {
        if (audioSource != null) audioSource.Play();
    }

    IEnumerator restartScene()
    {
        //waiting...
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MapaN1");
    }

    IEnumerator nextLevel()
    {
        //waiting...
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MapaN1");
    }

    private void hideButtons()
    {
        GameObject.Find("AnswerBtn1").SetActive(false);
        GameObject.Find("AnswerBtn2").SetActive(false);
        GameObject.Find("AnswerBtn3").SetActive(false);
    }
}
