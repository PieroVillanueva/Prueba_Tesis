using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunMostrarLetreros : MonoBehaviour
{
    public GameObject[] objetivos;
    public GameObject[] letreros;
    private bool auxiliar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        auxiliar = objetivos[0].activeInHierarchy || objetivos[1].activeInHierarchy || objetivos[2].activeInHierarchy;
        letreros[0].SetActive(auxiliar);
    }

}
