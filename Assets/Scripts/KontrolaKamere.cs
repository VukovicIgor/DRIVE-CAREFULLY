using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolaKamere : MonoBehaviour
{
    private int brojac=0;
    public Camera GlavnaKamera;
    public Camera Retrovizor;
    public GameObject nebo;
    private Vector3 trenutnaPozicija;
    void Start()
    {
        if (GameManager.noc)
        {
            GlavnaKamera.clearFlags = CameraClearFlags.SolidColor;
            GlavnaKamera.backgroundColor = Color.black;
            Retrovizor.clearFlags = CameraClearFlags.SolidColor;
            Retrovizor.backgroundColor = Color.black;
            nebo.transform.rotation=Quaternion.Euler(345.100006f, 178.5f, 188.5f);
        }
        else
        {
            nebo.transform.rotation = Quaternion.Euler(50f, 330f, 0f);
        }
        trenutnaPozicija = GlavnaKamera.transform.localPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) )
        {
            PromenaPozicije();
        }
        if (Input.GetKey(KeyCode.V))
        {
            GlavnaKamera.transform.localPosition = new Vector3(1.75f, 2.26000118f, -2.32800007f);
            GlavnaKamera.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            GlavnaKamera.transform.localPosition = trenutnaPozicija;
            GlavnaKamera.transform.localRotation = Quaternion.Euler(0, 0, 0); 
        }
    }

    private void PromenaPozicije()
    {
        switch (brojac)
        {
            case 0:
                GlavnaKamera.transform.localPosition = new Vector3(1.75f, 2.26000118f, -6.82700014f);
                trenutnaPozicija = GlavnaKamera.transform.localPosition;
                brojac = 1;
                break;
            case 1:
                GlavnaKamera.transform.localPosition = new Vector3(1.75f, 2.26000118f, -7.66300011f);
                trenutnaPozicija = GlavnaKamera.transform.localPosition;
                brojac = 2;
                break;
            case 2:
                GlavnaKamera.transform.localPosition = new Vector3(1.75f, 0.356000006f, 2.5f);
                trenutnaPozicija = GlavnaKamera.transform.localPosition;
                brojac = 3;
                break;
            case 3:
                GlavnaKamera.transform.localPosition = new Vector3(1.75f, 1.01900005f, 0.786000013f);
                trenutnaPozicija = GlavnaKamera.transform.localPosition;
                brojac = 4;
                break;
            case 4:
                GlavnaKamera.transform.localPosition = new Vector3(1.43200004f, 0.870000005f, -0.0599999987f);
                trenutnaPozicija = GlavnaKamera.transform.localPosition;
                brojac = 5;
                break;
            case 5:
                GlavnaKamera.transform.localPosition = new Vector3(1.75f, 2.26000118f, -5.98002529f);
                trenutnaPozicija = GlavnaKamera.transform.localPosition;
                brojac = 0;
                break;
        }
    }
}
