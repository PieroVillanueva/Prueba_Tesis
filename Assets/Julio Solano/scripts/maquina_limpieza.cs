using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maquina_limpieza : MonoBehaviour
{
    public GameObject Maquina;
    public GameObject tubo_guardado;
    public GameObject tubo_1;
    public GameObject tubo_2;
    public float timer = 0.0f;
    public float time_off;
    public Vector3 ubicacion_m;
    bool limpiando = false;
    Vector3 pos0;
    // Start is called before the first frame update
    void Start()
    {
        pos0 = this.transform.position;
        tubo_guardado.gameObject.SetActive(true);
        tubo_1.gameObject.SetActive(false);
        tubo_2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (limpiando == true)
        {
            timer = Time.deltaTime + timer;
            if (timer >= time_off)
            {
                if (this.name == "manguera")
                {
                    
                }
                //Maquina.gameObject.SetActive(false);
                G_Manager.gm.si_muestra = false;
                G_Manager.gm.permiso_siguiente_fase = true;
                Debug.Log("ya limpiado");
                limpiando = false;
                G_Manager.gm.ya_limpio = true;
                timer = 0.0f;
                StartCoroutine(apagar_maquina());
            }

        }

        /*if (this.name == "M_Limpiadora" && limpiando == false)
        {
            this.transform.position = pos0;
            this.gameObject.SetActive(true);
        }*/

    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (G_Manager.gm.n_etapa == 3)
        {
            if (other.CompareTag("Player"))
            {
                tubo_guardado.gameObject.SetActive(false);
                tubo_1.gameObject.SetActive(true);
                tubo_2.gameObject.SetActive(true);
                this.gameObject.transform.position = G_Manager.gm.gas.transform.position + ubicacion_m;
                limpiando = true;
            }
        }
  }*/

    public void M_maquina()
    {
        this.gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
        tubo_guardado.gameObject.SetActive(false);
        tubo_1.gameObject.SetActive(true);
        tubo_2.gameObject.SetActive(true);
        Maquina.gameObject.transform.position = G_Manager.gm.gas.transform.position + ubicacion_m;
        limpiando = true;
        //apagar_maquina();
    }
    public void Activar_Maquina()
    {
        StartCoroutine(animacion_maquina());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator animacion_maquina()
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        yield return new WaitForSeconds(0.5f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.5f);
        player.StartCoroutine("TransitionLvlOut");
        M_maquina();

    }
    IEnumerator apagar_maquina()
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        yield return new WaitForSeconds(0.5f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.5f);
        player.StartCoroutine("TransitionLvlOut");
        this.gameObject.SetActive(false);
    }
}