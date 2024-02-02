using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public Canvas Canvas1;
    public Canvas Canvas2;
    public Canvas Canvas3;
    public bool Final = false;
    private int PuntuacionFinal = 0;

    public Timer tiempo;
    public BarraHP muertes;

    public TextMeshProUGUI texto;

    private void Start()
    {
        Canvas2.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Canvas1.enabled = false;
            Canvas3.enabled = false;
            Canvas2.enabled = true;
            calcularPuntuacion();
        }
    }

    private void calcularPuntuacion()
    {
        Final = true;
        if (tiempo.tiempo < 60)
        {
            PuntuacionFinal = PuntuacionFinal + 10;
        }
        else if (tiempo.tiempo > 60 && tiempo.tiempo < 70)
        {
            PuntuacionFinal = PuntuacionFinal + 9;
        }
        else if (tiempo.tiempo > 70 && tiempo.tiempo < 80)
        {
            PuntuacionFinal = PuntuacionFinal + 8;
        }
        else if (tiempo.tiempo > 80)
        {
            PuntuacionFinal = PuntuacionFinal + 7;
        }

        PuntuacionFinal = PuntuacionFinal - muertes.Muertes;

        if (PuntuacionFinal < 0)
        {
            PuntuacionFinal = 0;
        }

        texto.text = "Puntuación: " + PuntuacionFinal.ToString() + "/10";
    }
}