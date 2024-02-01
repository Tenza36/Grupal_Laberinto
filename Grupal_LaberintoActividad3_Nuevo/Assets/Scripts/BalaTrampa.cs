using UnityEngine;

public class BalasTrampa : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡El jugador tocó la trampa!");
            // Colisionó con el jugador, reiniciar la escena o realizar alguna acción
            ReiniciarEscena2();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡El jugador tocó la trampa!");
            // Colisionó con el jugador, reiniciar la escena o realizar alguna acción
            ReiniciarEscena2();
        }
    }

    private void ReiniciarEscena2()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }


}
