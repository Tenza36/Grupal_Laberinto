using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarraHP : MonoBehaviour
{
    //creacion de variables

    public Image barraHP;
    public float vidaActual;
    public float vidaMaxima;
    public int Muertes;
    public Timer tiempoGuardar;
    public Puntuacion final;

    void Start()
    { 
        // Se guardan las variables que no se tienen que resetear cuando se resetea la escena
        Muertes = PlayerPrefs.GetInt("Muertes", 0);
        tiempoGuardar.tiempo = PlayerPrefs.GetFloat("tiempo", 0);
    }

    void Update()
    {
        if (final.Final == true) //Bool para que cuando se complete el nivel se reseteen las variables que guardabamos
        {
            PlayerPrefs.SetInt("Muertes", 0);
            PlayerPrefs.SetFloat("tiempo", 0);
            final.Final = false;
        }

        barraHP.fillAmount = vidaActual / vidaMaxima; //Calculo de cuanta vida tiene y se guarda en el fill del sprite para que baje la vida

        if (barraHP.fillAmount <= 0) // Comprueba si esta muerto
        {
            ReiniciarEscena(); //Llama al metodo ReiniciarEscena
        }
    }

    public void ReiniciarEscena() //Metodo que reinicia la escena cuando muere el jugador
    {
        Muertes++; // Se le suma una muerte al contador para calcular la puntuacion

        //Estas variables se guardan para cuando se reinicie la escena 
        PlayerPrefs.SetInt("Muertes", Muertes);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("tiempo", tiempoGuardar.tiempo);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reinicia la escena
    }
}
