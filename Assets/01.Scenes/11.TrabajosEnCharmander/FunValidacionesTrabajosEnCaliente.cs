using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunValidacionesTrabajosEnCaliente : MonoBehaviour
{
    public bool[] eppColocado;
    public bool todosEPPColocados;
    public bool[] gasesActivados;

    public bool retirarPersonalNoAutorizado;
    public bool revisionDeGases;

    public bool segundaFirma;

    public int mediciones;

    public GameObject gasParaEncender;
    public GameObject flama;
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

    public void activarGas(int pos)
    {
        gasesActivados[pos] = true;
        if (validarArreglo(gasesActivados))
        {
            gasParaEncender.gameObject.SetActive(true);
        }
    }
    public void desactivarGas()
    {
        flama.gameObject.SetActive(false);
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
