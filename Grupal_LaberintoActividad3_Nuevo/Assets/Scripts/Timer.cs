using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    //creacion de variables

    public float tiempo = 0;
    public TextMeshProUGUI texto;

    void Update()
    {
        tiempo += Time.deltaTime; // Calcular el tiempo
        texto.text = "Tiempo: " + tiempo.ToString("f0"); //Se representa el tiempo mediante el texto. El f0 hace que muestre solo el numero entero
    }
}
