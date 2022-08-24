using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetekcijaUdesa : MonoBehaviour
{
    public GameManager gameManager;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag!="Podloga")
            gameManager.Udes();
    }
}
