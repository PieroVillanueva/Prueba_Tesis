using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VR_head_body : MonoBehaviour
{
    public Animator ergo_sprite_guia;
    public GameObject c;
    public GameObject i;
    public GameObject carga;
    public GameObject piso;
    public GameObject h_camara;
    public GameObject head;
    public GameObject body;
    public Text h_rot;
    public Text distance_h_b;
    public Text altura_actual;
    public Text info;
    public double distancex;
    
    double distance_p;
    double max_altura;
    double altura_min;
    double angulo_h;
    public bool a_c = false;
    public bool p_c = false;
    public bool RH_select = false;
    public bool LH_select = false;
    public bool tarea18 = false;
    public bool tarea19 = false;
    public bool tarea20 = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calcular_alt();
        calcular_d_carga();
        calcular_vision();
        mostrar_postura();
        //h_rot.text = "rotacion : " + h_r();
        si_tarea18_20();        
        //altura_actual.text = "altura actual: "+distance_p+" ; max altura: "+ max_altura + " minima: "+ altura_min;

        //distance_h_b.text = "distancia carga : " + distancex;
}
    void calcular_d_carga()
    {
        if(GManagerErgo.ge.actualTarea>=17)
        distancex = System.Math.Round(carga.transform.position.z - h_camara.transform.position.z, 2);

        if (distancex <= 0.05f)
        {
            p_c = false;
        }
        else
        {
            p_c = true;
        }
    }
    void calcular_vision()
    {
        if (angulo_h > 50 && angulo_h < 90)
        {            
            a_c = false;
        }
        else
        {
            a_c = true;
        }
    }
    void mostrar_postura()
    {
        if (p_c == true&&a_c==true)
        {
            c.SetActive(true);
            i.SetActive(false);
            //.text = "Postura correcta";
        }
        else
        {
            if (tarea20 != true) {
                c.SetActive(false);
                i.SetActive(true);
            }

            //info.text = "Postura incorrecta";
        }
    }
    void calcular_alt()
    {
        distance_p = System.Math.Round(h_camara.transform.position.y - piso.transform.position.y, 2);
    }
    double h_r()
    {
        double text;
        text= System.Math.Round(h_camara.transform.localEulerAngles.x, 2);
        angulo_h = text;
        return text;
    }
    public void cargar_catch(bool is_derecha)
    {
        switch (is_derecha)
        {
            case false:
                LH_select = true;
                break;
            case true:
                RH_select = true;
                break;
        }
    }
    public void soltar_catch(bool is_derecha)
    {
        switch (is_derecha)
        {
            case false:
                LH_select = false;
                break;
            case true:
                RH_select = false;
                break;
        }
    }
    void si_tarea18_20()
    {
        if (GManagerErgo.ge.actualTarea <= 17 && distance_p > max_altura)
        {
            max_altura = distance_p;
            altura_min = max_altura * 60 / 100;
        }
        if (tarea18 == false && GManagerErgo.ge.actualTarea == 18)
        {
            if (distance_p < altura_min && p_c == true)
            {
                StartCoroutine(paso1_2());
                GManagerErgo.ge.me.CumplirTarea(18);
                tarea18 = true;
            }
        }
        if (tarea18 == true && tarea19 == false)
        {
            
            if (LH_select == true && RH_select == true && GManagerErgo.ge.E5_cargar == true)
            {
                StartCoroutine(paso2_3());
                GManagerErgo.ge.me.CumplirTarea(19);
                tarea19 = true;
            }
        }
        if (tarea19 == true && tarea20 == false)
        {
            
            if (GManagerErgo.ge.E5_cargar == true && distance_p >= max_altura * 4 / 5)
            {
                StartCoroutine(paso3_4());
                StartCoroutine(espera_t20());
                
            }
        }
    }
    IEnumerator espera_t20()
    {
        yield return new WaitForSeconds(0.5f);
        GManagerErgo.ge.me.CumplirTarea(20);
        GManagerErgo.ge.E5_carga_indi.SetActive(true);
        GManagerErgo.ge.check_obj(6);
        tarea20 = true;
    }
    IEnumerator paso1_2() 
    {
        ergo_sprite_guia.SetTrigger("paso1");
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator paso2_3()
    {
        ergo_sprite_guia.SetTrigger("paso3");
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator paso3_4()
    {
        ergo_sprite_guia.SetTrigger("paso4");
        yield return new WaitForSeconds(0.1f);
    }
}
