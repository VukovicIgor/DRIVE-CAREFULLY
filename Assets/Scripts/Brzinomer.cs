using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brzinomer : MonoBehaviour
{
    public RectTransform strelica;
    public Rigidbody rb;
    private float maxBrzina = 260f;
    private float minUgaoStrelice = 13.6f;
    private float maxUgaoStrelice = -193.2f;

    private float speed;
    private void Update()
    {
        speed = rb.velocity.magnitude * 3.4f;
        strelica.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minUgaoStrelice, maxUgaoStrelice, speed / maxBrzina));
    }
}
