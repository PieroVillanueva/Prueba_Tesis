using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Estantes
{
    public Rigidbody[] objetos;
    public GameObject padre;
    public Vector3[] posIn;
    public Vector3[] rotIn;
    public List<Vector3> posI;
    public List<Vector3> rotI;

    public void ObtenerPosInicial()
    {
        if (objetos != null)
        {
            for (int i = 0; i < objetos.Length; i++)
            {
                posI.Add(objetos[i].gameObject.transform.localPosition);
                rotI.Add(objetos[i].gameObject.transform.localEulerAngles);
            }

        }      
    }

    public void Rewind()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].gameObject.transform.localPosition = posI[i];
            objetos[i].gameObject.transform.localEulerAngles = rotI[i];
            objetos[i].isKinematic = true;
        }
    }
}
public class AccidenteEstantesRLA : MonoBehaviour
{
    public Estantes[] estantes;
    public bool primera;
    public RLA_Manager manager;
    void Start()
    {
        foreach (Estantes esta in estantes)
        {
            esta.objetos = esta.padre.GetComponentsInChildren<Rigidbody>();
            esta.ObtenerPosInicial();
        }
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Detect") || (other.CompareTag("Objeto") && !other.GetComponent<Rigidbody>().isKinematic))
        {
            if (!primera)
            {
                StartCoroutine(Accidente());
                primera = true;
            }           
        }
        
    }

    IEnumerator Accidente()
    {
        foreach (Estantes estante in estantes)
        {
            foreach (Rigidbody cuerpos in estante.objetos)
            {
                cuerpos.isKinematic = false;
            }
            yield return new WaitForSeconds(1f);
        }
        if (manager != null)
        {
            //manager.CumplirTarea(25);
        }
        gameObject.SetActive(false);

        
    }
}
