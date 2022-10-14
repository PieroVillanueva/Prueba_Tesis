using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FunSeleccionadorEscena : MonoBehaviour
{
    public int totalOpciones;
    public int seleccionado;

    public GameObject[] mostrables;

    // Start is called before the first frame update
    void Start()
    {
        seleccionado = 0;
        totalOpciones = mostrables.Length-1;
        cambiarSeleccion(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambiarSeleccion(int selec)
    {
        for (int i = 0; i < mostrables.Length; i++)
        {
            mostrables[i].SetActive(false);
        }
        mostrables[selec].SetActive(true);
    }
    public void derecha()
    {
        seleccionado++;
        if (seleccionado > totalOpciones)
        {
            seleccionado = 0;
        }
        cambiarSeleccion(seleccionado);
    }
    public void izquierda()
    {
        seleccionado--;
        if (seleccionado < 0)
        {
            seleccionado = totalOpciones;
        }
        cambiarSeleccion(seleccionado);
    }
    public void elegirEscenario(int opcion)
    {
        SceneManager.LoadScene(asignarEscenaAOpcion(opcion));
    }

    public int asignarEscenaAOpcion(int opcion)
    {
        //switch (opcion)
        //{
        //    case 0:
        //        return 1;
        //    case 1:
        //        return 5;
        //    case 2:
        //        return 8;
        //}
        return opcion;
    }



}
