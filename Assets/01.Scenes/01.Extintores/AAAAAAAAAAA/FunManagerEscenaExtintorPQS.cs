using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunManagerEscenaExtintorPQS : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] titulos;
    public GameObject[] contenido;
    public BoxCollider[] colliders;
    void Start()
    {
        solicitarExtintores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void solicitarExtintores() => StartCoroutine(mostrarExtintores());

    IEnumerator mostrarExtintores()
    {
        for (int i = 0; i < titulos.Length; i++)
        {
            yield return new WaitForSeconds(0.25f);
            titulos[i].SetActive(true);
            yield return new WaitForSeconds(0.18f);
            contenido[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 3; i++)
        {
            colliders[i].enabled = true;
        }
        
    }

}
