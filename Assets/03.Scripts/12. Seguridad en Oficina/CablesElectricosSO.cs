using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CablesElectricosSO : MonoBehaviour
{
    public bool soltado;
    private GameObject canaleta;
    private GameObject cable;
    private BoxCollider colider;
    private Vector3 posicionInicial;
    private Vector3 rotacionInicial;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        rotacionInicial = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PoloPositivo") && other.GetComponent<CablesSO>().enUso)
        {
            colider = other.GetComponent<BoxCollider>();
            canaleta = other.transform.Find("CanaletaSuperior").gameObject;
            cable = other.transform.Find("CableOndulado").gameObject;
            StartCoroutine(SoltarParche(other.gameObject));
        }
    }

    public void CambiarEstadoParche(bool estado)
    {
        soltado = estado;
    }

    IEnumerator SoltarParche(GameObject other)
    {
        while (!soltado)
        {
            yield return new WaitForSeconds(0.01f);
        }
        canaleta.SetActive(true);
        colider.enabled = false;
        transform.position = posicionInicial;
        transform.eulerAngles = rotacionInicial;
        cable.SetActive(false);
        other.GetComponent<CablesSO>().enUso = false;
        yield return new WaitForSeconds(0.1f);
        colider.enabled = true;
        canaleta = null;
        colider = null;
        cable = null;
    }
}
