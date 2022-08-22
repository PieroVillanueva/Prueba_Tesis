﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidarImplementosTA : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject casco;
    public GameObject limite;
    public GameObject boton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValidarImplementos()
    {
        if (!casco.activeInHierarchy)
        {
            limite.SetActive(false);
            boton.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ValidarImplementos();
        }
    }
}
