using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FunManagerSecadoAlVacio : MonoBehaviour
{
    public int estaEscena;
    public int siguienteEscena;
    [Header("Accidente")]
    public Movement personaje;
    public GameObject nuevaPos;
    public GameObject esferaAccidente;
    public S_ControlEffect manoDerecha;
    public S_ControlEffect manoIzquierda;

    [Header("Validacion Epps")]
    public bool[] eppsColocados;
    public bool todosEPPColocados;

    [Header("Audios")]
    public AudioSource reproductor;
    public AudioClip[] audiosAccidentes;
    public AudioClip audioGrito;
    public AudioClip[] audiosSecuencia;

    [Header("Objetos Secuencia")]
    public GameObject letreroAplastamiento;
    public GameObject btn_ConfirmarExtintor;
    public BoxCollider trapeador;
    public GameObject senalTrapeador;
    public GameObject[] epps;

    [Header("Objetos Maquina")]
    public FunPlanchaSecadoVacio planchaArriba;
    public FunPlanchaSecadoVacio planchaAbajo;
    public GameObject aroAzul;

    public GameObject piel1;
    public GameObject piel2;
    public GameObject letreroPiel1;
    public GameObject letreroPiel2;
    public GameObject espacioPrimeraPiel;
    public GameObject espacioSegundaPiel;

    [Header("Validacion Maquina")]
    public GameObject primerBoton;
    public GameObject segundoBoton;


    // Start is called before the first frame update
    void Start()
    {
        llamarEmpezarTarea(0);
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
                    llamarEmpezarTarea(3);
                }
            }
        }
    }
    public void colocarEppRoto() => StartCoroutine(accidente(true));
    public void aplastamientoManos() => StartCoroutine(accidente(false));
    IEnumerator accidente(bool esPorEpp)
    {
        personaje.Velocidad(0);
        if (esPorEpp) {
            manoDerecha.VibracionPersonalizada(0.3f);
            manoIzquierda.VibracionPersonalizada(0.3f);
        }
        else //Si es por aplastamiento
        {
            manoDerecha.VibracionPersonalizada(0.6f);
            manoIzquierda.VibracionPersonalizada(0.6f);
        }
        reproductor.clip = audioGrito;
        reproductor.Play();
        esferaAccidente.SetActive(true);

        yield return new WaitForSeconds(2.0f);
        if (esPorEpp) 
        {
            reproductor.clip = audiosAccidentes[0];
        }
        else //Si es por aplastamiento
        {
            reproductor.clip = audiosAccidentes[2];
        }
        reproductor.Play();
        personaje.llamarTransitionIn();
        yield return new WaitForSeconds(1.0f);
        personaje.gameObject.transform.position = nuevaPos.transform.position;

        if (!esPorEpp)//Si es por aplastamiento
        {
            personaje.gameObject.transform.Rotate(new Vector3(0, 1, 0), 90);
        }

        yield return new WaitForSeconds(1.0f);
        esferaAccidente.SetActive(false);
        personaje.llamarTransitionOut();
        yield return new WaitForSeconds(16f);
        //REINICIAR AUTOMATICO
        SceneManager.LoadScene(estaEscena);
    }


    public void activarEPPs()
    {
        for (int i = 0; i < epps.Length; i++)
        {
            epps[i].GetComponent<BoxCollider>().enabled = true;
            epps[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void llamarEmpezarTarea(int numero) => StartCoroutine(empezarTarea(numero));
    IEnumerator empezarTarea(int numero)
    {
        switch (numero)
        {
            case 0://Al iniciar se completa este
                yield return new WaitForSeconds(3f);
                reproducirAudio(0);
                yield return new WaitForSeconds(audiosSecuencia[0].length+0.4f);
                // HABILITA LIMPIAR --
                reproducirAudio(1);

                senalTrapeador.SetActive(true);
                trapeador.enabled = true;


                yield return new WaitForSeconds(audiosSecuencia[1].length + 0.4f);


                break;
            case 1:  //Se limpia
                yield return new WaitForSeconds(0.5f);
                btn_ConfirmarExtintor.SetActive(true);


                reproducirAudio(2);
                yield return new WaitForSeconds(audiosSecuencia[2].length + 0.4f);
                //HABILITA LETRERO EXTINTOR --
                

                break;
            case 2: //Toca extintor
                yield return new WaitForSeconds(0.5f);
                reproducirAudio(3);
                yield return new WaitForSeconds(audiosSecuencia[3].length + 0.4f);
                reproducirAudio(4);
                yield return new WaitForSeconds(audiosSecuencia[4].length + 0.4f);
                //HABILITA COLOCARTE EPPs
                activarEPPs();


                break;
            case 3: //Colocarte EPPs
                yield return new WaitForSeconds(0.5f);
                reproducirAudio(5);
                yield return new WaitForSeconds(audiosSecuencia[5].length + 0.4f);
                //HABILITA LETRERO RIESGO MECANICO --
                letreroAplastamiento.SetActive(true);
                reproducirAudio(6);
                yield return new WaitForSeconds(audiosSecuencia[6].length + 0.4f);
                letreroAplastamiento.SetActive(false);
                reproducirAudio(7);
                yield return new WaitForSeconds(audiosSecuencia[7].length + 0.4f);
                //HABILITA ARO AZUL --
                aroAzul.SetActive(true);

                break;
            case 4: //Toca Aro Azul
                yield return new WaitForSeconds(0.5f);
                reproducirAudio(8);
                yield return new WaitForSeconds(audiosSecuencia[8].length + 0.4f);
                //HABILITA COLOCAR PIEL EN BASE MAQUINA --
                espacioPrimeraPiel.SetActive(true);
                piel1.GetComponent<BoxCollider>().enabled = true;
                piel1.GetComponent<Rigidbody>().isKinematic = false;
                letreroPiel1.SetActive(true);

                break;
            case 5: //Coloca piel en base maquina
                yield return new WaitForSeconds(0.5f);
                reproducirAudio(9);
                yield return new WaitForSeconds(audiosSecuencia[9].length + 0.4f);
                //HABILITA ESTIRAR -- Ya se hace en el snapzone


                break;
            case 6: //Se estira la piel
                yield return new WaitForSeconds(0.5f);
                reproducirAudio(10);
                yield return new WaitForSeconds(audiosSecuencia[10].length + 0.4f);
                //HABILITA PRESIONAR BOTON
                primerBoton.SetActive(true);

                break;
            case 7: //Presiona boton
                yield return new WaitForSeconds(0.5f);
                reproducirAudio(11);
                yield return new WaitForSeconds(audiosSecuencia[11].length + 0.4f);
                yield return new WaitForSeconds(4f);
                //HABILITA COLOCAR SEGUNDA PIEL
                espacioSegundaPiel.SetActive(true);
                piel2.GetComponent<BoxCollider>().enabled = true;
                piel2.GetComponent<Rigidbody>().isKinematic = false;
                letreroPiel2.SetActive(true);

                break;
            case 8: //Coloca segunda piel
                yield return new WaitForSeconds(0.5f);
                reproducirAudio(12);
                yield return new WaitForSeconds(audiosSecuencia[12].length + 0.4f);
                //HABILITA EXPANDIR SEGUNDA PIEL

                break;
            case 9: //Expande segunda piel
                yield return new WaitForSeconds(0.5f);
                reproducirAudio(13);
                yield return new WaitForSeconds(audiosSecuencia[13].length + 0.4f);
                //HABILITA PRESIONAR BOTON SEGUNDA VEZ
                segundoBoton.SetActive(true);
                break;
            case 10: //Presiona boton segunda vez
                yield return new WaitForSeconds(0.5f);
                reproducirAudio(14);
                yield return new WaitForSeconds(audiosSecuencia[14].length + 0.4f);
                //SALIDAAAAAAAAAA
                yield return new WaitForSeconds(2f);

                if (siguienteEscena>-1)
                {
                    SceneManager.LoadScene(siguienteEscena);
                }
                break;

        }
    }
}
