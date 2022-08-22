using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ergo_E3_lampara : MonoBehaviour
{
    public GameObject indicador;
    public GameObject lampara_mesh;
    Vector3 pos0;
    Vector4 rot0;
    bool tp = false;
    public float timer;
    public float tp_time = 0.1f;
    bool no_grab = true;
    public GameObject nombre_col;
    public bool contacto_limite = false;
    public int n_iluminador = 2;
    // Start is called before the first frame update
    void Start()
    {
        pos0 = new Vector3();
        rot0 = new Vector4();
        pos0 = this.transform.position;
        rot0 = this.transform.localEulerAngles;
    }

    void OnTriggerStay(Collider coll)
    {
        if (LayerMask.LayerToName(coll.gameObject.layer) == "Ground")
        {
            Debug.Log("piso detectado");
            timer += Time.deltaTime;
            if (timer >= tp_time)
            {
                this.transform.position = pos0;
                this.transform.localEulerAngles = rot0;
                Debug.Log(this.gameObject.name + " teletransportado");
                timer = 0;
            }
        }
        if (coll.name == nombre_col.name&&no_grab==true)
        {
            this.transform.localEulerAngles = rot0;
            contacto_limite = true;
            GManagerErgo.ge.evento_Iluminacion(2);
            GManagerErgo.ge.E3_Lamp_ind.SetActive(false);
            lampara_mesh.SetActive(true);
            Debug.Log("lampara en escritorio");
            coll.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            }
    }
    public void in_grab()
    {
        no_grab = false;
        indicador.SetActive(false);
    }
    public void out_grab()
    {
        no_grab = true;
        if (contacto_limite == false) { indicador.SetActive(true); }
        
        timer = 0.0f;
    }
}