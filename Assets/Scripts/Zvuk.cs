using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zvuk : MonoBehaviour
{
    private AudioSource izvor;

    void Awake()
    {
        izvor = GetComponent<AudioSource>();
    }

    public void DodatnoVreme()
    {
        izvor.Play();
    }
}
