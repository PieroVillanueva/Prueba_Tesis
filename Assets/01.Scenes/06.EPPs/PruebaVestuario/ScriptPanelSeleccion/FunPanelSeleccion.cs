using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunPanelSeleccion : MonoBehaviour
{
    public Button[] Botones;
    public GameObject[] CollidersBoton;
    public FunNivelVestuarioController controlador;
    [SerializeField]
    private Color ColorResaltado;
    [SerializeField]
    private Color ColorSinResaltar;
    public FunPuertaLevadiza puerta;

    public Text textoSituacion;
    void Start()
    {
        SeleccionarBoton(0);
    }
    private void resaltarPresionado(int seleccionado) {
        for (int i = 0; i < 3; i++)
        {
            if (i == seleccionado)
            {
                Botones[i].GetComponent<Image>().color = ColorResaltado;//new Color(178, 86,9); NARANJA

            }
            else
            {
                Botones[i].GetComponent<Image>().color = ColorSinResaltar;//new Color(9, 101, 178); AZUL
            }
        }
    }
    private void SetCombinacionEpp(string cabeza,string ojos,string oidos,string manos,string respiratoria,string ropa,string pies) {
        controlador.VersionEppCorrecto[0] = cabeza;
        controlador.VersionEppCorrecto[1] = ojos;
        controlador.VersionEppCorrecto[2] = oidos;
        controlador.VersionEppCorrecto[3] = manos;
        controlador.VersionEppCorrecto[4] = respiratoria;
        controlador.VersionEppCorrecto[5] = ropa;
        controlador.VersionEppCorrecto[6] = pies;
    }
    public void SeleccionarBoton(int seleccionado) {
        switch (seleccionado)
        {
            case 0:
                resaltarPresionado(seleccionado);
                SetCombinacionEpp("A","B","B","C","A","A","A");
                textoSituacion.text = "Energias Peligrosas";
                break;

            case 1:
                resaltarPresionado(seleccionado);
                SetCombinacionEpp("A", "B", "B", "C", "", "", "");
                textoSituacion.text = "Trabajo en alturas";
                break;

            case 2:
                resaltarPresionado(seleccionado);
                SetCombinacionEpp("B", "B", "A", "C", "", "A", "A");
                textoSituacion.text = "Riesgos Químicos";
                break;
            case 3://ALEATORIO
                SeleccionarBoton(Random.Range(0,3));
                break;

            case 4://COMENZAR
                for (int i = 0; i < CollidersBoton.Length; i++)
                {
                    CollidersBoton[i].SetActive(false);
                }
                puerta.LlamarSubida();
                break;
        }
       
    }
}
