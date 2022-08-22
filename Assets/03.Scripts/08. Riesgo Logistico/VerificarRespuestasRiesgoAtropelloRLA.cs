using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VerificarRespuestasRiesgoAtropelloRLA : MonoBehaviour
{
    // Start is called before the first frame update
    public RespuestaRiesgoAtropellosRLA[] respuestasCorrectas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool VerificarRespuestas()
    {
        for (int i = 0; i < respuestasCorrectas.Length; i++)
        {
            if (respuestasCorrectas[i].toggle.isOn == false)
            {
                return false;
            }
        }
        return true;
    }
}
