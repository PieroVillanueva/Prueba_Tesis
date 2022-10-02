using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FunManagerEPP : MonoBehaviour
{
    public int siguienteEscena;

    public int cantidadEpp;
    public bool[] equiposAgarrados;

    [Header("====Objetos====")] 
    public GameObject[] epps;
    public FunLetreroSencillo letrero;
   
    [Header("====Audio====")]
    public AudioSource reproductor;
    public AudioClip[] audios;

    [Header("====Video====")]
    public GameObject videoIntro;

    [Header("====Imagenes====")]
    public GameObject[] imagenes;
    public AudioClip[] audiosEpp;
    public float[] tiemposDuracionImagenes;

    [Header("====Final====")]
    public GameObject aroParaRotos;
    public GameObject[] eppRotos;

    [Header("====Indicador====")]
    public GameObject[] indicadores;
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
        reproducirClip(audios[0]);
        yield return new WaitForSeconds(17.5f);
        reproducirClip(audios[1]);
        yield return new WaitForSeconds(3.5f);
        //REPRODUCIR VIDEO
        videoIntro.SetActive(true);
        yield return new WaitForSeconds(138.00f);//134 + 4
        //yield return new WaitForSeconds(3.00f);//version corta
        videoIntro.SetActive(false);
        reproducirClip(audios[2]);
        yield return new WaitForSeconds(21.0f);

        letrero.gameObject.SetActive(true);
        epps[0].GetComponent<BoxCollider>().enabled = true;
        epps[0].GetComponent<Rigidbody>().isKinematic = false;
    }

    public void reproducirClip(AudioClip clip)
    {
        reproductor.clip = clip;
        reproductor.Play();
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

        imagenes[pos].SetActive(true); //Muestra imagen
        reproducirClip(audiosEpp[pos]);
        yield return new WaitForSeconds(tiemposDuracionImagenes[pos]+0.3f); //Espera termina audio
        imagenes[pos].SetActive(false); //Oculta imagen
        
        if (pos!=cantidadEpp-1) //EN CASO NO SEA EL ULTIMO
        {
            indicadores[pos].SetActive(true);//Se activa el indicador
            letrero.cambiarObjetivo(epps[pos + 1]); //Cambias objetivo Letrero
            letrero.gameObject.SetActive(true); //Activar letrero

            //epps[pos + 1].enabled = true;//Activar agarrar otro Objeto
            epps[pos + 1].GetComponent<BoxCollider>().enabled = true;
            epps[pos + 1].GetComponent<Rigidbody>().isKinematic = false;
        }
        else //EN CASO SEA EL ULTIMO
        {
            aroParaRotos.SetActive(true);
            for (int i = 0; i < eppRotos.Length; i++)
            {
                eppRotos[i].GetComponent<BoxCollider>().enabled = true;
                eppRotos[i].GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
    public void tocarAroRoto() => StartCoroutine(tocaAroRoto());
    IEnumerator tocaAroRoto()
    {
        imagenes[7].SetActive(true); //Muestra imagen
        reproducirClip(audiosEpp[7]);
        yield return new WaitForSeconds(tiemposDuracionImagenes[7] + 0.3f); //Espera termina audio
        imagenes[7].SetActive(false); //Oculta imagen

        reproducirClip(audios[3]);
        yield return new WaitForSeconds(audios[3].length + 2.0f);
        //Cambia escenario
        SceneManager.LoadScene(siguienteEscena);
    }

}
