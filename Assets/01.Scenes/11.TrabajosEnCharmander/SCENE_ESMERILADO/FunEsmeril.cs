using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunEsmeril : MonoBehaviour
{
    // Start is called before the first frame update
    public string targetTag;
    public bool chocaConSuperficie;
    public bool esmerilEncendido;
    public GameObject chispa;
    public GameObject lijaGiratoria;
    public int velocidad;
    void Start()
    {
    }
    void Update()
    {
        if(chocaConSuperficie && esmerilEncendido)
        {
            chispa.SetActive(true);
        }
        else
        {
            chispa.SetActive(false);
        }
    }
    void OnDisable()
    {
        chispa.SetActive(false);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        lijaGiratoria.transform.Rotate(0, 0, velocidad);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            chocaConSuperficie = true;
            //StartCoroutine(muestraParticula());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            chocaConSuperficie = false;
        }
    }
    public void encenderEsmeril()
    {
        esmerilEncendido = true;
        //StartCoroutine(muestraParticula());
    }
    public void apagarEsmeril()
    {
        esmerilEncendido = false;
    }
    IEnumerator muestraParticula()
    {
        while (chocaConSuperficie&&esmerilEncendido) {
            yield return new WaitForSeconds(0.01f);
            chispa.SetActive(true);
        }
        chispa.SetActive(false);
    }


}
