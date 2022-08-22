using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidenteImplementoTA : MonoBehaviour
{
    // Start is called before the first frame update
    public string nombreImplemento;
    public ObtenerImplementoTA app;
    public GameObject appUsado;
    public GameObject usuario;
    public Transform posicionReset;
    public Transform posicionAmbulancia;
    Vector3 posicionTomadaPos;
    Vector3 posicionTomadaRot;
    public bool coroutineEj;
    public ManagerTA manager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //usuario = other.gameObject;
            appUsado = app.appUsado;
            if (appUsado != null)
            {
                if (appUsado.name == nombreImplemento && !coroutineEj)
                {
                    coroutineEj = true;
                    StartCoroutine(AccidenteImplemento());
                }
            }
            if (appUsado == null)
            {
                if (!coroutineEj)
                {
                    coroutineEj = true;
                    StartCoroutine(AccidenteImplemento());
                }
            }
            
        }
    }

    IEnumerator AccidenteImplemento()
    {
        if (coroutineEj)
        {
            Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
            player.Velocidad(0f);
            yield return new WaitForSecondsRealtime(1.1f);

            player.StartCoroutine("TransitionLvlIn");

            yield return new WaitForSeconds(1.1f);
            PosicionarUsuario();
            player.StartCoroutine("TransitionLvlOut");
            yield return new WaitForSeconds(1f);
            player.Velocidad(1.5f);
            coroutineEj = false;
            
        }
        
    }

    public void PosicionarUsuario()
    {
        manager.vidas++;
        if (manager.vidas == manager.vidasMax)
        {
            posicionTomadaPos = posicionAmbulancia.position;
            posicionTomadaRot = posicionAmbulancia.eulerAngles;
            Debug.Log("ambulancia");
        }
        else
        {
            posicionTomadaPos = posicionReset.position;
            posicionTomadaRot = posicionReset.eulerAngles;
            Debug.Log("reset");
        }
        usuario.transform.position = posicionTomadaPos;
        usuario.transform.eulerAngles = posicionTomadaRot;
    }
}
