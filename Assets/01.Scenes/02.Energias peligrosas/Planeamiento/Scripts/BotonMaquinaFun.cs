using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonMaquinaFun : MonoBehaviour
{
    public GameObject panel;
    public AudioClip clip;
    public AudioClip clip2;
    public Lvl_Manager lvl_manager;
    public int Turno=0;
    // Start is called before the first frame update
    void Start()
    {
        lvl_manager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PrenderOApagar()
    {
        /*
        panel.GetComponent<PanelFun>().maquinaApagada = !panel.GetComponent<PanelFun>().maquinaApagada;
        Debug.Log("Maquina Cambiada a " + panel.GetComponent<PanelFun>().maquinaApagada);

        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip);*/
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player")&&Turno==1)
        {
            panel.GetComponent<PanelFun>().maquinaApagada = !panel.GetComponent<PanelFun>().maquinaApagada;
            Debug.Log("Maquina Cambiada a " + panel.GetComponent<PanelFun>().maquinaApagada);

            GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip);
            StartCoroutine(ReproducirSiguienteAudio(1));
            Turno = 0;
        }
        if (obj.CompareTag("Player") && Turno == 2)
        {
            GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip2);
            StartCoroutine(ReproducirSiguienteAudio(9));
            Turno = 0;
        }
    }
    IEnumerator ReproducirSiguienteAudio(int pos)
    {
        yield return new WaitForSeconds(0.5f);
        lvl_manager.CumplirTarea(pos);
    }
}
