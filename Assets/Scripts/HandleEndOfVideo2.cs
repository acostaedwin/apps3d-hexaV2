using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandleEndOfVideo2 : MonoBehaviour
{
    // Start is called before the first frame update
    private float delay = 5;

    private bool isReadyForSkip;

    public void FixedUpdate()
    {
        if (delay > 0)
        {
            delay -= Time.fixedDeltaTime;

            if (delay <= 0)
            {
                isReadyForSkip = true;
            }
        }
    }

    void Start()
    {
        StartCoroutine(WaitForTheEndOfVideo(30));
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDoubleTap() && isReadyForSkip)
        {
            SceneManager.LoadScene("MapaN1");
        }
    }

    IEnumerator WaitForTheEndOfVideo(int seconds)
    {
        //waiting...
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("MapaN1");
    }

    public static bool IsDoubleTap()
    {
        try
        {
            if (Input.GetTouch(0).tapCount == 2)
            {
                return true;
            }
            return false;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
}
