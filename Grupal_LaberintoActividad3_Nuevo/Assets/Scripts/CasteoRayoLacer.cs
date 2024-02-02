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
        laserLine=GetComponent<LineRenderer>();
    }
    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && fireTimer>fireRate) {
            fireTimer = 0;
            laserLine.SetPosition(0, LaserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);
                Destroy(hit.transform.gameObject);

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
}*/
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
                    abrirPuertas.OnTriggerEnter(null); // Llama a OnTriggerEnter del botón
                }
                laserLine.SetPosition(1, hit.point);
                
            }
            else
            {
                // Llama a OnTriggerExit del botón
                AbrirPuertas abrirPuertas = hit.transform.GetComponent<AbrirPuertas>();
                if (abrirPuertas != null)
                {
                    abrirPuertas.OnTriggerExit(null);
                }

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
*/

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
    public Patrullaje Enemigo;

    LineRenderer laserLine;
    float fireTimer;

    private void Start()
    {
        Enemigo = FindAnyObjectByType<Patrullaje>();
    }

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
                if (hit.collider.CompareTag("Enemigo"))
                {
                    if (Enemigo != null)
                    {
                        Enemigo.vidaActual -= 10;
                        Debug.Log("He dado al enemigo");
                    }
                }
            }

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
}