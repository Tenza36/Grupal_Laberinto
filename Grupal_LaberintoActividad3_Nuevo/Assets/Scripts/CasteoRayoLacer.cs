

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasteoRayoLacer : MonoBehaviour
{
    public Camera playerCamera;
    public Transform LaserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;
    float fireTimer;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0;

            // Utiliza LaserOrigin.position como punto de inicio del rayo
            Vector3 rayOrigin = LaserOrigin.position;

            laserLine.SetPosition(0, rayOrigin);
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                AbrirPuertas abrirPuertas = hit.transform.GetComponent<AbrirPuertas>();
                if (abrirPuertas != null)
                {
                    abrirPuertas.OnTriggerEnter(hit.collider); // Pasa el collider relevante
                }
                laserLine.SetPosition(1, hit.point);
            }
            else
            {
                // Si no hay colisión, puedes hacer algo aquí si es necesario
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
}*/
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

    LineRenderer laserLine;
    float fireTimer;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0;

            // Utiliza LaserOrigin.position como punto de inicio del rayo
            Vector3 rayOrigin = LaserOrigin.position;

            laserLine.SetPosition(0, rayOrigin);
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                // Verifica si el objeto impactado tiene un componente de vida
                Vida vidaEnemigo = hit.transform.GetComponent<Vida>();
                if (vidaEnemigo != null)
                {
                    // Causa daño al enemigo
                    vidaEnemigo.CausarDaño(3f); // Ajusta el valor de daño según tus necesidades
                }

                AbrirPuertas abrirPuertas = hit.transform.GetComponent<AbrirPuertas>();
                if (abrirPuertas != null)
                {
                    abrirPuertas.OnTriggerEnter(hit.collider); // Pasa el collider relevante
                }
                laserLine.SetPosition(1, hit.point);
            }
            else
            {
                // Si no hay colisión, puedes hacer algo aquí si es necesario
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