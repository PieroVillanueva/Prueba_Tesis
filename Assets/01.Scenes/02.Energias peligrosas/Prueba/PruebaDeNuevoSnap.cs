using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaDeNuevoSnap : MonoBehaviour
{
    public bool primeraVez;
    public GameObject lentesSilueta;
    public bool colocado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    private void OnTriggerStay(Collider obj)
    {
        lentesSilueta.SetActive(true);
        if (obj.name == "Equipo2" )
        {

            if (!colocado && !obj.GetComponent<ObjetoParaSnapNuevo>().agarrado)
            {
                lentesSilueta.SetActive(false);
                obj.transform.position = gameObject.transform.position;
                obj.GetComponent<Rigidbody>().useGravity = false;
                Debug.Log("se Coloco");
                //sonido de colocar
                if (!primeraVez)
                {
                    primeraVez = true;
                    //sonido de tarea cumplida
                   
                }
                colocado = true;
            }
            if(obj.GetComponent<ObjetoParaSnapNuevo>().agarrado && colocado)
            {
                colocado = false;
            }
           
        }
    }
    private void OnTriggerExit(Collider obj)
    {
       obj.GetComponent<Rigidbody>().useGravity = true;
        lentesSilueta.SetActive(false);
    }

}
