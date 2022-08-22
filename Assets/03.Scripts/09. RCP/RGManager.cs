using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGManager : MonoBehaviour
{
    public RCP_Manager rc;
    public GameObject piso;
    public GameObject cabeza;
    public GameObject aro;
    public GameObject[] paneles;
    public double altura_actual;
    double max_altura;
    public bool si_prueba;

    // Start is called before the first frame update
    void Start()
    {
        if (si_prueba == true)
        {
            altura_actual = 20f;
            max_altura = 20f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rc.actualTarea < 2&&si_prueba!=true)
        {
            calcular_alt();
        }
        if (rc.actualTarea == 2)
        {
            if(altura_actual < max_altura * 0.7)
            {
                rc.CumplirTarea(2);
            }
        }
    }
    void calcular_alt()
    {
        altura_actual = System.Math.Round(cabeza.transform.position.y - piso.transform.position.y, 2);
        if(altura_actual> max_altura)
        {
            max_altura = altura_actual;
        }
    }
}
