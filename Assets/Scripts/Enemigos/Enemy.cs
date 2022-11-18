using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad;
    void Update()
    {
        transform.Translate(0, 0, velocidad * Time.deltaTime);
    }
}
