using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaparticulas : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem electricidad;
    public ParticleSystem humo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        electricidad.Play();
        humo.Play();
    }
}
