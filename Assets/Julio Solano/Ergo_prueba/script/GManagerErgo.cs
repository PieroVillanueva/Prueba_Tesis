using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManagerErgo : MonoBehaviour
{
    public Animator E4_op2;
    public Animator E1_col2;
    public GameObject[] E2_i_desk;
    public GameObject[] cortinas;
    public GameObject tareas_panel;
    public GameObject[] tp_pos;
    public Animator E4_op;
    public GameObject E3_Luz1_2;
    public GameObject E3_Luz1_1;
    public GameObject E3_luz;
    public GameObject E1_cabeza_grab;
    public Manager_Ergo me;
    public bool tarea_hecha = false;
    public static GManagerErgo ge;
    public GameObject[] panelesParte1;
    public GameObject aro;
    public Transform[] aro_pos;
    public Toggle[] objetivos;
    public bool ya_lim = false;
    public int actualTarea;
    public bool e1_cuello_anim = false;
    public bool aro_new_pos = false;
    public int E2_total_items;
    public int E2_actualTotal;
    bool E2_indi_activos = false;
    public int E3_eventos_Iluminacion = 3;
    public int E3_actualeventos;
    public GameObject E3_Lamp_ind;
    public GameObject E3_Lampara_indi;
    bool E3_activar_indi = false;
    public bool[] iluminadores;
    public bool anim_start = false;
    public bool E5_cargar = false;
    public GameObject[] E1_T3_obj_in;
    public GameObject[] E1_T3_obj_mesh;
    public int E1_T3_contador = 0;
    bool E1_T3_indi_activado = false;
    public GameObject E1_T4_obj_in;
    public GameObject E1_T4_obj_mesh;
    public GameObject E1_T4_pies;
    public GameObject E1_T4_pies_pos0;
    public GameObject E5_carga_indi;
       
    public bool ya_pos = false;
    private void Awake()
    {
        if (ge == null)
        {
            DontDestroyOnLoad(gameObject);
            ge = this;
        }
        else if (ge != this)
        {
            Destroy(gameObject);
        }
    }
    public void tp_repos(float angulo, int p)
    {
        if (tareas_panel.transform.position != tp_pos[p].transform.position)
        {
            tareas_panel.transform.position = tp_pos[p].transform.position;
            tareas_panel.transform.eulerAngles += new Vector3(0, angulo, 0);
        }

    }
    public void check_obj(int x)
    {
        objetivos[x].isOn = true;
    }
    public void aros_ubic(int x)
    {
        aro.transform.position = aro_pos[x].position;
        StartCoroutine(espera());
        aro.SetActive(true);


    }
    public IEnumerator espera()
    {
        Debug.Log("espero por courutine");
        yield return new WaitForSeconds(1);

    }
    public void completar_tarea_panel(int tarea)
    {
        me.CumplirTarea(tarea);
    }
    public void limites(int x)
    {
        switch (x)
        {
            case 1:
                E1_cabeza_grab.SetActive(false);
                e1_cuello_anim = true;
                panelesParte1[0].SetActive(false);
                Debug.Log("desactivo panel: " + x);
                break;
            case 2:
                panelesParte1[1].SetActive(false);
                Debug.Log("desactivo panel: " + x);
                break;
            case 3:
                panelesParte1[2].SetActive(false);
                Debug.Log("desactivo panel: " + x);
                break;
            case 4:
                panelesParte1[3].SetActive(false);
                Debug.Log("desactivo panel: " + x);
                break;
            case 5:
                panelesParte1[4].SetActive(false);
                Debug.Log("desactivo panel: " + x);
                break;
            case 6:
                panelesParte1[5].SetActive(false);
                Debug.Log("desactivo panel: " + x);
                break;
            case 7:
                panelesParte1[6].SetActive(false);
                Debug.Log("desactivo panel: " + x);
                break;


        }
    }
    public void Ya_total_Items()
    {
        if (E2_actualTotal == E2_total_items)
        {
            limites(5);
            me.CumplirTarea(10);
            check_obj(4);
        }
    }
    public void evento_Iluminacion(int iluminador)
    {
        iluminadores[iluminador] = true;
        Ya_Iluminado();
    }
    void Ya_Iluminado()
    {
        if (iluminadores[0] == true || iluminadores[1] == true)
        {
            E3_luz.SetActive(true);
        }
        if (iluminadores[0] == true && iluminadores[1] == true)
        {
            E3_Luz1_1.SetActive(true);
            E3_Luz1_2.SetActive(true);
        }
        if (iluminadores[0] == true && iluminadores[1] == true && iluminadores[2] == true)
        {
            limites(6);
            me.CumplirTarea(12);
            check_obj(5);
        }
    }
    public void hacer_carga()
    {
        StartCoroutine(carga_anim());
    }
    IEnumerator carga_anim()
    {
        E4_op.SetTrigger("levantar_obj");
        E4_op2.SetTrigger("carga");
        yield return new WaitForSeconds(4f);
        panelesParte1[6].SetActive(true);
    }
    public void E3_cortinas(int nc)
    {
        cortinas[nc].SetActive(false);
        cortinas[nc + 2].SetActive(true);
    }
    public void activar_items_desk()//indicadores con material verde transparente del ejercicio orden y limpieza
    {
        if (E2_indi_activos == false)
        {
            for (int i = 0; i < E2_i_desk.Length; i++)
            {
                E2_i_desk[i].SetActive(true);
            }
            E2_indi_activos = true;
        }
    }
    public void col2_dis()
    {
        StartCoroutine(c2_dis());
    }
    IEnumerator c2_dis()
    {
        E1_col2.SetTrigger("distancia");
        yield return new WaitForSeconds(2f);
        col2_pos0();
    }
    public void col2_pos0() 
    {
        StartCoroutine(c2_pos0());
    }
    IEnumerator c2_pos0()
    {
        //yield return new WaitForSeconds(1f);
        E1_col2.SetTrigger("pos0");
        yield return new WaitForSeconds(0.1f);
    }
    public void E1_T3_verificador()
    {
        if (E1_T3_contador == 2)
        {
            panelesParte1[2].SetActive(false);
            check_obj(2);
            panelesParte1[2].SetActive(false);
            me.CumplirTarea(4);
            panelesParte1[2].SetActive(false);
        }
    }
    public void E1T3activar_indi()
    {
        if (E1_T3_indi_activado == false)
        {
            E1_T3_obj_in[0].SetActive(true);
            E1_T3_obj_in[1].SetActive(true);
            E1_T3_indi_activado = true;
        }
    }
    public void E1T4activar_indi()
    {
        if (ge.actualTarea < 6)
        {
            E1_T4_pies.SetActive(false);
            E1_T4_pies_pos0.SetActive(true);
            E1_T4_obj_in.SetActive(true);
        }
    }
    public void E3_lamp_active()
    {
        if (E3_activar_indi == false)
        {
            E3_Lampara_indi.SetActive(true);
            E3_activar_indi = true;
        }
    }
}
