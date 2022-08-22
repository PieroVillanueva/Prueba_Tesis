using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesMovimientoMaquinaRLA : MonoBehaviour
{
    // Start is called before the first frame update
    public bool arriba;
    public bool activar;
    public MoverCajaMaquinaRLA movimiento;
    public ColocarLLavaCarroRLA llave;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Activar()
    {
        if (llave.encendido)
        {
            activar = true;
            movimiento.StartCoroutine("BajarySubir");
        }
    }

    public void Desactivar()
    {
        activar = false;
    }
}
