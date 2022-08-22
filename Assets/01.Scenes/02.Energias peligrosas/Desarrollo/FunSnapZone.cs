using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunSnapZone : MonoBehaviour
{
    public GameObject Objeto;
    public bool MostrarObjeto;
    // Start is called before the first frame update
    void Start()
    {
        MostrarObjeto = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivarOcultarModelo(bool activo)
    {
        if (MostrarObjeto)
        {
            if (activo)
            {
                Objeto.SetActive(true);
            }
            else
            {
                Objeto.SetActive(false);
            }
        }
    }
    public void VolverMostrarOcultarModelo(bool activo)
    {
        MostrarObjeto = activo;
        if (!activo)
        {
            Objeto.SetActive(false);
        }
    }

}
