using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asensor_puerta : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject p_i;
    public GameObject p_d;
    Vector3 pos0_i;
    Vector3 pos0_d;
    public float timer;
    public float espera_a;
    public float espera_p;
    public float speed;
    public bool auto = true;
    public bool si_abierta=false;
    public bool si_cerrada=true;
    public Vector3 move;
    public float li;
    public float ld;
    public bool player_in;
    // Start is called before the first frame update
    void Start()
    {
        pos0_i = p_i.transform.localPosition;
        pos0_d = p_d.transform.localPosition;
    }
    void Update()
    {if(auto == true)
        {
            timer = aumento_x_tiempo(timer);
            if(timer >= espera_a)
            {
                abrir_puertas();
                auto = false;
                timer = 0;
            }
        }
        if (si_abierta == true && si_cerrada == true)
        {
            p_i.transform.localPosition -= move;
            p_d.transform.localPosition += move;
            timer = aumento_x_tiempo(timer);
            if (p_d.transform.localPosition.x >= ld)
            {
                timer = 0;
                si_cerrada = false;
            }
        }
        if (si_cerrada == false && si_abierta == true)
        {
            if (player_in == false) { 
            timer = aumento_x_tiempo(timer);
            if (timer >= espera_p)
            {
                timer = 0;
                si_abierta = false;
            }
        }
        }
        if(si_cerrada == false && si_abierta == false)
        {
            p_i.transform.localPosition += move;
            p_d.transform.localPosition -= move;
            timer = aumento_x_tiempo(timer);
            if (p_d.transform.localPosition.x <= pos0_d.x )
            {
                timer = 0;
                si_cerrada = true;
            }
        }
    }
    public void abrir_puertas()
    {
        audioSource.Play();
        si_abierta = true;
    }
    float aumento_x_tiempo(float timer)
    {
        timer += Time.deltaTime * speed;
        return timer;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name=="VR Rig")
        {
            player_in = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "VR Rig")
        {
            player_in = true;
        }
    }
}
