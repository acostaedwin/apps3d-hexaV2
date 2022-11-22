using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterColliderHandle : MonoBehaviour
{
    public AudioSource crashSound;

    public AudioSource waterSplashSound;

    public AudioSource ouchSound;

    public AudioSource coinCollectedSound;

    LevelController levelControllerScript;

    GameOverHandle gameOverHandleScript;

    // Start is called before the first frame update
    void Start()
    {
        levelControllerScript =
            GameObject.FindObjectOfType(typeof (LevelController)) as
            LevelController;

        gameOverHandleScript =
            GameObject.FindObjectOfType(typeof (GameOverHandle)) as
            GameOverHandle;
        // Debug.Log(levelControllerScript == null);
        // Debug.Log(gameOverHandleScript == null);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("levelControllerScript: " + levelControllerScript.tokensGoal);
        if (other.gameObject.tag == "token")
        {
            other.gameObject.SetActive(false);
            playSound (coinCollectedSound);
            levelControllerScript.tokenCollected();
        }
        // Debug.Log("other.tag: " + levelController.tokensGoal);
        // Debug.Log("other.gameObject: " + other.gameObject.tag);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            // StartCoroutine(CrashCoroutine());
            playSound (crashSound);
            gameOverHandleScript
                .ShowGameOver(levelControllerScript.getTokenCounterText());
        }
        if (collision.gameObject.tag == "water")
        {
            // StartCoroutine(WaterCoroutine());
            playSound (waterSplashSound);
            gameOverHandleScript
                .ShowGameOver(levelControllerScript.getTokenCounterText());
        }
        if (collision.gameObject.tag == "hell")
        {
            playSound (ouchSound);
            gameOverHandleScript
                .ShowGameOver(levelControllerScript.getTokenCounterText());
            // StartCoroutine(OutOfMapCoroutine());
        }
        else if (
            collision.gameObject.tag == "Untagged" ||
            collision.gameObject.tag == "fieldOfPlay"
        )
        {
        }
        else
        {
            Debug.Log("Collision with: " + collision.gameObject.tag);
        }
        // Debug.Log("Name: " + collision.gameObject.name);
    }

    /*
    IEnumerator OutOfMapCoroutine()
    {
        //wait for 1 second.
        yield return new WaitForSeconds(1);

        gameOverHandleScript
            .ShowGameOver(levelControllerScript.getTokenCounterText());

        // Debug.Log("===>" + levelControllerScript.getTokenCounterText());
        //  SceneManager.LoadScene("MapaN1");
    }

    IEnumerator CrashCoroutine()
    {
        playSound (crashSound);

        //wait for 1 second.
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MapaN1");
    }

    IEnumerator WaterCoroutine()
    {
        playSound (waterSplashSound);

        //wait for 1 second.
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MapaN1");
    }
    */
    private void playSound(AudioSource sound)
    {
        if (sound != null) sound.Play();
    }
}
