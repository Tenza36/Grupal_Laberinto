using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float tiempo = 0;
    public TextMeshProUGUI texto;

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        texto.text = "Tiempo: " + tiempo.ToString("f0");
    }
}
