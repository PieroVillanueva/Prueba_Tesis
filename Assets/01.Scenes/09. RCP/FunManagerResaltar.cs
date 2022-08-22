using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunManagerResaltar : MonoBehaviour
{
    public GameObject[] cambiantes;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambiarColor(GameObject cambiante, bool azul)
    {
        if (azul)
        {
            cambiante.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_UseColorMap", 0);
            cambiante.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_EMISSION", 1);
        }
        else
        {
            cambiante.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_UseColorMap", 1);
            cambiante.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_EMISSION", 0);
        }
    }
    public void ponerAzulObjeto(int posicion)
    {
        cambiarColor(cambiantes[posicion],true);
    }
    public void quitarAzulObjeto(int posicion)
    {
        cambiarColor(cambiantes[posicion], false);
    }
}
