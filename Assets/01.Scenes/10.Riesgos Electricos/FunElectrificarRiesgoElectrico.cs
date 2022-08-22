using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunElectrificarRiesgoElectrico : MonoBehaviour
{
    public AudioClip clip;
    public GameObject Personaje;
    public GameObject electricidad;
    public Vector3 nuevaPosicionPersonaje;
    public Text textoMuerte;
    public string textoParaPoner;
    public GameObject letreroPaMuerte;
    public Vector3 rotacion;
    public bool primeraVez;
    public AudioClip locucionMuerte;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player")&&!primeraVez) //En caso se toque con las manos, se generan chispas y el usuario va a emergencia
        {
            primeraVez = true;
            GameObject.Find("NuevoControladorLocuciones").GetComponent<AudioSource>().PlayOneShot(clip);
            S_ControlEffect control = obj.GetComponentInChildren<S_ControlEffect>();
            control.VibracionPersonalizada(0.9f);
            electricidad.transform.position = obj.ClosestPoint(transform.position);
            electricidad.SetActive(true);
            StartCoroutine(mover());
        }
    }
    IEnumerator mover()
    {
        Movement movimiento = Personaje.GetComponent<Movement>();
        textoMuerte.text = textoParaPoner;
        yield return new WaitForSeconds(2f);
        movimiento.llamarTransitionIn();
        yield return new WaitForSeconds(2f);
        Personaje.transform.position = nuevaPosicionPersonaje;
        Personaje.transform.Rotate(rotacion);
        movimiento.Velocidad(0);
        letreroPaMuerte.SetActive(true);       
        movimiento.llamarTransitionOut();
        yield return new WaitForSeconds(1);
        source.clip = locucionMuerte;
        source.Play();
    }
}
