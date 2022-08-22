using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMetodoVR : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer esfera;
    void Start()
    {
        esfera = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambiarColor()
    {
        esfera.material.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
    }
}
