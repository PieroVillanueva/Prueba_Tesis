using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FunManagerOxicorte_Trabajo : MonoBehaviour
{
    public GameObject esferaAccidente;
    public Movement movimiento;
    public bool ocurrioAccidente;
    [Header("AUDIOS")]
    public AudioSource reproductor;
    public AudioClip[] locuciones;
    public AudioClip audioAccidente;
    [Header("ACTIVABLES")]
    public GameObject obj_video;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(esperaInicial());
        StartCoroutine(aparecerVideo());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator aparecerVideo()
    {
        yield return new WaitForSeconds(14.00f);
        obj_video.SetActive(true);
        yield return new WaitForSeconds(20.00f);
        reproductor.PlayOneShot(locuciones[1]);
    }


    IEnumerator esperaInicial()
    {
        yield return new WaitForSeconds(2.00f);
        reproductor.PlayOneShot(locuciones[0]);
    }
    /*IEnumerator esperaFinal()
    {
        yield return new WaitForSeconds(1.00f);
        reproductor.PlayOneShot(locuciones[1]);
    }
    public void completarNivel()
    {
        StartCoroutine(esperaFinal());
    }*/
    public void accidentePorExplosion()//listo
    {
        StartCoroutine(esperaAccidente(2));
    }
    public void accidentePorTocarFlama()//listo
    {
        StartCoroutine(esperaAccidente(3));
    }
    public void accidentePorFuego()//listo
    {
        StartCoroutine(esperaAccidente(4));
    }
    public void accidentePorEpp()//listo
    {
        StartCoroutine(esperaAccidente(5));
    }

    IEnumerator esperaAccidente(int indiceAccidente)
    {
        if (!ocurrioAccidente) {
            ocurrioAccidente = true;
            movimiento.speed = 0;
            yield return new WaitForSeconds(0.40f);
            reproductor.PlayOneShot(audioAccidente);
            esferaAccidente.SetActive(true);            
            yield return new WaitForSeconds(2.40f);
            reproductor.PlayOneShot(locuciones[indiceAccidente]);

            yield return new WaitForSeconds(14.20f);
            SceneManager.LoadScene(5); //REINICIAR
        }
    }
}