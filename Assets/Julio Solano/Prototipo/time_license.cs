using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time_license : MonoBehaviour
{
    public Text hora;
    public Text hora2;
    public Text hora_actual;
    public Text hora_temp;
    public string hora_temp2;
    string realtime;
    bool por_defecto = false;
    bool nueva_licencia = false; 
    public string hora_custom;
    double raw;
   
    int[] fecha;
    // Start is called before the first frame update
    void Start()
    {
        //fecha[0] = System.DateTime.Now.get_Month();
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
//        string timeUS = System.DateTime.UtcNow.ToLocalTime().ToString("M/d/yy hh:mm tt");
        hora.text = "Hora Tomada : "+ time;
        hora2.text = "Hora2 Tomada : " + calcular_Hora();
        hora_temp.text = "Licencia vigente";
        hora_temp2 = calcular_Hora();
        //DateTime time = UtcNow.ToLocalTime().AddDays(20);
        //Debug.Log( );
    }

    // Update is called once per frame
    /*void Update()
    {
        realtime = calcular_Hora();
        hora_actual.text = "Hora Actual : " + calcular_Hora();
 
        
        if (por_defecto == false&&nueva_licencia==true)
            {
                if(hora_custom!=
            }
        
        
    }*/
    string calcular_Hora()
    {
        realtime = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
        return realtime;
    }
    void Licencia_check(bool nueva_licencia)
    {
        if (nueva_licencia == false)
        {
            hora_temp.text = "Licencia vencida";
        }
        else
        {
            hora_temp.text = "Licencia vigente";
        }
    }

}
