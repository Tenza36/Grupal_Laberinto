using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbrirPuertas : MonoBehaviour
{
    public Material open;
    [SerializeField]private Material closed;
    private Renderer renderer;
    public Animator PuertasGeneral;
    public void OnTriggerEnter(Collider other)
    {
        PuertasGeneral.SetTrigger("isOpen");
        if (renderer != null)
        {
            renderer.material = open;
            StartCoroutine(Shoot());
            
        }
    }

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            closed = renderer.material;

        }
        else
        {
            Debug.LogError("El objeto no tiene un Renderer.");
        }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2);
        if (renderer != null)
        {
            renderer.material = closed;
        }
    }
 }
