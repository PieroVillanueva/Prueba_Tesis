using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunBtnCulminacion : MonoBehaviour
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
            canvaEtapas.cambiarSeleccion(3);
        }
    }
}
