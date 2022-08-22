using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunCheckListConColor : MonoBehaviour
{
    public Toggle[] checks;
    public int posCheck;
    public Color[] coloresNecesarios;
    [Header("Validacion")]
    public bool[] checksListos;
    public bool todosChecksListos;
    void Start()
    {
        checks = GetComponentsInChildren<Toggle>();
        checksListos = new bool[checks.Length];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void activarUltimoCheck()
    {
        checks[posCheck].isOn = true;
        checks[posCheck].GetComponent<Image>().color = coloresNecesarios[0];
        checkearCheck(posCheck);
        posCheck++;
    }
    public void activarUnCheck(int pos)
    {
        checks[pos].isOn = true;
        checks[pos].GetComponent<Image>().color = coloresNecesarios[0];
        checkearCheck(pos);
    }

    public void reiniciar()
    {
        for (int i = 0; i < checks.Length; i++)
        {
            checks[i].isOn = false;
            checks[i].GetComponent<Image>().color = coloresNecesarios[1];
        }
        posCheck = 0;
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
    public void checkearCheck(int pos)
    {
        checksListos[pos] = true;
        if (validarArreglo(checksListos))
        {
            todosChecksListos = true;
        }
    }
}
