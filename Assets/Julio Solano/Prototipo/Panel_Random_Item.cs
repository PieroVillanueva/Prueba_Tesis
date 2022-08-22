using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Random_Item : MonoBehaviour
{
    public Text text;
    
    public GameObject[] opciones;
    public GameObject[] Items;
    public bool b1_bien = true;
    Vector3 pos0;
    Vector3 pos1;
    bool ya_respuesta = false;
    public int n_panel_tarea;
    public bool panel_cmpleta_tarea = false;
    

    void Start()
    {
        
        is_correct();
        pos0 = opciones[0].transform.localPosition;
        pos1 = opciones[1].transform.localPosition;
        opciones[2].SetActive(false);
        opciones[3].SetActive(false);

    }
    public void activo_respuesta(int boton)
    {
        ya_respuesta = false;
        opciones[boton].SetActive(false);
        if (b1_bien == true && ya_respuesta == false)
        {
            if (boton == 0)
            {
                opciones[2].transform.localPosition = pos0;
                opciones[2].SetActive(true);
                opciones[3].SetActive(false);
                ya_respuesta = true;
                /*if (panel_completa_tarea == true)
                {
                    GManagerErgo.ge.completar_tarea_panel(n_panel_tarea);
                }*/

            }
            else
            {
                opciones[3].transform.localPosition = pos1;
                opciones[3].SetActive(true);
            }
        }
        else
        {
            if (boton != 0 && ya_respuesta == false)
            {
                opciones[2].transform.localPosition = pos1;
                opciones[2].SetActive(true);
                opciones[3].SetActive(false);
                ya_respuesta = true;
                /*if (panel_completa_tarea == true)
                {
                    GManagerErgo.ge.completar_tarea_panel(n_panel_tarea);
                }*/
            }
            else
            {
                opciones[3].transform.localPosition = pos0;
                opciones[3].SetActive(true);
            }
        }
    }
    void is_correct() 
    {
        int r;
        r = Random.Range(0, 2);
        if (r == 0)
        {
            b1_bien = true;
        }
        else { b1_bien = false; }
    }
    void show_items(bool f)
    {
        if (f == false)
        {
            int i;
            i = Random.Range(0, Items.Length);
            Items[i].SetActive(false);
        }
    }
}