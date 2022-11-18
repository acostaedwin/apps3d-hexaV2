using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad;

    void Start()
    {
        if (velocidad == -1) velocidad = Random.Range(2f, 10f);
    }

    void Update()
    {
        transform.Translate(0, 0, velocidad * Time.deltaTime);
    }
}
