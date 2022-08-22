using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class FunManagerOxicorteAccidente : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject panelSiguienteEscenario;
    public AudioSource reproductor;
    public AudioClip [] locuciones;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(esperaAnimacion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator esperaAnimacion()
    {
        reproductor.PlayOneShot(locuciones[0]);
        yield return  new WaitForSeconds(5.00f);
        director.Play();
        yield return new WaitForSeconds(7.20f);
        reproductor.PlayOneShot(locuciones[1]);
        yield return new WaitForSeconds(3.00f);
        reproductor.PlayOneShot(locuciones[2]);
        yield return new WaitForSeconds(6.00f);
        panelSiguienteEscenario.SetActive(true);
    }
    public void siguienteEscenario()
    {
        SceneManager.LoadScene(4);
    }
}
