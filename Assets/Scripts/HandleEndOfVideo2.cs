using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandleEndOfVideo2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForTheEndOfVideo(30));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator WaitForTheEndOfVideo(int seconds)
    {
        //waiting...
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("MapaN1");
    }
}
