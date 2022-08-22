using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerda_anim : MonoBehaviour
{
    public GameObject medidor_fake;
    public GameObject m_guia;
    public bool inicio_anim = false;
    public bool ya_bajo = false;
    public bool a_subir = false;
    public float timer;
    public float speed;
    public float cuerda_stop;
    Vector3 pos0;
    Vector3 alargo;
    Vector3 descenso;
    public float waiting;

    //public float timer
    // Start is called before the first frame update
    void Start()
    {
        medidor_fake.SetActive(false);
        pos0 = this.gameObject.transform.localScale;
        alargo = new Vector3(0.0f, 0.011f, 0.0f);
        descenso = new Vector3(0.0f, 0.011f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (G_Manager.gm.ya_cuerda == true)
        {
            inicio_anim = true;
        }
        if (inicio_anim == true)
        {

            medidor_fake.SetActive(true);

            G_Manager.gm.ya_cuerda = false;
            timer = aumento_X_tiempo(timer);
            this.gameObject.transform.localScale += alargo;
            this.gameObject.transform.localPosition -= descenso;
            medidor_fake.transform.localPosition -= descenso * 2;

            if (cuerda_stop <= timer)
            {
                timer = 0;
                inicio_anim = false;
                ya_bajo = true;
            }
        }
        if (ya_bajo == true)
        {
            timer = aumento_X_tiempo(timer);
            if (waiting <= timer)
            {
                ya_bajo = false;
                timer = 0;
                a_subir = true;
            }
        }
        if (a_subir == true)
        {

            timer = aumento_X_tiempo(timer);
            this.gameObject.transform.localScale -= alargo;
            this.gameObject.transform.localPosition += descenso;
            medidor_fake.transform.localPosition += descenso * 2;
            if (cuerda_stop <= timer)
            {
                G_Manager.gm.cuerda_usar = false;
                //inicio_anim = false;
                G_Manager.gm.fin_cuerda = true;
                //G_Manager.gm.ya_cuerda = true;
                G_Manager.gm.tp_detector = true;
                medidor_fake.SetActive(false);
                a_subir = false;
                timer = 0;
                this.gameObject.transform.localScale = new Vector3(0.02f, 0.1f, 0.02f);

            }
        }
    }
    public void iniciar_caida()
    {
        inicio_anim = true;
    }
    float aumento_X_tiempo(float timer)
    {
        timer += Time.deltaTime * speed;
        return timer;
    }
}
