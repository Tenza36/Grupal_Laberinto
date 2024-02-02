using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarraHP : MonoBehaviour
{
    public Image barraHP;
    public float vidaActual;
    public float vidaMaxima;
    public int Muertes;
    public Timer tiempoGuardar;
    public Puntuacion final;

    void Start()
    { 
        Muertes = PlayerPrefs.GetInt("Muertes", 0);
        tiempoGuardar.tiempo = PlayerPrefs.GetFloat("tiempo", 0);
    }

    void Update()
    {
        if (final.Final == true)
        {
            PlayerPrefs.SetInt("Muertes", 0);
            PlayerPrefs.SetFloat("tiempo", 0);
            final.Final = false;
        }

        barraHP.fillAmount = vidaActual / vidaMaxima;

        if (barraHP.fillAmount <= 0)
        {
            ReiniciarEscena();
        }
    }

    public void ReiniciarEscena()
    {
        Muertes++;

        PlayerPrefs.SetInt("Muertes", Muertes);
        PlayerPrefs.Save();

        PlayerPrefs.SetFloat("tiempo", tiempoGuardar.tiempo);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
