using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunManagerEPP : MonoBehaviour
{
    public int cantidadEpp;
    public bool[] equiposAgarrados;

    [Header("====Objetos====")] 
    public OneHandInteractable[] epps;
    public FunLetreroSencillo letrero;
   
    [Header("====Audio====")]
    public AudioSource reproductor;
    public AudioClip[] audios;

    [Header("====Video====")]
    public GameObject[] videosIntro;
    public float[] tiemposDuracionIntro;

    public GameObject[] videosObjetos;
    public float[] tiemposDuracionObjetos;

    [Header("====Final====")]
    public GameObject aroParaRotos;
    public OneHandInteractable[] eppRotos;

    // Start is called before the first frame update
    void Start()
    {
        cantidadEpp = epps.Length;
        StartCoroutine(inicial());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator inicial()
    {
        yield return new WaitForSeconds(3.0f);
        //SE REPRODUCEN AUDIOS
        letrero.gameObject.SetActive(true);
        epps[0].enabled=true;
    }
    IEnumerator reproducirVideo(int pos)
    {
        videosIntro[pos].SetActive(true);
        yield return new WaitForSeconds(tiemposDuracionIntro[pos] + 3.00f);
        videosIntro[pos].SetActive(false);
    }



    public void agarrarEPP(int pos)
    {
        if (!equiposAgarrados[pos])
        {
            equiposAgarrados[pos] = true;
            StartCoroutine(reproducirVideoObjeto(pos));
        }
    }
    IEnumerator reproducirVideoObjeto(int pos)
    {
        letrero.gameObject.SetActive(false); //Desactiva Letrero

        videosObjetos[pos].SetActive(true); //Muestra video

        yield return new WaitForSeconds(tiemposDuracionObjetos[pos] +3.00f); //Espera termina video
        videosObjetos[pos].SetActive(false); //Oculta video

        if (pos!=cantidadEpp-1) //EN CASO NO SEA EL ULTIMO
        {
            letrero.cambiarObjetivo(epps[pos + 1].gameObject); //Cambias objetivo Letrero
            letrero.gameObject.SetActive(true); //Activar letrero

            epps[pos + 1].enabled = true;//Activar agarrar otro Objeto
        }
        else //EN CASO SEA EL ULTIMO
        {
            aroParaRotos.SetActive(true);
            for (int i = 0; i < eppRotos.Length; i++)
            {
                eppRotos[i].enabled = true;
            }
        }
    }
    public void tocarAroRoto() => StartCoroutine(tocaAroRoto());
    IEnumerator tocaAroRoto()
    {
        videosObjetos[7].SetActive(true); //Muestra video
        yield return new WaitForSeconds(tiemposDuracionObjetos[7] + 3.00f); //Espera termina video
        videosObjetos[7].SetActive(false); //Oculta video
        //Reproduce audio y cambia escenario
        //Debug.Log("YASTA");
    }

}
