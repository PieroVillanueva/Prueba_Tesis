﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunBtnNoGuiado : MonoBehaviour
{
    public FunCanvasEtapas canvaEtapas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            canvaEtapas.cambiarGuiado(5);
        }
    }
}
