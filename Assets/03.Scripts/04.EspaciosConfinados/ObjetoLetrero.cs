using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoLetrero : MonoBehaviour
{
    public bool agarrado;
    public bool Desactivado;
    public bool cumplioTarea;
    // Start is called before the first frame update

    void Start()
    {
        agarrado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Soltar()
    {
        agarrado = false;
        ManagerLetrero.instanciaCompartida.ObtenerObjeto(gameObject);
    }
    public void Agarrar()
    {
        agarrado = true;
    }
    public void Desactivar()
    {
        Desactivado = true;
        
    }
    public void CumplirTarea(bool cumplir)
    {
        cumplioTarea = cumplir;
    }
    public void AgarrarTablero()
    {
        if (cumplioTarea)
        {
            agarrado = true;
        }
    }
    public void SoltarTablero()
    {
        if (cumplioTarea)
        {
            agarrado = false;
            ManagerLetrero.instanciaCompartida.ObtenerObjeto(gameObject);
        }
    }
}
