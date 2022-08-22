using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunManagerMostrarObjetos : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Colocar modelo de Default")]
    public GameObject[] ModelosDefault;

    [Tooltip("Colocar modelo Mostrable")]
    public GameObject[] ModelosMostrables;

    //[Tooltip("Colocar mesh de Mostrable")]
   // public MeshRenderer[] Mesh_Mostrables;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void CambiarColor(FunTipoEPP tipo, bool resaltar)
    {
    }
    public void MostrarColocado(int posicion)
    {
        ModelosDefault[posicion].SetActive(false);
        ModelosMostrables[posicion].SetActive(true);
    }
    public void OcultarColocado(int posicion)
    {
        ModelosDefault[posicion].SetActive(true);
        ModelosMostrables[posicion].SetActive(false);
    }
    public void resaltado2(int pos,bool resaltar)
    {
        if (ModelosMostrables[pos].GetComponent<MeshRenderer>() != null)
        {
            Material mat = ModelosMostrables[pos].GetComponent<MeshRenderer>().material;
            if (mat != null)
            {
                if (resaltar)
                {
                    mat.SetFloat("_UseColorMap", 0);
                    mat.SetFloat("_EMISSION", 1);
                    //Debug.Log("bbbbbsignado");
                }
                else
                {
                    mat.SetFloat("_UseColorMap", 1);
                    mat.SetFloat("_EMISSION", 0);
                    //Debug.Log("cccccsignado");
                }
                //Debug.Log("LOGRADO");
            }
        }
        else
        {
            MeshRenderer[] mesh = ModelosMostrables[pos].GetComponentsInChildren<MeshRenderer>();
            Material[] materiales=new Material[mesh.Length];
            for (int i = 0; i < mesh.Length; i++)
            {
                materiales[i]= mesh[i].material;
                //Debug.Log("aaaasignado");
            }
            //Debug.Log(materiales.Length);

            if (resaltar)
            {
                for (int i = 0; i < materiales.Length; i++)
                {
                    materiales[i].SetFloat("_UseColorMap", 0);
                    materiales[i].SetFloat("_EMISSION", 1);
                    //Debug.Log("aaaasignado");
                }
            }
            else
            {
                for (int i = 0; i < materiales.Length; i++)
                {
                    materiales[i].SetFloat("_UseColorMap", 1);
                    materiales[i].SetFloat("_EMISSION", 0);
                    //Debug.Log("desaaaasignado");
                }
            }
           
        }
        
    }
    
    public virtual void MostrarMostrable(FunTipoEPP tipo)
    {

    }
    public virtual void OcultarMostrable(FunTipoEPP tipo)
    {

    }
}
