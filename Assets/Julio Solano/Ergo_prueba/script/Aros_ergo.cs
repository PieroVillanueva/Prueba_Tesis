using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aros_ergo : MonoBehaviour
{
    public Manager_Ergo me;
    int caso_revisado=-1;
    string labor;
    private void OnTriggerEnter(Collider other)
    {
       if (other.name == "VR Rig")
        {
                switch (me.actualTarea)
                {
                    case 0:
                        caso_revisado = me.actualTarea;
                        me.CumplirTarea(0);
                        labor = " cumplo tarea 0";
                        
                        break;
                    case 1:
                        GManagerErgo.ge.StartCoroutine("espera");
                        GManagerErgo.ge.panelesParte1[0].gameObject.SetActive(true);
                        labor = " activo panel 1";
                        caso_revisado = me.actualTarea;
                        break;
                    case 3:
                        //GManagerErgo.ge.StartCoroutine("espera");
                        GManagerErgo.ge.panelesParte1[1].gameObject.SetActive(true);
                        labor = " activo panel 2";
                        caso_revisado = me.actualTarea;
                    GManagerErgo.ge.aro.transform.position = GManagerErgo.ge.aro_pos[3].position;
                    break;
                    case 4:
                        //GManagerErgo.ge.StartCoroutine("espera");
                    
                    GManagerErgo.ge.panelesParte1[2].gameObject.SetActive(true);
                        labor = " activo panel 3";
                        caso_revisado = me.actualTarea;
                        break;
                    case 5:
                       // GManagerErgo.ge.StartCoroutine("espera");
                    
                    GManagerErgo.ge.panelesParte1[3].gameObject.SetActive(true);
                        labor = " activo panel 4";
                        caso_revisado = me.actualTarea;
                        break;
                    case 7:
                        caso_revisado = me.actualTarea;
                    GManagerErgo.ge.panelesParte1[3].gameObject.SetActive(false);
                    me.CumplirTarea(7);
                        labor = " se indico ir a otra area";
                        
                        break;
                case 8:
                    caso_revisado = me.actualTarea;
                    me.CumplirTarea(8);
                    labor = " se indico ir a otra area";

                    break;
                case 9:
                        GManagerErgo.ge.StartCoroutine("espera");
                        GManagerErgo.ge.panelesParte1[4].gameObject.SetActive(true);
                        labor = " activo panel 5 de orden y limpieza";
                        caso_revisado = me.actualTarea;
                        break;
                case 11:
                    GManagerErgo.ge.StartCoroutine("espera");
                    GManagerErgo.ge.panelesParte1[5].gameObject.SetActive(true);
                    labor = " activo panel 6 de iluminacion";
                    caso_revisado = me.actualTarea;
                    this.gameObject.SetActive(false);
                    break;
                case 13:
                    caso_revisado = me.actualTarea;
                    me.CumplirTarea(13);
                    labor = " se indico ir a otra area";
                    break;
                case 15:
                    caso_revisado = me.actualTarea;
                    GManagerErgo.ge.hacer_carga();
                    //anim_ayudante()
                    labor = " se acerco al extra e inicio animacion";
                    GManagerErgo.ge.aro.transform.position = GManagerErgo.ge.aro_pos[10].position;
                    break;
                case 17:
                    caso_revisado = me.actualTarea;
                    me.CumplirTarea(17);
                    labor = " se posiciono cerca a la carga";
                    GManagerErgo.ge.limites(7);
                    this.gameObject.SetActive(false);
                    break;
                default:break;
            }
                Debug.Log("Aro :" + labor + " :hecho");
                this.gameObject.SetActive(false);
                
            }
        
    }
}
