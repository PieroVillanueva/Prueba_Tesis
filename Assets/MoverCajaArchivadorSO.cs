using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoverCajaArchivadorSO : MonoBehaviour
{
   
    public List<cajaArchivadorSO> cajas;
    public List<cajaArchivadorSO> cajasAuxiliar;
    private Vector3 auxiliar;
    public float distancia;
    public int cajasAbiertas;
    public GameObject accidente;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoverCajas()
    {
        int i = Random.Range(0, cajas.Count);
        auxiliar = cajas[i].caja.localPosition;
        auxiliar.z = distancia;
        cajas[i].caja.localPosition = auxiliar;
        cajas[i].cerrado = false;
        cajasAuxiliar.Add(cajas[i]);
        cajas.RemoveAt(i);
    }

    public void ComprobarCerrado()
    {    
        if (CajasCerradas())
        {
            accidente.SetActive(false);
        }
    }

    public bool CajasCerradas()
    {
        foreach (cajaArchivadorSO cajaActual in cajasAuxiliar)
        {
            if (!cajaActual.cerrado)
            {
                return false;
            }
        }
        return true;
    }
    
}
