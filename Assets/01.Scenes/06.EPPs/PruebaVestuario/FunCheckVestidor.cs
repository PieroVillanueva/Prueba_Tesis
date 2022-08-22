using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunCheckVestidor : MonoBehaviour
{
    
    public Toggle[] checks;
    public Text[] nombres;
    public int posCheck;
    public Color[] coloresNecesarios;

    public void asignarToggle(int opcion, string texto,string parte)
    {
       
        if (opcion == 1)
        {
            checks[posCheck].isOn = true;
        }
            checks[posCheck].GetComponent<Image>().color = coloresNecesarios[opcion-1];
            nombres[posCheck].text = parte+": "+texto;

        if (posCheck < 6)
        {
            posCheck++;
        }
        
    }

}
