using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ValidacionesRiesElecElectricista : MonoBehaviour
{
    public Lvl_Manager lvlManager;
    public bool[] colocaEppPrimero;
    public bool[] checksTocados;
    public bool[] polosMedidos;

    public Text textoPeligro;
    // Start is called before the first frame update
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
    public void tocarCheck(int posCheck)
    {
        checksTocados[posCheck] = true;
        if (validarArreglo(checksTocados))
        {
            lvlManager.CumplirTarea(3);
        }
    }
    public void medirPolo(int posPolo)
    {
        polosMedidos[posPolo] = true;
        if (validarArreglo(polosMedidos))
        {
            lvlManager.CumplirTarea(6);
        }
    }
    IEnumerator cambiarTamanoFuente()
    {
        while (true)
        {
            for (int i = 0; i < 26; i++)
            {
                textoPeligro.fontSize = 94 + i;
                yield return new WaitForSeconds(0.05f);
            }
            for (int i = 0; i < 26; i++)
            {
                textoPeligro.fontSize = 120 - i;
                yield return new WaitForSeconds(0.05f);
            }
        }

    }

}
