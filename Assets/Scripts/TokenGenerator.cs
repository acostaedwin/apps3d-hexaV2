using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenGenerator : MonoBehaviour
{
    public GameObject tokenModel;

    private int amountOfTokens;

    private int startAmountOfTokens = 8;

    private Vector3 minRange = new Vector3(10.48642f, -1f, 0.637f);

    private Vector3 maxRange = new Vector3(23.10193f, 1f, 51.9628f);

    // Start is called before the first frame update
    void Start()
    {
        if (GameInformationData.currentLevel == 0)
            amountOfTokens = startAmountOfTokens;
        else
        {
            amountOfTokens =
                startAmountOfTokens + GameInformationData.currentLevel * 2;
        }
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
            Vector3 newPosition =
                new Vector3(child.transform.position.x + 0.597f,
                    child.transform.position.y + 0.5f,
                    child.transform.position.z + 0.9221f);
            if (isVectorBetween(newPosition, minRange, maxRange))
            {
                Instantiate(tokenModel, newPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(tokenModel,
                getRandomVector3(minRange, maxRange),
                Quaternion.identity);
            }
            // Instantiate(tokenModel, newPosition, child.transform.localRotation);
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

    private bool isVectorBetween(Vector3 vector, Vector3 min, Vector3 max)
    {
        return vector.x >= min.x &&
        vector.x <= max.x &&
        vector.y >= min.y &&
        vector.y <= max.y &&
        vector.z >= min.z &&
        vector.z <= max.z;
    }

    private Vector3 getRandomVector3(Vector3 min, Vector3 max)
    {
        return new Vector3(Random.Range(min.x, max.x),
            0.8f,
            Random.Range(min.z, max.z));
    }
}
