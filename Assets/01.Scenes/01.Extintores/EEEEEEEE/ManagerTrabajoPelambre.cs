using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerTrabajoPelambre : MonoBehaviour
{
    public int esteEscenario;
    public int siguienteEscenario;
    public FunBotalGiratorio botalGiratorio;
    [Header("Accidente")]

    public AudioSource reproductorAccidentes;
    public bool sufriAccidente;
    public Movement personaje;
    public GameObject nuevaPos;
    public GameObject nuevaPosAccidente;
    public GameObject esferaAccidente;
    public S_ControlEffect manoDerecha;
    public S_ControlEffect manoIzquierda;

    [Header("Validacion Epps")]
    public bool[] eppsColocados;
    public bool todosEPPColocados;

    [Header("UI")]
    public GameObject gif_Like;
    public GameObject btn_ConfirmarExtintor;
    public GameObject letrero_RiesgoQuimico;

    public GameObject texto_Quimicos;
    public GameObject texto_pasaron10Minutos;
    public GameObject texto_pasaron25Minutos;
    public GameObject texto_pasaron30Minutos;    
   // public GameObject[] indicadores_Agarrar;

    public GameObject indicador_Trapeador;

    [Header("Objetos Secuencia")]       
    public GameObject[] epps;
    public GameObject[] snapzones;
    public GameObject[] quimicosColocables;

    public GameObject aroAzul;
    public GameObject agua;
    public GameObject collidersAgua;
    public GameObject trapeador;

    [Header("Audios")]
    public AudioSource reproductor;
    public AudioClip[] audiosAccidentes;
    public AudioClip audioGrito;
    public AudioClip[] audiosSecuencia;

    [Header("Validacion Maquina")]
    public GameObject[] primerosBotones;
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
    public float reproducirAudio(int numero)
    {
        reproductor.clip = audiosSecuencia[numero];
        reproductor.Play();
        return audiosSecuencia[numero].length;
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
                    llamarEmpezarTarea(2);

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
    public void tocarBotalGirando() => StartCoroutine(accidente(false));
    public void colocarEppRoto() => StartCoroutine(accidente(true));
    //IEnumerator accidente(bool esPorEpp)
    //{
    //    personaje.Velocidad(0);
    //    if (esPorEpp)
    //    {
    //        manoDerecha.VibracionPersonalizada(0.3f);
    //        manoIzquierda.VibracionPersonalizada(0.3f);
    //    }
    //    //else //Si es por aplastamiento
    //    //{
    //    //    manoDerecha.VibracionPersonalizada(0.6f);
    //    //    manoIzquierda.VibracionPersonalizada(0.6f);

    //    //    reproductor.clip = audioGrito;
    //    //    reproductor.Play();
    //    //    esferaAccidente.SetActive(true);
    //    //    yield return new WaitForSeconds(2.0f);
    //    //}
    //    if (esPorEpp)
    //    {
    //        reproductor.clip = audiosAccidentes[0];
    //    }
    //    //else //Si es por aplastamiento
    //    //{
    //    //    reproductor.clip = audiosAccidentes[2];
    //    //}
    //    reproductor.Play();
    //    personaje.llamarTransitionIn();
    //    yield return new WaitForSeconds(1.0f);

    //    //personaje.gameObject.transform.position = nuevaPos.transform.position;

    //    //if (!esPorEpp)//Si es por aplastamiento
    //    //{
    //    //    personaje.gameObject.transform.Rotate(new Vector3(0, 1, 0), 90);
    //    //}

    //    //yield return new WaitForSeconds(1.0f);
    //    //esferaAccidente.SetActive(false);
    //    //personaje.llamarTransitionOut();
    //    //reproducir audio reintentalo 
    //    SceneManager.LoadScene(esteEscenario);
    //    //REINICIAR AUTOMATICO
    //}

    IEnumerator accidente(bool esPorEpp)
    {
        sufriAccidente = true;
        reproductor.volume = 0;
        personaje.Velocidad(0);
        if (esPorEpp)
        {
            manoDerecha.VibracionPersonalizada(0.3f);
            manoIzquierda.VibracionPersonalizada(0.3f);

            reproductorAccidentes.clip = audiosAccidentes[0];
        }
        else //Si es por aplastamiento
        {
            manoDerecha.VibracionPersonalizada(0.6f);
            manoIzquierda.VibracionPersonalizada(0.6f);

            reproductorAccidentes.clip = audioGrito;
            reproductorAccidentes.Play();
            esferaAccidente.SetActive(true);
            yield return new WaitForSeconds(2.0f);

            reproductorAccidentes.clip = audiosAccidentes[2];
        }

        reproductorAccidentes.Play();
        personaje.llamarTransitionIn();
        yield return new WaitForSeconds(1.0f);

        if (!esPorEpp)//Si es por aplastamiento
        {
            personaje.gameObject.transform.position = nuevaPosAccidente.transform.position;
            personaje.gameObject.transform.Rotate(new Vector3(0, 1, 0), 90);
            yield return new WaitForSeconds(1.0f);
            esferaAccidente.SetActive(false);
        }

        personaje.llamarTransitionOut();
        yield return new WaitForSeconds(17f);
        //REINICIAR AUTOMATICO
        SceneManager.LoadScene(esteEscenario);
    }

    public void llamarEmpezarTarea(int numero) => StartCoroutine(empezarTarea(numero));
    IEnumerator empezarTarea(int numero)
    {
        switch (numero)
        {
            case 0://Al iniciar se completa este
                yield return new WaitForSeconds(3f);
                gif_Like.SetActive(true);
                yield return new WaitForSeconds(reproducirAudio(0) + 0.3f);        //reproduce audio y espera tiempo de duración
                gif_Like.SetActive(false);

                yield return new WaitForSeconds(reproducirAudio(1) + 0.3f);
                //Habilita tocar confirmar extintor
                btn_ConfirmarExtintor.SetActive(true);

                break;

            case 1://Tocar confirmar extintor
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(2) + 0.3f);
                //                                                                              FALTA TP
                if (!sufriAccidente)
                {
                    personaje.transform.position = nuevaPos.transform.position;
                }
                
                yield return new WaitForSeconds(reproducirAudio(3) + 0.3f);

                //Habilitar EPPS
                activarEPPs();

                break;

            case 2://Colocarse EPPs
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(4) + 0.3f);

                
                letrero_RiesgoQuimico.SetActive(true);
                yield return new WaitForSeconds(reproducirAudio(5) + 0.3f);
                letrero_RiesgoQuimico.SetActive(false);

                //Habilita Aro Azul
                aroAzul.SetActive(true);
                yield return new WaitForSeconds(reproducirAudio(6) + 0.3f);

                break;

            case 3://Toca Aro Azul
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(7) + 0.3f);

                texto_Quimicos.SetActive(true);

                //Habilita Agarrar Bactericida
                yield return new WaitForSeconds(reproducirAudio(8) + 0.3f);
                quimicosColocables[0].SetActive(true);

                break;

            case 4://Agarra Bactericida
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(9) + 0.3f);
                //Habilita Colocar Bactericida
                snapzones[0].SetActive(true);

                break;

            case 5://Coloca Bactericida
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(10) + 0.3f);

                //Habilita Agarrar Humectante
                quimicosColocables[1].SetActive(true);

                break;

            case 6://Agarra Humectante
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(11) + 0.3f);

                //Habilita Colocar Humectante
                snapzones[1].SetActive(true);
                break;

            case 7://Coloca Humectante
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(12) + 0.3f);
                //Habilita Boton Inicio Maquina
                primerosBotones[0].SetActive(true);

                break;

            case 8://Toca boton Inicio Maquina
                yield return new WaitForSeconds(0.5f);
                //                                                               gira 
                botalGiratorio.empezarGirar();
                yield return new WaitForSeconds(3.00f);
                if (!sufriAccidente) { 
                    personaje.llamarTransitionIn();
                    yield return new WaitForSeconds(1.00f);
                    //                                                               tp
                    personaje.transform.position = nuevaPos.transform.position;
                    agua.SetActive(true);
                    personaje.llamarTransitionOut();
                }
                //                                                              PARAR GIRO
                botalGiratorio.dejarGirar();
                texto_pasaron30Minutos.SetActive(true);
                yield return new WaitForSeconds(reproducirAudio(13) + 0.3f);
                texto_pasaron30Minutos.SetActive(false);

                //Habilita Limpiar
                trapeador.SetActive(true);
                indicador_Trapeador.SetActive(true);
                yield return new WaitForSeconds(reproducirAudio(14) + 0.3f);         
                
                collidersAgua.SetActive(true);
                break;

            case 10://Limpia
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(15) + 0.3f);
                //Habilita agarrar desengrasante 
                quimicosColocables[2].SetActive(true);
                break;

            case 11://Agarrar Desengrasante
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(16) + 0.3f);
                //Habilita Colocar Desengrasante
                snapzones[2].SetActive(true);
                break;

            case 12://Coloca Desengrasante
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(17) + 0.3f);
                //Habilita tocar boton
                primerosBotones[1].SetActive(true);
                break;

            case 13://Toca boton
                yield return new WaitForSeconds(0.5f);
                //                                                               gira 
                botalGiratorio.empezarGirar();
                yield return new WaitForSeconds(reproducirAudio(18) + 0.3f);

                //Habilita Agarrar Soda Caustica
                quimicosColocables[3].SetActive(true);

                break;

            case 14://Agarra Soda Caustica
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(19) + 0.3f);

                //Habilita Colocar Soda Caustica
                snapzones[3].SetActive(true);
                break;

            case 15://Coloca Soda Caustica
                yield return new WaitForSeconds(2.00f);
                personaje.llamarTransitionIn();
                yield return new WaitForSeconds(1.00f);
                if (!sufriAccidente)
                {
                    //                                                               tp
                    personaje.transform.position = nuevaPos.transform.position;
                
                    botalGiratorio.dejarGirar();
                    //                                                               PARAR MAQUINA
                    personaje.llamarTransitionOut();
                }
                texto_pasaron30Minutos.SetActive(true);
                yield return new WaitForSeconds(reproducirAudio(20) + 0.3f);
                texto_pasaron30Minutos.SetActive(false);

                //Habilita Agarrar Bactericida
                quimicosColocables[4].SetActive(true);
                break;

            case 16://Agarra Bactericida
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(21) + 0.3f);

                //Habilita Colocar Bactericida
                snapzones[4].SetActive(true);
                break;

            case 17://Coloca Bactericida
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(reproducirAudio(22) + 0.3f);

                //Habilita tocar boton
                //                                                                      FALTA REINICIAR BOTON
                primerosBotones[2].SetActive(true);

                break;
            case 18://Toca boton
                //                                                                      gira 
                botalGiratorio.empezarGirar();
                yield return new WaitForSeconds(3.00f);
                if (!sufriAccidente)
                {
                    personaje.llamarTransitionIn();
                    yield return new WaitForSeconds(1.00f);
                    //                                                                      tp
                    //                                                                      PARAR GIRAR
                    personaje.transform.position = nuevaPos.transform.position;

                    botalGiratorio.dejarGirar();
                    personaje.llamarTransitionOut();
                }
                yield return new WaitForSeconds(reproducirAudio(23) + 0.3f);
                //Habilita Agarrar Sulfuro Sodio
                yield return new WaitForSeconds(reproducirAudio(24) + 0.3f);
                quimicosColocables[5].SetActive(true);
                break;

            case 19://Agarra Sulfuro Sodio
                yield return new WaitForSeconds(0.5f);

                //Habilita Colocar Sulfuro Sodio
                yield return new WaitForSeconds(reproducirAudio(25) + 0.3f);
                snapzones[5].SetActive(true);
                break;

            case 20://Coloca Sulfuro Sodio
                yield return new WaitForSeconds(0.5f);
                //Habilita Agarrar Humectante
                yield return new WaitForSeconds(reproducirAudio(26) + 0.3f);
                quimicosColocables[6].SetActive(true);

                break;

            case 21://Agarra Humectante
                yield return new WaitForSeconds(0.5f);
                //Habilita Colocar Humectante
                yield return new WaitForSeconds(reproducirAudio(27) + 0.3f);
                snapzones[6].SetActive(true);
                break;

            case 22://Coloca Humectante
                yield return new WaitForSeconds(0.5f);
                //Habilita Agarrar Amina
                yield return new WaitForSeconds(reproducirAudio(28) + 0.3f);
                quimicosColocables[7].SetActive(true);
                break;

            case 23://Agarra Amina
                yield return new WaitForSeconds(0.5f);
                //Habilita Colocar Amina
                yield return new WaitForSeconds(reproducirAudio(29) + 0.3f);
                snapzones[7].SetActive(true);
                break;

            case 24://Coloca Amina
                yield return new WaitForSeconds(0.5f);
                //Habilita Tocar Boton
                yield return new WaitForSeconds(reproducirAudio(30) + 0.3f);
                //                                                                      FALTA REINICIAR BOTON
                primerosBotones[3].SetActive(true);
                break;

            case 25://Toca Boton
                yield return new WaitForSeconds(0.5f);
                //                                                                      gira 
                botalGiratorio.empezarGirar();
                yield return new WaitForSeconds(3.00f);
                if (!sufriAccidente)
                {
                    personaje.llamarTransitionIn();
                    yield return new WaitForSeconds(1.00f);
                    //                                                                      tp
                    //                                                                      PARAR GIRAR
                    personaje.transform.position = nuevaPos.transform.position;
                
                    botalGiratorio.dejarGirar();
                    yield return new WaitForSeconds(1.00f);
                    personaje.llamarTransitionOut();
                }
                //Habilita Agarrar Cal
                texto_pasaron30Minutos.SetActive(true);
                yield return new WaitForSeconds(reproducirAudio(31) + 0.3f);
                texto_pasaron30Minutos.SetActive(false);

                quimicosColocables[8].SetActive(true);

                break;

            case 26://Agarra Cal
                yield return new WaitForSeconds(0.5f);

                //Habilita Colocar Cal
                yield return new WaitForSeconds(reproducirAudio(32) + 0.3f);
                snapzones[8].SetActive(true);
                break;

            case 27://Coloca Cal
                //Habilita Agarrar Sulfuro de sodio
                yield return new WaitForSeconds(reproducirAudio(33) + 0.3f);

                quimicosColocables[9].SetActive(true);

                break;

            case 28:// Agarra Sulfuro de sodio
                yield return new WaitForSeconds(0.5f);

                //Habilita Colocar Sulfuro de sodio
                yield return new WaitForSeconds(reproducirAudio(34) + 0.3f);
                snapzones[9].SetActive(true);
                break;

            case 29:// Coloca Sulfuro de sodio
                yield return new WaitForSeconds(0.5f);
                //Habilita tocar boton
                yield return new WaitForSeconds(reproducirAudio(35) + 0.3f);
                //                                                                      FALTA REINICIAR BOTON
                primerosBotones[4].SetActive(true);


                break;

            case 30://Toca boton
                yield return new WaitForSeconds(0.5f);
                //                                                                      gira 
                botalGiratorio.empezarGirar();
                yield return new WaitForSeconds(3.00f);
                if (!sufriAccidente)
                {
                    personaje.llamarTransitionIn();
                    //                                                                      tp
                    //                                                                      PARAR GIRAR
                    yield return new WaitForSeconds(1.00f);
                    personaje.transform.position = nuevaPos.transform.position;
                
                    botalGiratorio.dejarGirar();
                    yield return new WaitForSeconds(1.00f);
                    personaje.llamarTransitionOut();
                }
                //Habilita agarrar sulfuro de sodio
                texto_pasaron25Minutos.SetActive(true);
                yield return new WaitForSeconds(reproducirAudio(36) + 0.3f);
                texto_pasaron25Minutos.SetActive(false);

                quimicosColocables[10].SetActive(true);

                break;

            case 31://Agarra sulfuro de sodio
                yield return new WaitForSeconds(0.5f);
                //Habilita Colocar Sulfuro de sodio
                yield return new WaitForSeconds(reproducirAudio(37) + 0.3f);                
                snapzones[10].SetActive(true);
                break;

            case 32://Coloca Sulfuro de sodio
                yield return new WaitForSeconds(0.5f);
                //Habilita Agarrar Cal
                yield return new WaitForSeconds(reproducirAudio(38) + 0.3f);
                quimicosColocables[11].SetActive(true);

                break;

            case 33://Agarra Cal
                yield return new WaitForSeconds(0.5f);

                //Habilita Colocar Cal
                yield return new WaitForSeconds(reproducirAudio(39) + 0.3f);
                snapzones[11].SetActive(true);
                break;

            case 34://Coloca Cal
                yield return new WaitForSeconds(0.5f);

                //Habilita tocar boton
                yield return new WaitForSeconds(reproducirAudio(40) + 0.3f);
                //                                                                      FALTA REINICIAR BOTON
                primerosBotones[5].SetActive(true);
                break;

            case 35://Toca boton
                yield return new WaitForSeconds(0.5f);
                //                                                                      gira 
                botalGiratorio.empezarGirar();
                yield return new WaitForSeconds(3.00f);
                if (!sufriAccidente)
                {
                    personaje.llamarTransitionIn();
                    //                                                                      tp
                    yield return new WaitForSeconds(1.00f);
                    personaje.transform.position = nuevaPos.transform.position;
                
                    yield return new WaitForSeconds(1.00f);

                    personaje.llamarTransitionOut();
                }

                //Habilita tocar SEGUNDO boton
                texto_pasaron10Minutos.SetActive(true);
                yield return new WaitForSeconds(reproducirAudio(41) + 0.3f);
                texto_pasaron10Minutos.SetActive(false);
          
                segundoBoton.SetActive(true);


                break;

            case 36:// toca SEGUNDO boton
                yield return new WaitForSeconds(0.5f);
                //                                                                      PARAR GIRAR
                botalGiratorio.dejarGirar();
                yield return new WaitForSeconds(reproducirAudio(42) + 0.3f);
                yield return new WaitForSeconds(2f);
                Debug.Log("Se acabo");
                //Cambiar Escenario
                if (siguienteEscenario != -1)
                {
                    SceneManager.LoadScene(siguienteEscenario);
                }
               
                break;
        }
    }
}
