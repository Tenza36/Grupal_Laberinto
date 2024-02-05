using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    //creacion de variables

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
        Canvas2.enabled = false; //Desactiva el canvas de puntuacion al iniciar la partida
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //Detecta cuando el jugador llega a la meta
        {
            //Desactiva los canvas anteriores y muestra el de puntuacion
            Canvas1.enabled = false;
            Canvas3.enabled = false;
            Canvas2.enabled = true;
            calcularPuntuacion(); // Llamada al metodo calcularPuntuacion
        }
    }

    private void calcularPuntuacion()
    {
        Final = true; // Bool para que se reseteen las variables guardadas
        
        //Calculos que determinan tu puntuacion final en funcion del tiempo
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

        

        PuntuacionFinal = PuntuacionFinal - muertes.Muertes; //Calculo que determina tu puntuacion final en funcion de las muertes

        if (PuntuacionFinal < 0) // Evita que puedas obtener una puntuacion negativa
        {
            PuntuacionFinal = 0;
        }

        texto.text = "Puntuación: " + PuntuacionFinal.ToString() + "/10"; //Transforma la puntuacion a String y la guarda en el texto
    }
}