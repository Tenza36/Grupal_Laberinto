using UnityEngine;

public class Trampa : MonoBehaviour
{
    public BarraHP hp;

    void Start()
    {
        // Busca la instancia de BarraHP al inicio
        hp = FindObjectOfType<BarraHP>();

        if (hp == null)
        {
            Debug.LogError("No se encontró la instancia de BarraHP. Asegúrate de que BarraHP esté presente en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡El jugador tocó la trampa!");
            // Colisionó con el jugador, reiniciar la escena o realizar alguna acción
            hp.vidaActual = hp.vidaActual - 10;
        }
    }

}