using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterColliderHandle : MonoBehaviour
{
    public AudioSource crashSound;

    public AudioSource waterSplashSound;

    public AudioSource ouchSound;

    public AudioSource coinCollectedSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "token")
        {
            other.gameObject.SetActive(false);
            playSound (coinCollectedSound);
        }
        // Debug.Log("other.tag: " + other.tag);
        // Debug.Log("other.gameObject: " + other.gameObject.tag);
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
        if (collision.gameObject.tag == "hell")
        {
            StartCoroutine(OutOfMapCoroutine());
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

    IEnumerator OutOfMapCoroutine()
    {
        playSound (ouchSound);

        //wait for 1 second.
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MapaN1");
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

    private void playSound(AudioSource sound)
    {
        if (sound != null) sound.Play();
    }
}
