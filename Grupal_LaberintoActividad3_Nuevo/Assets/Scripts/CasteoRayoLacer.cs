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

            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                if (hit.collider.CompareTag("Enemigo"))
                {
                    Debug.Log("Enemigo Detectado");
                    Detectado = true;
                }
            }

            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                AbrirPuertas abrirPuertas = hit.collider.GetComponent<AbrirPuertas>();
                if (abrirPuertas != null)
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
