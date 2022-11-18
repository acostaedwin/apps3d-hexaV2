using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterColliderHandle : MonoBehaviour
{
    public AudioSource crashSound;

    public AudioSource waterSplashSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            StartCoroutine(CrashCoroutine());
        }
        if (collision.gameObject.tag == "water")
        {
            StartCoroutine(WaterCoroutine());
        }
        else if (collision.gameObject.tag == "Untagged")
        {
        }
        else
        {
            Debug.Log("Collision with: " + collision.gameObject.tag);
        }
        Debug.Log("Name: " + collision.gameObject.name);
    }

    IEnumerator CrashCoroutine()
    {
        playCrashSound();

        //wait for 1 second.
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MapaN1");
    }

    IEnumerator WaterCoroutine()
    {
        playWaterSplash();

        //wait for 1 second.
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MapaN1");
    }

    private void playCrashSound()
    {
        if (crashSound != null) crashSound.Play();
    }

    private void playWaterSplash()
    {
        if (waterSplashSound != null) waterSplashSound.Play();
    }
}
