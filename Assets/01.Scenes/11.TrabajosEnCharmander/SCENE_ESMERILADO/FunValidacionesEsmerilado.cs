using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunValidacionesEsmerilado : MonoBehaviour
{
    public bool[] eppColocado;
    public bool todosEPPColocados;
    public bool agarradoSegundaMano;
    public bool ocurrioAccidente;

    public bool segundaFirma;

    public int mediciones;
    public bool revisionDeGases;

    public bool retirarPersonalNoAutorizado;

    public FunManagerEsmerilado manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool validarArreglo(bool[] arreglo)
    {
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (!arreglo[i])
            {
                return false;
            }
        }
        return true;
    }
    public void colocarEpp(int posEpp)
    {
        eppColocado[posEpp] = true;
        if (validarArreglo(eppColocado))
        {
            todosEPPColocados = true;
        }
    }
    public void agarrarSegundaMano()
    {
        agarradoSegundaMano = true;
    }
    public void soltarSegundaMano()
    {
        agarradoSegundaMano = false;
    }
    public void tocarFiloEsmerilado()
    {
        if (!agarradoSegundaMano && !ocurrioAccidente)
        {
            ocurrioAccidente = true;
            Debug.Log("Accidente tocar Esmeril");
            manager.accidentePorTocarFlama();


        }
    }
    public void activarDesterrar()
    {
        retirarPersonalNoAutorizado = true;
    }
    public void activarBoolSegundaFirma()
    {
        segundaFirma = true;
    }
    public void contarMedicion()
    {
        if (!revisionDeGases && mediciones <= 2)
        {
            if (mediciones == 2)
            {
                revisionDeGases = true;
            }
            else
            {
                mediciones++;
            }
        }
    }

}
