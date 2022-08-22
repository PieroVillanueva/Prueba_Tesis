using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoFuncion : MonoBehaviour
{
    public bool agarrado;
    public bool noVolverAsignar;
    // Start is called before the first frame update
    void Start()
    {
        noVolverAsignar = true; //no tiene letrero y no pide ni suelta letrero
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Soltar()
    {
        if (!noVolverAsignar) { // en caso este desactivado no pasa nada 
            agarrado = false; // se considera que no esta agarrado
            PoolManagerFun.instanciaCompartida.ObtenerObjeto(gameObject);//Se le asigna el letrero
        }
    }
    public void Agarrar()
    {
        if (!noVolverAsignar)// en caso este desactivado no pasa nada 
        {
            agarrado = true; //se considera agarrado para que el letrero deje de seguirlo y vuelva al pool
        }
    }
  


}
