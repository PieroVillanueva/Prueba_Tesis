using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunColliderPanel : MonoBehaviour
{
    public Manage_EPeligrosas contradorLocuciones;
    public GameObject letrero;
    public GameObject llamadoPool;
    public FunCheckList checkList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            contradorLocuciones.AsignarTarea();
            gameObject.SetActive(false);
            letrero.gameObject.SetActive(false);
            checkList.activarCheck(0);
            llamadoPool.GetComponent<FunLlamadoPool>().mostrarEPP();
        }
    }
}
