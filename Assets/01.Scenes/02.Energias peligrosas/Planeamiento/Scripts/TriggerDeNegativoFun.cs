using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeNegativoFun : MonoBehaviour
{
    public PanelFun panel;
    public AudioClip clip;
    public int posicion;
    void Start()
    {
        panel = GameObject.Find("Panel").GetComponent<PanelFun>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ColocarNegativo()
    {
        //panel.ActivarPolo(false, posicion);
        Debug.Log("Capturo Negativo");
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    public void SacarNegativo()
    {
        //panel.DesactivarPolo(false, posicion);
        Debug.Log("Salio Negativo");
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
    /*
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("PoloNegativo"))
        {
          
        }
    }
    private void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("PoloNegativo"))
        {
           
        }
    }*/
}
