using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawn1;
    [SerializeField] private Transform spawn2;
    [SerializeField] private bool isShooting = false;
    [SerializeField] private bool start = false;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float retraso;
    public float intervaloBala=3f;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // El trigger ha entrado en contacto con el jugador
            start = true;
            isShooting = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            start = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            
            StartCoroutine(Shoot());
            isShooting = false;
        }
    }

    IEnumerator Shoot()
    {
        while (start)
        {
            yield return new WaitForSeconds(retraso);
            GameObject x = Instantiate(bullet, spawn1.position, spawn1.rotation) as GameObject;
            Rigidbody rb = x.GetComponent<Rigidbody>();
            rb.AddForce(-spawn1.forward * bulletSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(intervaloBala/2);
            GameObject y = Instantiate(bullet, spawn2.position, spawn2.rotation) as GameObject;
            Rigidbody rb2 = y.GetComponent<Rigidbody>();
            rb2.AddForce(-spawn2.forward * bulletSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(intervaloBala/2);
        }
    }
}
