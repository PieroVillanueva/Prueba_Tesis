using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunManagerSecadoAlVacio : MonoBehaviour
{
    [Header("Validacion Epps")]
    public bool[] eppsColocados;
    public bool todosEPPColocados;

    [Header("Audios")]
    public AudioSource reproductor;
    public AudioClip audioAccidente;
    public AudioClip[] audiosSecuencia;
   
    [Header("Validaciones")]
    public bool confirmoExtintor;
    public bool selimpio;

    [Header("Objetos Secuencia")]
    public GameObject letreroAplastamiento;


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
        for (int i = 0; i < eppsColocados.Length; i++)
        {
            if (!arreglo[i])
            {
                return false;
            }
        }
        return true;
    }
    public void colocarseEpp(int pos) //Al colocarse EPP
    {
        if (!eppsColocados[pos])
        {
            eppsColocados[pos] = true;

            if (validarArreglo(eppsColocados))
            {
                todosEPPColocados = true;

            }
        }
    }
    public void colocarEppRoto()
    {
        //AUDIO EPP ROTO
    }
    public void confirmarExtintor()
    {
        confirmoExtintor = true;
    } 
    public void realizarLimpieza()
    {
        selimpio = true;
    }
}
