using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Svetla : MonoBehaviour
{
    private Light svetlo;

    public void Start()
    {
        if (GameManager.noc)
        {
            this.GetComponent<Light>().enabled = true;
        }
        else
        {
            this.GetComponent<Light>().enabled = false;
        }
    }
}
