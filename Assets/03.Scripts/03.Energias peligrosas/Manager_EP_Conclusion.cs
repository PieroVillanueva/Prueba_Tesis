using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_EP_Conclusion : Lvl_Manager
{
    public bool m_snapBloqueo;
    public bool m_snapCandado;
    public bool m_snapPinza;

    public FunCheckList listaChecks;
    public GameObject salida;

    public MeshRenderer[] meshFressnel;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        listaChecks.gameObject.SetActive(false);
        salida.gameObject.SetActive(false);
        StartCoroutine(Tareas(actualTarea));
    }

    

    public override void CumplirTarea(int indexTarea)
    {
        listaChecks.activarCheck(indexTarea);
        base.CumplirTarea(indexTarea);

        StartCoroutine(Tareas(actualTarea));
    }

    public void SnapBloqueo(bool value)
    {
        m_snapBloqueo = value;
    }
    public void SnapCandado(bool value)
    {
        m_snapCandado = value;
    }
    public void SnapaPinzas(bool value)
    {
        m_snapPinza = value;
    }

    bool validadSnaps()
    {
        if (m_snapPinza == true || m_snapCandado == true || m_snapBloqueo == true) return false;
        return true;
    }

    IEnumerator Tareas(int tarea)
    {

        yield return new WaitForSeconds(3);
        switch (tarea)
        {
            case 0:
                while (validadSnaps() != true)
                {
                    //esperando sacar los snaps
                    yield return new WaitForFixedUpdate();
                }
                CumplirTarea(0);
                break;
            case 1:
                meshFressnel[0].material.SetFloat("_EMISSION", 1);
                while (meshFressnel[0].material.GetFloat("_EMISSION") == 1)
                {
                    //esperando tocar switch
                    yield return new WaitForFixedUpdate();
                }
                meshFressnel[1].material.SetFloat("_EMISSION", 1);
                while (meshFressnel[1].material.GetFloat("_EMISSION") == 1)
                {
                    //esperando tocar interruptorBomba
                    yield return new WaitForFixedUpdate();
                }
                meshFressnel[2].material.SetFloat("_EMISSION", 1);
                while (meshFressnel[2].material.GetFloat("_EMISSION") == 1)
                {
                    //esperando tocar interruptorBomba
                    yield return new WaitForFixedUpdate();
                }
                CumplirTarea(1);
                break;
            case 2:
                listaChecks.gameObject.SetActive(true);
                salida.gameObject.SetActive(true);
                break;
            case 3:
                
                break;

        }
    }

}
