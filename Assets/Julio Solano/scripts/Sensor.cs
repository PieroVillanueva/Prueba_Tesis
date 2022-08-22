using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{
    public Text medidor;
    public Text ins_etapa;
    public Text e_text;
    public Button b_reset;
    public float gas_valor = 27.6f;
    public GameObject g_ins;
    public GameObject g_valores;
    public GameObject pantalla;
    public GameObject pantalla_0;
    
    public int counter = 0;
    bool SiDetectado = false;
    public float timer;
    public float exposicion_gas;
    public int value;
    public int n_etapa = 1;
    public int Rango_max = 3;
    public bool if_ON=false;
    public bool si_permiso = false;
    public GameObject c_reset;
    public string etapa;
    bool si_siguiente_etapa = false;
    bool si_siguiente_fase = false;
    // Start is called before the first frame update
    void Start()
    {
        e_text.text = "Fase : " + n_etapa;
        g_ins.SetActive(false);
        g_valores.SetActive(false);
        etapa = " Tapa Cerrada";
        //b_reset.onClick.AddListener();
        timer = 0;
         value = Random.Range(0, 3);//sies 0 es que no detecto
        Debug.Log("value = "+value);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer != 0)
        {
            
            if(n_etapa==1){
                Rango_max = 3;
                etapa = " Tapa Cerrada";
                
            }else if (n_etapa == 2)
            {
                etapa = " Tapa Abierta";
                Rango_max = 2;
            }
            else
            {
                Rango_max = 1;
                etapa = " Interior de Ducto";                
            }
            ins_etapa.text = "Inspeccionando :" + etapa;
            g_ins.SetActive(true);
        }
        
        if (SiDetectado == true) {
            counter++;
            SiDetectado = false;
            value = Random.Range(0, 3);//sies 0 es que si detecto
            Debug.Log("value = " + value);
            if (value == 0)
            {
                gas_valor = 26.7f;            }
        
        else
        {
            gas_valor = 0.0f;
        }
        }
    }
    void OnTriggerEnter(Collider other)
    {
       if(other.tag == "reset")
        {
            pantalla.SetActive(false);
            pantalla_0.SetActive(false);
            Debug.Log("Detectador Apagado");
            if_ON = false;
            medidor.text = "0.0";
        }
        if (other.tag == "permiso")
        {
            if_ON = false;
            si_permiso = true;
            if (n_etapa == 2)
            {
                e_text.text = "Fase : " + n_etapa;
            }
            if (n_etapa == 3)
            {
                e_text.text = "Fase : " + n_etapa;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (if_ON == false)
        {
            if (other.tag == "gas_ducto")
            {
                g_ins.SetActive(true);
                if (si_permiso == true)
                {
                    timer += Time.deltaTime;
                    if (timer >= exposicion_gas)
                    {
                        value = Random.Range(0, Rango_max);//sies 0 es que si detecto
                        Debug.Log("value = " + value);
                        if (value == 0)//detecto gas venenoso
                        {
                            gas_valor = 26.7f;
                            pantalla.SetActive(true);
                            
                            si_siguiente_fase = true;
                        }
                        else//no detecto gas
                        {
                            gas_valor = 0.0f;
                            pantalla_0.SetActive(true);
                            si_permiso = false;
                            n_etapa++;
                            
                        }
                        medidor.text = " " + gas_valor;
                        
                        Debug.Log("Gas Detectado = " + gas_valor);
                        timer = 0f;
                        ins_etapa.text = "Inspeccion Completa ";
                        if_ON = true;
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        timer = 0f;
        g_ins.SetActive(false);
    }
    public void reset_b()
    {
        pantalla.SetActive(false);
        pantalla_0.SetActive(false);
        Debug.Log("Detectador Apagado");
        if_ON = false;
        medidor.text = "0.0";
        n_etapa = 1;

    }
}
