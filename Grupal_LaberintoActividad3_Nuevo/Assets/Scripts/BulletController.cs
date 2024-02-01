using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Debug.Log(collision.gameObject.tag);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
