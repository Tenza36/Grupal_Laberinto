using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasteoRayoLacer : MonoBehaviour
{
    public Camera playerCamera;
    public Transform LaserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;
    public Patrullaje Enemigo;  // Declarar una referencia a Patrullaje
    public bool Detectado = false;
    LineRenderer laserLine;
    float fireTimer;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        Enemigo = GetComponent<Patrullaje>();
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0;

            Vector3 rayOrigin = LaserOrigin.position;

            laserLine.SetPosition(0, rayOrigin);
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange)) // Lanza el rayo
            {
                if (hit.collider.CompareTag("Enemigo")) // Comprueba si tiene el tag enemigo
                {
                    Debug.Log("Enemigo Detectado");
                    Detectado = true; //El rayo detecta al objetivo y aplica el estado Detectado
                }
            }

            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange)) // Funcionamiento para que el raycast abra las puertas del laberinto
            {
                // Crea un objeto de la clase "AbrirPuertas" en el que almacena la componente del objeto que colisiona con el rayo AbrirPuertas
                AbrirPuertas abrirPuertas = hit.collider.GetComponent<AbrirPuertas>(); 
                if (abrirPuertas != null) // Se ejecuta la funcion del objeto si no es nulo
                {
                    abrirPuertas.OnTriggerEnter(hit.collider);
                }
                laserLine.SetPosition(1, hit.point);
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
            StartCoroutine(ShootLaser());
        }
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }


}
