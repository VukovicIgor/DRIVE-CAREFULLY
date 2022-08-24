using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolaIgraca : MonoBehaviour
{
    
    public GameObject auto;
    public WheelCollider PrednjaDesna;
    public WheelCollider PrednjaLeva;
    public WheelCollider ZadnjaDesna;
    public WheelCollider ZadnjaLeva;
    public Transform prednjaDesnaTransform;
    public Transform prednjaLevaTransform;
    public Transform zadnjaDesnaTransform;
    public Transform zadnjaLevaTransform;
    public Rigidbody rb;

    private float ubrzanje = 50000f;
    private float silaKocenja = 150000f;
    private float maxUgaoSkretanja = 15f;
    private Vector3 pozicija;

    [HideInInspector] public float trenutnoUbrzanje = 0f;
    [HideInInspector] public float trenutnaSilaKocenja = 0f;
    [HideInInspector] public float trenutniUgaoSkretanja = 0f;

    private void Start()
    {
        pozicija = auto.transform.position;
    }

    private void FixedUpdate()
    {
        if (GameManager.gameState == GameManager.GameState.kraj)
        {
            trenutnaSilaKocenja = 10000000000f * Time.deltaTime;
            trenutnoUbrzanje = 0f * Time.deltaTime;
        }
        if (GameManager.gameState == GameManager.GameState.voznja)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                trenutnaSilaKocenja = silaKocenja * 1000f * Time.deltaTime;
                trenutnoUbrzanje = 0f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                trenutnoUbrzanje = ubrzanje * 10f * Time.deltaTime;
                trenutnaSilaKocenja = 0f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
                trenutnaSilaKocenja = silaKocenja * 400f * Time.deltaTime;
            else
            {
                trenutnaSilaKocenja = 20000f * Time.deltaTime;
                trenutnoUbrzanje = 0f * Time.deltaTime;
            }

            PrednjaDesna.motorTorque = trenutnoUbrzanje;
            PrednjaLeva.motorTorque = trenutnoUbrzanje;

            PrednjaDesna.brakeTorque = trenutnaSilaKocenja;
            PrednjaLeva.brakeTorque = trenutnaSilaKocenja;
            ZadnjaDesna.brakeTorque = trenutnaSilaKocenja;
            ZadnjaLeva.brakeTorque = trenutnaSilaKocenja;

            trenutniUgaoSkretanja = maxUgaoSkretanja * Input.GetAxisRaw("Horizontal");
            PrednjaLeva.steerAngle = trenutniUgaoSkretanja;
            PrednjaDesna.steerAngle = trenutniUgaoSkretanja;

            OkretanjeTockova(PrednjaLeva, prednjaLevaTransform);
            OkretanjeTockova(PrednjaDesna, prednjaDesnaTransform);
            OkretanjeTockova(ZadnjaLeva, zadnjaLevaTransform);
            OkretanjeTockova(ZadnjaDesna, zadnjaDesnaTransform);
        }
    }

    private void OkretanjeTockova(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

    public void ResetVozila()
    {
        auto.transform.position = pozicija;
        auto.transform.rotation = Quaternion.Euler(0,0,0);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
    }
}
