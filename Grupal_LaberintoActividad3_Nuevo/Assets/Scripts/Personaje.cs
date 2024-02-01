using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Personaje : MonoBehaviour
{
    public static Personaje singlenton;
    public Vida vida;

    private void Awake()
    {
        if(singlenton == null)
        {
            singlenton = this;
        }
        else { 
  
            DestroyImmediate(this.gameObject);
        }
    } 
}

