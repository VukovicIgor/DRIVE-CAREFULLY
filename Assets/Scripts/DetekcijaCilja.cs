using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetekcijaCilja : MonoBehaviour
{
    public GameManager gameManager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cilj")
            gameManager.Cilj();
    }
}
