using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunValidarQuimicosPelambre : MonoBehaviour
{
    public bool[] quimicos;
    public ManagerTrabajoPelambre manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void agarrarQuimico(int pos)
    {
        if (!quimicos[pos])
        {
            quimicos[pos] = true;
            switch (pos)
            {
                case 0:
                    manager.llamarEmpezarTarea(4);
                    break;
                case 1:
                    manager.llamarEmpezarTarea(6);
                    break;
                case 2:
                    manager.llamarEmpezarTarea(11);
                    break;
                case 3:
                    manager.llamarEmpezarTarea(14);
                    break;
                case 4:
                    manager.llamarEmpezarTarea(16);
                    break;
                case 5:
                    manager.llamarEmpezarTarea(19);
                    break;
                case 6:
                    manager.llamarEmpezarTarea(21);
                    break;
                case 7:
                    manager.llamarEmpezarTarea(23);
                    break;
                case 8:
                    manager.llamarEmpezarTarea(26);
                    break;
                case 9:
                    manager.llamarEmpezarTarea(28);
                    break;
                case 10:
                    manager.llamarEmpezarTarea(31);
                    break;
                case 11:
                    manager.llamarEmpezarTarea(33);
                    break;

            }
        }
    }


}
