using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PanelConclusion : MonoBehaviour
{
    public bool panelEncendido;
    public S_InterruptorBomba interruptorBomba;

    //public bool bloqueado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EncendidoPanel(bool value)
    {
        interruptorBomba.RecibeEnergia = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
