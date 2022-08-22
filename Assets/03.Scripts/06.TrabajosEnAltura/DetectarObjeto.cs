using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    public ManagerTA manager;
    public bool primera;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ActivarSeguro()
    {
        if (!primera)
        {
            manager.CumplirTarea(1);
            primera = true;
        }
        
    }

    

}
