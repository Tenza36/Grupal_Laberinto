using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Patrullaje : MonoBehaviour
{
    public Transform objetivo;
    private NavMeshAgent agente;
    public Transform enemigo;
    [SerializeField] float longitudrayo = 15f;
    public LayerMask ElementoQueVeo;
    private bool persecucion = false;
    public Transform inicio;
    public Transform mitad;
    public Transform final;
    private bool vieneDeInicio = true;
    public Image BarraHP2;
    public Canvas CanvasHP;
    public float vidaActual;
    public float vidaMaxima;
    public CasteoRayoLacer detectar;
    public BarraHP VidaPlayer;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.stoppingDistance = 0;
        CanvasHP.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
        if (persecucion)
        {
            perseguirPersonaje();
        }
        patrullaje();

        BarraHP2.fillAmount = vidaActual / vidaMaxima;

        if (detectar.Detectado == true)
        {
            vidaActual = vidaActual - 10;
            detectar.Detectado = false;
        }

        Morir();
    }
    private void perseguirPersonaje()
    {
        agente.destination = objetivo.position;
        agente.stoppingDistance = 5;
    }
    private void Raycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * longitudrayo, Color.red);
        if (Physics.Raycast(ray, out hit, longitudrayo, ElementoQueVeo) && persecucion == false) // Variable name corrected
        {
            persecucion = true;
            CanvasHP.enabled = true;

        }
    }
    private void patrullaje()
    {
        float tolerancia = 0.1f; // puedes ajustar este valor seg�n tus necesidades

        if (persecucion == false && Vector3.Distance(enemigo.position, inicio.position) < tolerancia)
        {

            agente.destination = mitad.position;
            vieneDeInicio = true;
            Debug.Log("AAA");
            

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
    }

    private void Ataque()
    {
        VidaPlayer.vidaActual = VidaPlayer.vidaActual - 10;
    }

    private void Morir()
    {
        if (vidaActual <= 0)
        {
            Destroy(this.gameObject, 0.5f);
        }
    }

}
