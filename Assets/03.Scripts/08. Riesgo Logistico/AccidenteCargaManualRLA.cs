using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidenteCargaManualRLA : MonoBehaviour
{
    // Start is called before the first frame update
    public RLA_Manager manager;
    public GameObject copia;
    public MeshRenderer textuPadre;
    public BoxCollider collPadre;
    public Transform nuevaPosicion;
    public AudioSource audioSource;
    public AudioClip locuciones;
    public bool accidente;
    public bool primera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!primera) //&& textuPadre != null
            {
                manager.CumplirTarea(7);
                //textuPadre.enabled = false;
                //collPadre.isTrigger = true;
                //copia.SetActive(true);
               // copia.transform.parent = null;
                //accidente = true;
                primera = true;
            }
            
            //textuPadre.gameObject.SetActive(false);
        }
    }

    public void MoverCaja()
    {
        if (accidente)
        {
            audioSource.clip = locuciones;
            audioSource.Play();
            textuPadre.gameObject.transform.position = nuevaPosicion.position;
        }
    }

}
