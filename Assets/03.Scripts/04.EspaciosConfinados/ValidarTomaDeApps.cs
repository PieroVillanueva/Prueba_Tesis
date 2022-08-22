using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidarTomaDeApps : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle[] toggles;
    public Manager_Preparacion controlador;
    public bool primera = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValidarTogglesActivos()
    {
        if (!primera)
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                if (toggles[i].isOn == false)
                {
                    Debug.Log("a");
                    break;
                }
                if (i == toggles.Length - 1)
                {
                    Debug.Log("b");
                    primera = true;
                    controlador.CumplirTarea(1);
                }
            }
        }
        
    }
}
