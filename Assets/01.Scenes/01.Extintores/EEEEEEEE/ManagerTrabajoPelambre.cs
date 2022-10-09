using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTrabajoPelambre : MonoBehaviour
{
    [Header("Accidente")]
    public Movement personaje;
    public GameObject nuevaPos;
    public GameObject esferaAccidente;
    public S_ControlEffect manoDerecha;
    public S_ControlEffect manoIzquierda;

    [Header("Validacion Epps")]
    public bool[] eppsColocados;
    public bool todosEPPColocados;

    [Header("Objetos Secuencia")]
    public GameObject letreroAplastamiento;
    public GameObject btn_ConfirmarExtintor;
    public BoxCollider trapeador;
    public GameObject senalTrapeador;
    public GameObject[] epps;


    [Header("Audios")]
    public AudioSource reproductor;
    public AudioClip[] audiosAccidentes;
    public AudioClip audioGrito;
    public AudioClip[] audiosSecuencia;

    [Header("Validacion Maquina")]
    public GameObject primerBoton;
    public GameObject segundoBoton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reproducirAudio(int numero)
    {
        reproductor.clip = audiosSecuencia[numero];
        reproductor.Play();
    }
    private bool validarArreglo(bool[] arreglo)
    {
        for (int i = 0; i < eppsColocados.Length; i++)
        {
            if (!arreglo[i])
            {
                return false;
            }
        }
        return true;
    }
    public void colocarseEpp(int pos) //Al colocarse EPP
    {
        if (!eppsColocados[pos])
        {
            eppsColocados[pos] = true;

            if (validarArreglo(eppsColocados))
            {
                if (!todosEPPColocados)
                {
                    todosEPPColocados = true;

                }
            }
        }
    }
    public void activarEPPs()
    {
        for (int i = 0; i < epps.Length; i++)
        {
            epps[i].GetComponent<BoxCollider>().enabled = true;
            epps[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public void colocarEppRoto() => StartCoroutine(accidente(true));
    IEnumerator accidente(bool esPorEpp)
    {
        personaje.Velocidad(0);
        if (esPorEpp)
        {
            manoDerecha.VibracionPersonalizada(0.3f);
            manoIzquierda.VibracionPersonalizada(0.3f);
        }
        //else //Si es por aplastamiento
        //{
        //    manoDerecha.VibracionPersonalizada(0.6f);
        //    manoIzquierda.VibracionPersonalizada(0.6f);

        //    reproductor.clip = audioGrito;
        //    reproductor.Play();
        //    esferaAccidente.SetActive(true);
        //    yield return new WaitForSeconds(2.0f);
        //}
        if (esPorEpp)
        {
            reproductor.clip = audiosAccidentes[0];
        }
        //else //Si es por aplastamiento
        //{
        //    reproductor.clip = audiosAccidentes[2];
        //}
        reproductor.Play();
        personaje.llamarTransitionIn();
        yield return new WaitForSeconds(1.0f);
        personaje.gameObject.transform.position = nuevaPos.transform.position;

        //if (!esPorEpp)//Si es por aplastamiento
        //{
        //    personaje.gameObject.transform.Rotate(new Vector3(0, 1, 0), 90);
        //}

        yield return new WaitForSeconds(1.0f);
        esferaAccidente.SetActive(false);
        personaje.llamarTransitionOut();
        //reproducir audio reintentalo 

        //REINICIAR AUTOMATICO
    }
}
