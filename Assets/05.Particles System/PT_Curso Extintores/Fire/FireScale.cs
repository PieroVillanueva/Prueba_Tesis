using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScale : MonoBehaviour
{
    public ParticleSystem[] p_hijos;
    [Range(0, 1f)]
    public float escala = 0.01f;
    // Start is called before the first frame update
    void changeScale(float value)
    {
        foreach(ParticleSystem particle in p_hijos)
        {
            particle.transform.localScale = Vector3.one * value;            
        }
    }

    // Update is called once per frame
    void Update()
    {
        changeScale(escala);
    }
}
