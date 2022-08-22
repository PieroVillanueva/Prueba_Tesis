using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarBasuraOyL_SO : MonoBehaviour
{

    public ManagerOyL_SO manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bloqueo"))
        {
            StartCoroutine(EliminarObstaculo(other.gameObject));
        }
    }

    IEnumerator EliminarObstaculo(GameObject obstaculo)
    {
        if ((obstaculo.GetComponent<ObstaculoSO>().ComprobarTipoObstaculo("documento") || obstaculo.GetComponent<ObstaculoSO>().ComprobarTipoObstaculo("basura")) && obstaculo.GetComponent<ObstaculoSO>().enUso)
        {
            yield return new WaitForSeconds(1f);
            obstaculo.SetActive(false);
            manager.obstaculosActual--;
            obstaculo.GetComponent<ObstaculoSO>().enUso = false;
            Debug.Log("Eliminado");
        } 
    }
}
