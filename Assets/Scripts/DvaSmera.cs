using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DvaSmera : MonoBehaviour
{
    private float brzina = 0.1f;
    public GameManager gameManager;
    public GameObject[] DesnaTraka;
    public GameObject[] LevaTraka;
    public GameObject[] Tragaci;
    void Update()
    {
        if (GameManager.gameState == GameManager.GameState.voznja)
        {
            KretanjeLeveTrake();
            KretanjeDesneTrake();
        }
    }
    public void Reset()
    {
        for (int i = 0; i < LevaTraka.Length; i++)
        {
            LevaTraka[i].transform.localPosition = new Vector3(0, 0, 0);
        }
        for (int i = 0; i < DesnaTraka.Length; i++)
        {
            DesnaTraka[i].transform.localPosition = new Vector3(0, 0, 0);
        }
        for (int i = 0; i < Tragaci.Length; i++)
        {
            Tragaci[i].transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    private void KretanjeLeveTrake()
    {
        for (int i = 0; i < LevaTraka.Length; i++)
        {
            float PosZ = LevaTraka[i].transform.position.z;
            PosZ -= brzina * Time.deltaTime * 30;
            LevaTraka[i].transform.position = new Vector3(transform.position.x, transform.position.y, PosZ);
        }
    }
    private void KretanjeDesneTrake()
    {
        for (int i = 0; i < DesnaTraka.Length; i++)
        {
            float PosZ = DesnaTraka[i].transform.position.z;
            PosZ += brzina * Time.deltaTime * 30;
            DesnaTraka[i].transform.position = new Vector3(transform.position.x, transform.position.y, PosZ);
        }
        for (int i = 0; i < Tragaci.Length; i++)
        {
            float PosZ = Tragaci[i].transform.position.z;
            PosZ += brzina * Time.deltaTime * 45;
            Tragaci[i].transform.position = new Vector3(transform.position.x, transform.position.y, PosZ);
        }
    }
}
