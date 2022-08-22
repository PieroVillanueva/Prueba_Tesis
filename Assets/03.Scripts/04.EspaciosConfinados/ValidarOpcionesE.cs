using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidarOpcionesE : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] opciones;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cambiar(int i)
    {
        opciones[i].SetActive(false);
        if (i + 1 < opciones.Length)
        {
            opciones[i + 1].SetActive(true);
        }
        
    }
}
