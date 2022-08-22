using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionAroRLA : MonoBehaviour
{
    public RLA_Manager manager;
    public int indice;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (indice)
            {
                case 0: manager.CumplirTarea(2);
                    break;
                case 1: manager.CumplirTarea(3);
                    break;
                case 2: manager.CumplirTarea(9);
                    break;
                case 3: manager.CumplirTarea(10);
                    break;
                case 4: manager.CumplirTarea(19);
                    break;
                case 5: manager.AccidenteAtropello();
                    break;
                case 6:
                    manager.CumplirTarea(24);
                    break;
                case 7: manager.CumplirTarea(29);
                    break;
                case 8: manager.CumplirTarea(30);
                    break;
                case 9: manager.CumplirTarea(32);
                    break;
                case 10: manager.CumplirTarea(35);
                    break;
            }
            gameObject.SetActive(false);
        }
    }
}
