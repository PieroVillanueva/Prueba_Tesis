using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorV2 : MonoBehaviour
{
    public G_Manager g_m;
    //public Text medidor;
    //public Text ins_etapa;
    //public Text e_text;
    //public Button b_reset;
    public float gas_valor = 27.6f;
   /* public GameObject g_ins;
    p*ublic GameObject g_valores;*/
    public GameObject pantalla;
    public GameObject pantalla_0;
    public GameObject atach;

    public int counter = 0;
    //bool SiDetectado = false;
    public float timer;
    public float exposicion_gas;
    public float timer2;
    public float timer3;
    public float ver_pantalla;
    public bool si_ver_pantalla;
    bool ultma_muestra=false;
    bool cuerda_usada=false;
    public int value;
    //public int n_etapa = 1;
    public int Rango_max = 3;
    public bool if_screen_ON = false;
    public bool si_permiso = false;
    public bool si_anotado = false;
    public bool ya_cuerda = false;
    public GameObject c_reset;
    public string etapa;
    bool si_siguiente_etapa = false;
    bool si_siguiente_fase = false;
    public GameObject cuerda;
    //public bool detectado = false;
    // Start is called before the first frame update
    void Start()
    {
        si_ver_pantalla = false;
   
    }

    // Update is called once per frame
    void Update()
    {
        if (G_Manager.gm.n_etapa == 5)
        {
            if (G_Manager.gm.cuerda_usar == false)
            {
                G_Manager.gm.cuerda_usar = true;
                G_Manager.gm.si_detecto = true;
                //ya_cuerda = true;
                pantalla_0.SetActive(true);

                G_Manager.gm.si_anotado = false;
                G_Manager.gm.si_muestra = true;
                si_ver_pantalla = true;
            }
               
        }
        
        if (G_Manager.gm.si_detecto == true) { si_ver_pantalla = true; }


        if (si_ver_pantalla == true)
        {
            timer2 += Time.deltaTime;
            if (ver_pantalla <= timer2)
            {
                pantalla.SetActive(false);
                pantalla_0.SetActive(false);
                si_ver_pantalla = false;
                timer2 = 0;
            }
        }
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            G_Manager.gm.indicador.SetActive(false);
        }
        if (other.name == "Pos0_detector"&& G_Manager.gm.ya_cuerda == false)
        {
           
                //this.gameObject.SetActive(false);
                G_Manager.gm.ya_cuerda = true;
                //cuerda_usada = true;
                
                //this.gameObject.SetActive(true);
                //ya_cuerda = false;
            
            }
    }
     
        private void OnTriggerStay(Collider other)
    {
        if (G_Manager.gm.si_detecto == false) { 
            if (other.tag == "gas_ducto")
            {
                
                timer += Time.deltaTime;
                    if (timer >= exposicion_gas)
                {
                    G_Manager.gm.si_expuesto = true;
                    G_Manager.gm.go_op2 = true;

                    if (G_Manager.gm.n_etapa==2)//detecto gas venenoso
                        {
                            gas_valor = 26.7f;
                            pantalla.SetActive(true);
              
                        }
                        else//no detecto gas
                        {
                            gas_valor = 0.0f;
                            pantalla_0.SetActive(true);
                        }
                        Debug.Log("Gas Detectado = " + gas_valor);
                        timer = 0f;
                    G_Manager.gm.si_detecto = true;
                    if (G_Manager.gm.si_detecto == true)
                    {
                        Debug.Log("gas detectado");
                    }
                    G_Manager.gm.si_anotado = false;
                    G_Manager.gm.si_muestra = true;
                    si_ver_pantalla = true;
                    //G_Manager.gm.si_detecto = detectado;
                }
                
                }
            }
    }

    private void OnTriggerExit(Collider other)
    {
        timer = 0f;
        //g_ins.SetActive(false);
    }
}
