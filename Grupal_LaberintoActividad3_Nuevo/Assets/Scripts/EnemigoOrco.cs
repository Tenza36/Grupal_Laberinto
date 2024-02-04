using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemigoOrco : Enemigo
{
    public NavMeshAgent agente;
    public Animator animaciones;
    public float daño = 3;
    private Vida vida;
    private Quaternion ultimaRotacion;
    private bool rotacionActualizada = false;

    private void Awake()
    {
        base.Awake();
        agente = GetComponent<NavMeshAgent>();
        vida = GetComponent<Vida>();
        
    }
    public override void EstadoIdle()
    {
        base.EstadoIdle();
       if(animaciones!=null) animaciones.SetFloat("velocidad", 0);
       if (animaciones != null)  animaciones.SetBool("atacando", false);
       agente.SetDestination(transform.position);
        
       // transform.LookAt(transform.position + Vector3.right);
    }

    public override void EstadoSeguir()
    {
       
     base.EstadoSeguir();
     if(animaciones!=null) animaciones.SetFloat("velocidad", 1);
     if(animaciones!=null) animaciones.SetBool("atacando", false);
     agente.SetDestination(target.position);
    // transform.LookAt(transform.position + Vector3.right);
}
    public override void EstadoAtacar()
    {
        base.EstadoAtacar();
        if(animaciones!=null) animaciones.SetFloat("velocidad", 0);
        if(animaciones!=null) animaciones.SetBool("atacando", true);
        agente.SetDestination(transform.position);
        transform.LookAt(target, Vector3.up);

    }
    public override void EstadoMuerto()
    {
      


         base.EstadoMuerto();
         if (animaciones != null) animaciones.SetBool("vivo", false);

         // Detener el NavMeshAgent cuando el enemigo muere
         if (agente != null)
         {
             agente.isStopped = true;
             agente.velocity = Vector3.zero;
            
            
        }



    }


    [ContextMenu("Matar")]
    public void Matar()
    {
        CambiarEstado(Estados.muerto);
    }
    public void Atacar()
    {
        Personaje.singlenton.vida.CausarDaño(daño);
    }
}

