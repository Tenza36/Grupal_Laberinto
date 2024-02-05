using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Patrullaje : MonoBehaviour
{
    //creacion de variables

    public Transform objetivo;
    public Transform inicio;
    public Transform mitad;
    public Transform final;
    public Transform enemigo;
    public Transform jugador;

    public LayerMask ElementoQueVeo;
    private NavMeshAgent agente;

    private bool persecucion = false;
    private bool vieneDeInicio = true;
    private bool estaMuerto = false;

    public float vidaActual;
    public float vidaMaxima;
    [SerializeField] float longitudrayo = 15f;
    private float tiempoAtaque = 0f;
    private float intervaloAtaque = 2.667f;
    public float x, y;

    public CasteoRayoLacer detectar;
    private Animator anim;
    public BarraHP VidaPlayer;
    public Image BarraHP2;
    public Canvas CanvasHP;

    void Start()
    {
        //Se inicializan los componentes necesarios para el correcto funcionamiento del enemigo
        agente = GetComponent<NavMeshAgent>();
        agente.stoppingDistance = 0;
        CanvasHP.enabled = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Llamada al metodo raycast
        Raycast(); 

        // Activar el modo de persecuccion
        if (persecucion)    
        {
            perseguirPersonaje(); // Llamada al metodo persecucion
        }
        
        Morir(); //Llamada al metodo morir
        
        patrullaje(); //Llamada al metodo patrullaje

        BarraHP2.fillAmount = vidaActual / vidaMaxima; //Actualiza la barra de vida del enemigo

        //Daño que le hace el arma al enemigo cuando le impacta el disparo
        if (detectar.Detectado == true)
        {
            vidaActual = vidaActual - 10;
            detectar.Detectado = false;

            //Detecta cuando al enemigo no le queda vida
            if (vidaActual <= 0)
            {
                estaMuerto = true;
                // Dejar de perseguir al jugador cuando muere
                persecucion = false;
            }
        }
        //Si el jugador se encuentra a una distancia menor de la de parada del enemigo
        if (Vector3.Distance(enemigo.position, jugador.position) <= agente.stoppingDistance && !estaMuerto)
        {
            Ataque(); //Llama al metodo ataque
        }


    }
    private void perseguirPersonaje() //Metodo que ejecuta la persecucion del enemigo al jugador
    {
        //Se le asigna la posicion del jugador como destino
        agente.destination = objetivo.position;
        agente.stoppingDistance = 5;
    }
    private void Raycast() //Metodo que crea el rayo que detecta al jugador para iniciar la persecucion
    {
        Ray ray = new Ray(transform.position, transform.forward); //Lanza un rayo hacia el frente
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * longitudrayo, Color.red); //Propiedades del rayo
        //Se activa el estado de persecucion y la barra de vida del enemigo cuando detecta "ElementoQueVeo"
        if (Physics.Raycast(ray, out hit, longitudrayo, ElementoQueVeo) && persecucion == false)
        {
            persecucion = true;
            CanvasHP.enabled = true;

        }
    }
    private void patrullaje() //Metodo que ajusta el comportamiento del enemigo en su estado de patrullaje
    {
        float tolerancia = 0.1f; //Tolerancia a que los decimales de los waypoints no sean exactamente los del enemigo y los detecte correctamente

        // Aqui se establece la ruta que sigue el enemigo a traves de los distintos waypoints
        if (persecucion == false && Vector3.Distance(enemigo.position, inicio.position) < tolerancia)
        {

            agente.destination = mitad.position;
            vieneDeInicio = true;


        }
        if (persecucion == false && Vector3.Distance(enemigo.position, final.position) < tolerancia)
        {
            agente.destination = mitad.position;
            vieneDeInicio = false;

        }
        if (persecucion == false && Vector3.Distance(enemigo.position, mitad.position) < tolerancia)
        {
            if (vieneDeInicio)
            {
                agente.destination = final.position;
            }
            else
            {
                agente.destination = inicio.position;
            }


        }
        
        //Variables para el funcionamiento de las animaciones de movimiento
        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);
    }

    private void Ataque() // Metodo que permite al enemigo ejecutar ataques
    {
        if (Time.time >= tiempoAtaque) //Se ejecuta cada intervalo de tiempo establecido
        {
            anim.Play("Mutant Swiping"); //Se reproduce la animacion de ataque
            Invoke("BajarVidaPersonaje", 1.09f); //Se llama al metodo "BajarVidaPersonaje"
            tiempoAtaque = Time.time + intervaloAtaque; //Ajuste para reiniciar el bucle de tiempo del ataque
        }
    }


    private void Morir() // Metodo que gestiona la muerte del enemigo
    {
        if (estaMuerto)
        {
            // Realizar acciones de muerte (rotación, animación, destrucción, etc.)
            transform.LookAt(transform.position + Vector3.right);
            anim.Play("Mutant Dying"); //Se reproduce la animacion de muerte
            Destroy(this.gameObject, 2.5f); //Se elimina al enemigo de la escena
            agente.destination = agente.transform.position;
        }

    }
    private void BajarVidaPersonaje() //Establece el daño que recibe el jugador del enemigo
    {
        VidaPlayer.vidaActual = VidaPlayer.vidaActual - 33.34f;
    }
}