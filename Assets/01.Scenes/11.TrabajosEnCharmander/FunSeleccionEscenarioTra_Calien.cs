using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FunSeleccionEscenarioTra_Calien : MonoBehaviour
{
    public GameObject[] listaSeleccionados;
    public int seleccionado;

    public AudioSource reproductor;
    public AudioSource reproductorIndividual;

    public AudioClip[] primerasLocusiones;

    // Start is called before the first frame update
    void Start()
    {
        seleccionado = 3;
        StartCoroutine(locusionesIniciales());
    }

    // Update is called once per frame
    void Update()
    {       

    }

    IEnumerator locusionesIniciales()
    {
        reproductor.clip = primerasLocusiones[0];
        reproductor.Play();
        yield return new WaitForSeconds(7);
        reproductor.clip = primerasLocusiones[1];
        reproductor.Play();
        yield return new WaitForSeconds(15);
        reproductor.clip = primerasLocusiones[2];
        reproductor.Play();
        yield return new WaitForSeconds(12.5f);
        reproductor.clip = primerasLocusiones[3];
        reproductor.Play();
    }
    IEnumerator locusionError()
    {
        if (reproductor.isPlaying)
        {
            reproductor.volume = 0.30f;
        }
        reproductorIndividual.Play();
        yield return new WaitForSeconds(4);
        reproductor.volume = 1;
    }
    public void seleccionarUno(int selectionado)
    {
        for (int i = 0; i < listaSeleccionados.Length; i++)
        {
            listaSeleccionados[i].SetActive(false);
        }
        listaSeleccionados[selectionado].SetActive(true);

        seleccionado = selectionado;
    }
    public void cambiarEscenario()
    {
        switch (seleccionado)
        {
            case 0:
                SceneManager.LoadScene(3);
                break;
            case 1:
                SceneManager.LoadScene(4);
                break;
            case 2:
                SceneManager.LoadScene(5);
                break;
            case 3:
                StartCoroutine(locusionError());
                break;
        }
        
    }
}
