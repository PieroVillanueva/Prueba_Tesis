using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuncionalidadesRiesgoESupervi : MonoBehaviour
{

    public Lvl_Manager lvlManager;

    public bool[] colocaEppPrimero;
    public bool[] tocarArosPanelesMotor;
    public bool[] tocarBotonesPanelesMotor;
    public bool[] colocaEppSegundo;

    public bool[] medirPolos;
    public bool primeraVez2;
    public Text textoPeligro;

    void Start()
    {
        StartCoroutine(cambiarTamanoFuente());
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
    public void colocarEppPrimero(int posEpp)
    {
        colocaEppPrimero[posEpp] = true;
        if (validarArreglo(colocaEppPrimero))
        {
            lvlManager.CumplirTarea(1);
        }
    }
    public void tocarAroPanelMotor(int posAro)
    {
            tocarArosPanelesMotor[posAro] = true;
            if (validarArreglo(tocarArosPanelesMotor))
            {
                if (!primeraVez2)
                {
                    primeraVez2 = true;
                    lvlManager.CumplirTarea(2);
                }
             }
       
    }
    public void tocarBotonPanelMotor(int posBoton)
    {
        tocarBotonesPanelesMotor[posBoton] = true;
        if (validarArreglo(tocarBotonesPanelesMotor))
        {
            lvlManager.CumplirTarea(3);
        }
    }
    public void colocarEppSegundo(int posEpp)
    {
        colocaEppSegundo[posEpp] = true;
        if (validarArreglo(colocaEppSegundo))
        {
            lvlManager.CumplirTarea(4);
        }
    }
    public void medirUnPolo(int posPolo)
    {
        medirPolos[posPolo] = true;
        if (validarArreglo(medirPolos))
        {
            lvlManager.CumplirTarea(10);
        }
    }
    
    IEnumerator cambiarTamanoFuente()
    {
        while (true) {
        for (int i = 0; i < 26; i++)
        {
            textoPeligro.fontSize= 94+i;
            yield return new WaitForSeconds(0.05f);
        }
        for (int i = 0; i < 26; i++)
        {
            textoPeligro.fontSize = 120- i;
            yield return new WaitForSeconds(0.05f);
        }
        }

    }

}
