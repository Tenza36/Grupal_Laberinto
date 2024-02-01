using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Enemigo : MonoBehaviour

{
    public Estados estado;
    public float distanciaSeguir;
    public float distanciaAtacar;
    public float distanciaEscapar;

    public bool autoseleccionarTarget = true;
    public Transform target;
    public float distancia;

    public bool vivo = true;

    private void Awake()
    {
        if (autoseleccionarTarget)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            StartCoroutine(CalcularDistancia());

        }
    }

    private void LateUpdate()
    {
        CheckEStado();
    }

    public void CheckEStado()
    {
        switch (estado)
        {
            case Estados.idle:
                EstadoIdle();
                break;
            case Estados.seguir:
                EstadoSeguir();
                break;
            case Estados.atacar:
                EstadoAtacar();
                break;
            case Estados.muerto:             
                EstadoMuerto();
                break;
            default:
                break;
        }
    } 

    public void CambiarEstado(Estados e)
    {
        switch (e)
        {
            case Estados.idle:
                break;
            case Estados.seguir:
                break;
            case Estados.atacar: 
                break;
            case Estados.muerto:
                vivo = false;
                break;
            default:
                break;
        }
        estado = e;
    }
    public virtual void EstadoIdle()
    {
        if (distancia < distanciaSeguir)
        {
            CambiarEstado(Estados.seguir);
        }
    }
    public virtual void EstadoSeguir()
    {
        if (distancia < distanciaAtacar)
        {
            CambiarEstado(Estados.atacar);
        }
        else if(distancia > distanciaEscapar)
        {
            CambiarEstado(Estados.idle);
        }

    }
    public virtual void EstadoAtacar()
    {
        if(distancia>distanciaAtacar + 0.4f)
        {
            CambiarEstado(Estados.seguir);
        }

    }
    public virtual void EstadoMuerto()
    {

    }
    IEnumerator CalcularDistancia()
    {
        while (vivo)
        {
            if(target != null)
            {
                distancia=Vector3.Distance(transform.position, target.position);
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, distanciaAtacar);
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.up, distanciaSeguir);
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, Vector3.up, distanciaEscapar);
        
    }
#endif

    private void OnDrawGizmos()
    {
        int icono = (int)estado;
        icono++;

        Gizmos.DrawIcon(transform.position + Vector3.up * 2.5f, "0"+icono+".png");
    }

    // Update is called once per frame
    public enum Estados
    {
        idle   = 0,
        seguir = 1,
        atacar = 2,
        muerto = 3
    }

}
