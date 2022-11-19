using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenGenerator : MonoBehaviour
{
    public GameObject tokenModel;

    public int amountOfTokens;

    // Start is called before the first frame update
    void Start()
    {
        if (amountOfTokens == 0) amountOfTokens = 5;
        GenerateTokens();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //  we seach all field object and we put the token on one of them randomly
    void GenerateTokens()
    {
        int[] numbers = new int[amountOfTokens];
        for (int i = 0; i < amountOfTokens; i++)
        {
            numbers[i] =
                getDifferentRandomNumber(0, transform.childCount, numbers); // we fill the array with random numbers
        }

        // Debug.Log("numbers: " + string.Join(", ", numbers));
        for (int i = 0; i < numbers.Length; i++)
        {
            Transform child = transform.GetChild(numbers[i]);

            // Debug.Log("child: " + child.name);
            Instantiate(tokenModel,
            new Vector3(child.transform.position.x + 0.597f,
                child.transform.position.y + 0.5f,
                child.transform.position.z + 0.9221f),
            child.transform.localRotation);
        }

        /*
        foreach (Transform child in transform)
        {
            if (
                child.name == "pCylinder200" ||
                child.name == "pCylinder204" ||
                child.name == "pCylinder209"
            )
            {
                Instantiate(tokenModel,
                new Vector3(child.transform.position.x + 0.597f,
                    child.transform.position.y + 0.5f,
                    child.transform.position.z + 0.9221f),
                child.transform.localRotation);

                // Debug.Log("child.name: " + );
                // child.gameObject.SetActive(false);
            }
        }
        */
    }

    int getDifferentRandomNumber(int min, int max, int[] numbers)
    {
        int randomNumber = Random.Range(min, max);
        for (int i = 0; i < numbers.Length; i++)
        {
            if (randomNumber == numbers[i])
            {
                randomNumber = getDifferentRandomNumber(min, max, numbers);
            }
        }
        return randomNumber;
    }
}
