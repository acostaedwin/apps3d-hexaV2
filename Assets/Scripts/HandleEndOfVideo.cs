using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandleEndOfVideo : MonoBehaviour
{
    public GameObject VideoTutorialObject;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartCountDownVideo()
    {
        // Debug.Log("VideoIntroObject: " + VideoIntroObject == null);
        StartCoroutine(WaitForTheEndOfVideo(16));
    }

    IEnumerator WaitForTheEndOfVideo(int seconds)
    {
        //waiting...
        yield return new WaitForSeconds(seconds);

        // SceneManager.LoadScene("MapaN1");
        GameObject VideoIntroObject = GameObject.Find("VideoIntro");
        VideoIntroObject.SetActive(false);
        VideoTutorialObject.SetActive(true);
    }
}
