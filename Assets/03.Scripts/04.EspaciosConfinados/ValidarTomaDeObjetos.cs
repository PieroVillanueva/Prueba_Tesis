using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidarTomaDeObjetos : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] objetosActivados;
    public Manager_Planeamiento1 controlador;
    public Manager_Preparacion preparacion;
    public int escena;
    public bool primera = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarObj(int indice)
    {
        if (escena == 1)
        {
            if (!primera)
            {
                objetosActivados[indice] = true;
                for (int i = 0; i < objetosActivados.Length; i++)
                {
                    if (!objetosActivados[i])
                    {
                        break;
                    }
                    if (i == objetosActivados.Length - 1)
                    {
                        primera = true;
                        controlador.CumplirTarea(0);
                    }
                }
            }
        }
        if (escena == 2)
        {
            if (!primera)
            {
                objetosActivados[indice] = true;
                for (int i = 0; i < objetosActivados.Length; i++)
                {
                    if (!objetosActivados[i])
                    {
                        break;
                    }
                    if (i == objetosActivados.Length - 1)
                    {
                        primera = true;
                        preparacion.CumplirTarea(0);
                    }
                }
            }
        }
        
    }

}
