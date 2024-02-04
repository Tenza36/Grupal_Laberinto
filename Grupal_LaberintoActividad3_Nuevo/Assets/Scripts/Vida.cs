/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Vida : MonoBehaviour
{
    public float vidaInicial;
    public float vidaActual;
    public Animator animator;
    void Start()
    {
        vidaActual = vidaInicial;
    }
    public void CausarDaño(float cuanto)
    {
        vidaActual-=cuanto;
        if (vidaActual <= 0)
        {
            print("Muerto!!! -> " + gameObject.name);
            

            if (animator != null)
            {
                animator.Play("Mutant Dying"); // Ajusta el nombre del trigger según la configuración de tu animador
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}*/


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vida : MonoBehaviour
{
    public float vidaInicial;
    public float vidaActual;
    public UnityEvent eventoMorir;
    public Animator animator;

    // Agrega una referencia al script EnemigoOrco
   

    void Start()
    {
        vidaActual = vidaInicial;
    }

   

    public void CausarDaño(float cuanto)
    {
        vidaActual -= cuanto;
        if (vidaActual <= 0)
        {
            print("Muerto!!! -> " + gameObject.name);
            eventoMorir.Invoke();

        }
    }

}*/
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Vida : MonoBehaviour
{
    public float vidaInicial;
    public float vidaActual;
    public UnityEvent eventoMorir;
    public Animator animator;

    private Vector3 posicionInicial;

    void Start()
    {
        vidaActual = vidaInicial;
        posicionInicial = transform.position;
        Debug.Log("Posición inicial: " + posicionInicial);
    }

    public void CausarDaño(float cuanto)
    {
        vidaActual -= cuanto;

        if (vidaActual <= 0)
        {
            StartCoroutine(RestaurarPosicionDespuesDeTiempo(0.1f)); // Ajusta este valor según tus necesidades
            Debug.Log("Muerto!!! -> " + gameObject.name);
            eventoMorir.Invoke();
        }
    }

    IEnumerator RestaurarPosicionDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        transform.position = posicionInicial;
        Debug.Log("Restableciendo posición a la inicial: " + transform.position);
    }
}