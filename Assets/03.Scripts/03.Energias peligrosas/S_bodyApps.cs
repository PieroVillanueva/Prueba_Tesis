using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_bodyApps : MonoBehaviour
{
    //bool isUsed = false;
    public List<S_APPs> appColocados;
    
    bool validarTipoApp(S_APPs app)
    {
        if (appColocados.Count != 0)
        {
            for(int i = 0; i < appColocados.Count; i++)
            {
                if (appColocados[i].APP.ToString() == "manos")
                {
                    return false;
                }
            }
            return true;
        }
        return true;
    }

    /// <summary>
    /// agrega objetos a una lista de Apps
    /// </summary>
    /// <param name="app">App</param>
    public void colocarObjetos(S_APPs app)
    {
        /*if (validarTipoApp(app) == false)
        {
            //Reemplazar APP
            reeemplazarObjeto(app);
            Debug.Log("se reemplazo App a lista");
        }
        else
        {*/
            //Agrega APP
            appColocados.Add(app);
            Debug.Log("se agrego App a lista");
        //}

    }

    void reeemplazarObjeto(S_APPs app)
    {
        for(int i = 0; i < appColocados.Count; i++)
        {
            if (appColocados[i].APP.ToString() == "manos")
            {
                appColocados[i] = app;
            }
        }
    }

    public bool comprobarCantidadApp(int cantidadApp)
    {
        if (appColocados.Count==cantidadApp) return true;
        return false;
    }
}
