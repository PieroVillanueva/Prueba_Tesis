using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G_Manager : MonoBehaviour
{
    public GameObject cuerda_spawn;
    public Animator op2;
    public GameObject detector_indicador;
    public GameObject wt_indicador;
    public verificacion_apps va;
    public GameObject panel0;
    public GameObject panel1;
    public GameObject panel2;
    public int t_a = -1;
    public GameObject player;
    public GameObject posA;
    public static G_Manager gm;
    public int n_etapa;
    public GameObject notacion1;
    public GameObject notacion2;
    public GameObject notacion3;
    public bool fin_cuerda = false;
    public bool cuerda_usar = true;
    public bool si_anotado;
    public bool ya_cuerda = false;
    public bool tp_detector = false;
    public bool permiso_siguiente_fase;
    public bool si_muestra = false;
    public bool si_detecto;
    public bool si_abierto_tapa = false;
    public bool anotado_T1 = false;
    public bool anotado_T2 = false;
    public bool anotado_T3 = false;
    public bool ya_limpio = false;
    public bool ya_medido_despues_limpieza = false;
    public bool ya_permiso;
    public bool ya_firma = false;
    public bool yo_contesto = false;
    public bool ya_salida = false;
    //public Text fase;
    public GameObject gas;
    int fase_ant;
    public bool tapa_open = false;
    public GameObject indicador;
    public bool si_accidente = false;
    public int apps_max = 13;
    public int apps = 0;
    public bool si_expuesto = false;
    public bool go_operario = false;
    public bool posible_accidente = true;
    public bool despues_anim = false;
    public bool todo_equip = false;
    public bool ducto_limpio = false;
    public bool go_op2 = false;
    public int tarea;

    public string etapa;
    private void Awake()
    {
        if (gm == null)
        {
            DontDestroyOnLoad(gameObject);
            gm = this;
        }
        else if (gm != this) { Destroy(gameObject);
        }
    }
    void Start()
    {

        n_etapa = 1;
        si_anotado = false;
        notacion1.SetActive(false);
        notacion2.SetActive(false);
        notacion3.SetActive(false);
    }
    /// <summary>
    /// 
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (go_op2 == true)
        {
            go_op2 = false;
            Debug.Log("llamo animacion");
            StartCoroutine(medicion());

        }

        if (apps == apps_max)
        {
            todo_equip = true;
        }

        if (posible_accidente == true)
        {
            if (go_operario == true && todo_equip == false)
            {
                posible_accidente = false;
                Debug.Log("si accidente ope sin apps");
                si_accidente = true;//operario2
                t_a = 1;
                posible_accidente = false;
                //go_operario = false;
            } else {
                if (go_operario == true && ducto_limpio == false)
                {
                    // go_operario = false;
                    Debug.Log("si accidente ope tox");
                    t_a = 2;//operario1
                    si_accidente = true;

                } else
                {
                    if (va.todos_apps == false && si_expuesto == true)
                    {
                        si_expuesto = false;
                        StartCoroutine("off_player");
                        Debug.Log("si accidente yo tox");
                        t_a = 0;//usuario
                        si_accidente = true;
                        posible_accidente = false;
                    }
                }
            }
            //go_accidente = false;
        }


        if (si_accidente == true && despues_anim == true)
        {
            Debug.Log("ya ocurrio accidente");
            despues_anim = false;
            //            si_accidente = false;
            activar_accidente(t_a);
        }
        if (si_anotado == true)
        {
            switch (n_etapa)
            {
                case 1:
                    anotado_T1 = true;
                    notacion1.SetActive(true);
                    si_expuesto = false;
                    break;
                case 4:
                    anotado_T2 = true;
                    notacion2.SetActive(true);
                    si_expuesto = false;
                    break;
                case 6:
                    Debug.Log("cumple  6");
                    anotado_T3 = true;
                    notacion3.SetActive(true);
                    si_expuesto = false;
                    break;
            }
        }
        if (si_muestra == false)
        {
            if (n_etapa == 0)
            {
                etapa = "preparacion";
            }
            if (n_etapa == 1)
            {
                etapa = "Tope";
                indicador.SetActive(true);
            }
            if (n_etapa == 2)
            {
                etapa = "Centro";
            }
            if (n_etapa == 3)
            {
                etapa = "Limpieza";
            }
            if (n_etapa == 4) {
                etapa = "nueva medicion";
            }
            if (n_etapa == 5)
            {
                etapa = "Fondo";
            }
            si_muestra = true;//muestra la fase
            Debug.Log("Etapa : " + etapa);
        }
        if (si_anotado == true && si_detecto == true)
        {
            //si_siguiente_fase = false;
            //yield return new WaitForSeconds(1);
            si_muestra = false;
            si_anotado = false;
            permiso_siguiente_fase = true;
            si_detecto = false;
            Debug.Log("Ya anotado");
        }
        if (permiso_siguiente_fase == true)
        {
            n_etapa++;
            Debug.Log("cambio de fase, aprobado : " + n_etapa);
            permiso_siguiente_fase = false;
        }
        if (ya_limpio == true)
        {
            si_muestra = false;
            si_anotado = false;
            permiso_siguiente_fase = true;
            si_detecto = false;
        }
        if (n_etapa == 6)
        {
            ya_medido_despues_limpieza = true;
        }
        if (n_etapa == 2 && si_detecto == true)
        {
            si_anotado = false;
            si_detecto = false;
            permiso_siguiente_fase = true;
            si_muestra = false;
        }
    }
    public void Wt_respuesta()
    {
        wt_indicador.SetActive(false);
        yo_contesto = true;
    }

    void activar_accidente(int t_a)
    {
        player.transform.position = posA.transform.position;
        player.transform.rotation = posA.transform.rotation;
        switch (t_a)
        {
            case 0:
                panel0.SetActive(true);
                break;
            case 1:
                panel1.SetActive(true);
                break;
            case 2:
                panel2.SetActive(true);
                break;
        }
    }
    public IEnumerator off_player()
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        //yield return new WaitForSeconds(1.5f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.5f);
        player.StartCoroutine("TransitionLvlOut");
        despues_anim = true;
    }
    public IEnumerator medicion()
    {

        Debug.Log("empezo animacion: medicion de ope2");

        yield return new WaitForSeconds(.1f);
        op2.SetTrigger("medicion");
        yield return new WaitForSeconds(.5f);
    }
    
}
[System.Serializable]
public class verificacion_apps
{
    public GameObject[] apps;
    public bool todos_apps=true;

    public void v_apps()
    {
        for(int i =0;i < apps.Length; i++)
        {
            Debug.Log("verfico apps:" +i);
            if (apps[i].activeInHierarchy == true)
            {
                Debug.Log("falta apps :"+i);
                todos_apps = false;
                break;
            }
            else
            {
                Debug.Log("todos apps");
                todos_apps = true;
            }
        }
    }

}

