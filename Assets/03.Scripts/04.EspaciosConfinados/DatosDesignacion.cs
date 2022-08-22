using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DatosDesignacion : MonoBehaviour
{
    // Start is called before the first frame update
    public Text nombre;
    public Text fecha;
    void Start()
    {
        nombre.text = "Cristian Suclupe Llontop";
        fecha.text = DateTime.Now.ToString("dd-MM-yyyy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
