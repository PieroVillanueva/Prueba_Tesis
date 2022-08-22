using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnclajetTraspaletaRLA : MonoBehaviour
{
    public RLA_Manager manager;
    public Transform hijo;
    public Transform nuevaPosicion;
    public Rigidbody cuerpos;
    public bool anclado;
    public Transform apoyo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Activar()
    {
        if (hijo != null)
        {
            if (!anclado)
            {
                manager.CumplirTarea(16);
                hijo.parent = apoyo.transform;
                hijo.localPosition = nuevaPosicion.localPosition;
                Caja();
                anclado = true;
            }
            else
            {
                hijo.parent = null;
                hijo = null;
                CajaNoAncla();
                anclado = false;
            }
        }
        

    }

    public void Caja()
    {

        /*for (int i = 0; i < cuerpos.Length; i++)
        {
            cuerpos[i].isKinematic = true;
        }*/
        cuerpos.isKinematic = true;
    }

    public void CajaNoAncla()
    {
        /*for (int i = 0; i < cuerpos.Length; i++)
        {
            cuerpos[i].isKinematic = false;
        }*/
        cuerpos.isKinematic = false;
    }
}
