using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunMedidor : MonoBehaviour
{
    public Text medicion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarTexto(string nuevoTexto)
    {
        medicion.text = nuevoTexto;
    }
}
