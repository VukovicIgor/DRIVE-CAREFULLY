using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JedanSmer : MonoBehaviour
{
    private float brzina = 0.1f;
    public GameManager gameManager;
    public GameObject[] vozila;
    public GameObject[] Tragaci;

    void Update()
    {
        if (GameManager.gameState == GameManager.GameState.voznja)
            Kretanje();
    }
    public void Reset()
    {
        for (int i = 0; i < vozila.Length; i++)
        {
            vozila[i].transform.localPosition = new Vector3(0, 0, 0);
        }
        for (int i = 0; i < Tragaci.Length; i++)
        {
            Tragaci[i].transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    private void Kretanje()
    {
        for (int i = 0; i < vozila.Length; i++)
        {
            float PosZ = vozila[i].transform.position.z;
            PosZ += brzina * Time.deltaTime * 30;
            vozila[i].transform.position = new Vector3(transform.position.x, transform.position.y, PosZ);
        }
        for (int i = 0; i < Tragaci.Length; i++)
        {
            float PosZ = Tragaci[i].transform.position.z;
            PosZ += brzina * Time.deltaTime * 45;
            Tragaci[i].transform.position = new Vector3(transform.position.x, transform.position.y, PosZ);
        }
    }
}
