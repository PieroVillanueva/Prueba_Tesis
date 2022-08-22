using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunCanvasEtapas : MonoBehaviour
{
    public Text textoDePanel;
    public Button[] Botones;
    private string[] texto;
    public bool[] btnActivado;
    // Start is called before the first frame update
    void Start()
    {
        texto = new string[4];
        texto[0] = "El rey de Constantinopla esta constantinoplizado.Consta que Constanza, no lo pudo desconstantinoplizar.El desconstantinoplizador que desconstantinoplizare al rey de Constantinopla, buen desconstantinoplizador será.";
        texto[1] = "El hipopótamo Hipo está con hipo, ¿quién le quita el hipoal hipopótamo Hipo?";
        texto[2] = "El que compra pocas capas, pocas capas paga, como yo compré pocas capas, pocas capas pago.";
        texto[3] = "Pedro Pérez Pita pintor perpetuo, pinta paisajes por poco precio para poder partirpronto para París.";

        cambiarSeleccion(0);
        cambiarGuiado(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambiarSeleccion(int seleccionado)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == seleccionado)
            {
                Botones[i].GetComponent<Image>().color = new Color(1, 0, 0);
                textoDePanel.text = texto[i];
            }
            else
            {
                Botones[i].GetComponent<Image>().color = new Color(0, 1, 0);
            }
        }
    }
    public void cambiarGuiado(int seleccionado)
    {
        for (int i = 4; i < 6; i++)
        {
            if (i == seleccionado)
            {
                Botones[i].GetComponent<Image>().color = new Color(1, 0, 0);
            }
            else
            {
                Botones[i].GetComponent<Image>().color = new Color(0, 1, 0);
            }
        }
    }


 
}
