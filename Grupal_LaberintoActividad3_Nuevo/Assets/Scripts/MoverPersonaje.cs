
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public CharacterController Controlador;

    public float Velocidad = 15f;
    public float Gravedad = -10;

    public Transform EnElPiso;
    public float DistanciaDelPiso;
    public LayerMask MascaraDelPiso;
    private Animator anim;

    Vector3 VelocidadAbajo;
    bool EstaEnElPiso;
    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        EstaEnElPiso = Physics.CheckSphere(EnElPiso.position, DistanciaDelPiso, MascaraDelPiso);
        if (EstaEnElPiso && VelocidadAbajo.y < 0)
        {
            VelocidadAbajo.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Obtener la rotación actual de la cámara
        Quaternion camaraRotacion = Camera.main.transform.rotation;

        // Obtener la dirección de movimiento en el plano horizontal
        Vector3 mover = Quaternion.Euler(0, camaraRotacion.eulerAngles.y, 0) * new Vector3(x, 0, z);

        // Mover el personaje en la dirección de la cámara
        Controlador.Move(mover * Velocidad * Time.deltaTime);

        VelocidadAbajo.y += Gravedad * Time.deltaTime;

        // Mover hacia abajo (gravedad)
        Controlador.Move(VelocidadAbajo * Time.deltaTime);

        anim.SetFloat("Velx", x);
        anim.SetFloat("Vely", z); 
    }
}
