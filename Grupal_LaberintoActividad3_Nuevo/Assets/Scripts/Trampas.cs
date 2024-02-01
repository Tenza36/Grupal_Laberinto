using UnityEngine;

public class Trampa : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡El jugador tocó la trampa!");
            // Colisionó con el jugador, reiniciar la escena o realizar alguna acción
            ReiniciarEscena();
        }
    }

    private void ReiniciarEscena()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }


}