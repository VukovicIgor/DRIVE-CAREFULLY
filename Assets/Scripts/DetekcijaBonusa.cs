using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetekcijaBonusa : MonoBehaviour
{
    public GameManager gameManager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bonus")
            gameManager.DetekcijaBonusa();
    }
}