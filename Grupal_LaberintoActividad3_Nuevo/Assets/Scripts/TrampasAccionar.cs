using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampasAccionar : MonoBehaviour
{
    public Animator TrampasGeneral;
    public void OnTriggerEnter(Collider other)
    {
        TrampasGeneral.Play("Arriba");
    }
    public void OnTriggerExit(Collider other)
    {
        TrampasGeneral.Play("Abajo");
    }

}