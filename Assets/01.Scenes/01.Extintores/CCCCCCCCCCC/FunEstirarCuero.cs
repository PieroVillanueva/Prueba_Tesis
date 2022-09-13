using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunEstirarCuero : MonoBehaviour
{
    [Header("Validaciones")]
    public bool derecha;
    public bool izquierda;

    [Header("Modelos")]
    public GameObject modelo_Ninguno;
    public GameObject modelo_Derecha;
    public GameObject modelo_Izquierda;
    public GameObject modelo_Ambos;

    // Start is called before the first frame update
    void Start()
    {
        activarModelos();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void activarModelos()
    {
        modelo_Ninguno.SetActive(false);
        modelo_Derecha.SetActive(false);
        modelo_Izquierda.SetActive(false);
        modelo_Ambos.SetActive(false);
        if (derecha && izquierda)
        {
            modelo_Ambos.SetActive(true);
            return;
        }
        if (derecha)
        {
            modelo_Derecha.SetActive(true);
        }
        else if (izquierda)
        {
            modelo_Izquierda.SetActive(true);
        }
        else
        {
            modelo_Ninguno.SetActive(true);
        }
    }

    public void tocarDerecha()
    {
        derecha = true;
        activarModelos();
    }
    public void tocarIzquierda()
    {
        izquierda = true;
        activarModelos();
    }

}
