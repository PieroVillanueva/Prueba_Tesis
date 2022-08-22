using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager_RCP : Lvl_Manager
{
    public Animator anima;
    public Animator animaPersoPiso;
    public FunCheckListConColor checkListActividades;
    public FunCheckListConColor checkListActividades2;
    public FunCheckListConColor checkListActividades3;
    public GameObject panelRondas;
    public GameObject[] manosHombros;
    public GameObject colliderHombros;

    public GameObject letreroAyuda;
    public GameObject[] manosParaAbrirBoca;
    public GameObject[] espacioParaAbrirBoca;
    public FunFuncionalidadesRCP funcionalidades;
    public GameObject[] boca_Oido;

    public GameObject[] espacioManosCompresiones;
    public Text contadorCompresionesTEXT;
    public FunContar funContar;
    public FunBoca bocaCollider;

    public GameObject letreroFinal;
    public Text contadorRepeticiones;

    public GameObject[] personajeYMesa;
    public GameObject muerto;
    public SkinnedMeshRenderer skin;

    public GameObject letreroMover;
    public Movement movimientoPJ;

    public GameObject[] cubosPersonajes;
    public GameObject cuello;
    public GameObject manoCuello;
    public GameObject camilla;
    public GameObject sillones;
    public GameObject cableElectrificado;
    public override void Start()
    {
        //Ejecuta las lineas que heredo
        //base.Start();
        totalTareas = audioController.locuciones.Length;

        StartCoroutine(esperaInicio());
        //StartCoroutine(aperturaDeBoca());
        //StartCoroutine(aperturaDeOjos());
    }

    public override void CumplirTarea(int indexTarea)
    {
        base.CumplirTarea(indexTarea);

        StartCoroutine(Tareas(actualTarea));
    }
    public void cambiarColor(GameObject cambiante, bool azul)
    {
        if (azul)
        {
             cambiante.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_UseColorMap", 0);
             cambiante.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_EMISSION", 1);
        }
        else
        {
             cambiante.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_UseColorMap", 1);
             cambiante.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_EMISSION", 0);
        }
    }
    IEnumerator esperaInicio()
    {
        yield return new WaitForSecondsRealtime(5.00f);
        iniciarNivelDelay();
        StartCoroutine(Tareas(actualTarea));
        
    }

    IEnumerator aperturaDeBoca()
    {
        while (skin.GetBlendShapeWeight(1)<100)
        {
            yield return new WaitForSeconds(0.033f);
            skin.SetBlendShapeWeight(1, skin.GetBlendShapeWeight(1)+5);
        }
    }
    IEnumerator aperturaDeOjos()
    {
        while (skin.GetBlendShapeWeight(0) > 0)
        {
            yield return new WaitForSeconds(0.033f);
            skin.SetBlendShapeWeight(0, skin.GetBlendShapeWeight(0) - 5);
        }
    }
    IEnumerator cerrarVista()
    {
        movimientoPJ.llamarTransitionIn();
        yield return new WaitForSeconds(0.5f);
        movimientoPJ.llamarTransitionOut();
    }

    IEnumerator Tareas(int tarea)
    {
        switch (tarea)
        {
            /*
            case 0://TOCAR HOMBRO
                yield return new WaitForSecondsRealtime(4.00f);

                cambiarColor(manosHombros[0], true);
                cambiarColor(manosHombros[1], true);
                manosHombros[0].SetActive(true);
                manosHombros[1].SetActive(true);
                colliderHombros.SetActive(true);//se desactiva solo

                break;
            case 1://MOVER MESA
                animaPersoPiso.SetTrigger("sacudidaLeve");
                checkListActividades.activarUltimoCheck();
                letreroMover.SetActive(true);
             
                break;
              case 2://oir respiracion
                StartCoroutine(cerrarVista());
                yield return new WaitForSecondsRealtime(0.5f);
                muerto.SetActive(false);
                camilla.SetActive(true);
                sillones.SetActive(true);
                personajeYMesa[1].SetActive(true);
                cubosPersonajes[0].transform.position += new Vector3(-1.9f, 0, 0);
                cubosPersonajes[1].transform.position += new Vector3(-1.9f, 0, 0);
                checkListActividades.activarUltimoCheck();

                cuello.SetActive(true);
                cambiarColor(manoCuello, true);
                manoCuello.SetActive(true);

                boca_Oido[0].SetActive(true);
                boca_Oido[1].SetActive(true);

                break;
            */
            case 0://Mover Mesa
                yield return new WaitForSecondsRealtime(6.00f);
                letreroMover.SetActive(true);

                break;
            case 1://Tocar Hombro
                checkListActividades.activarUltimoCheck();
                StartCoroutine(cerrarVista());
                yield return new WaitForSecondsRealtime(0.5f);
                cableElectrificado.SetActive(false);
                muerto.SetActive(false);
                camilla.SetActive(true);
                sillones.SetActive(true);
                personajeYMesa[1].SetActive(true);

                cambiarColor(manosHombros[0], true);
                cambiarColor(manosHombros[1], true);
                manosHombros[0].SetActive(true);
                manosHombros[1].SetActive(true);
                colliderHombros.SetActive(true);//se desactiva solo

                cubosPersonajes[0].transform.position += new Vector3(-1.9f, 0, 0);
                cubosPersonajes[1].transform.position += new Vector3(-1.9f, 0, 0);

                break;
            case 2://oir respiracion
                checkListActividades.activarUltimoCheck();
                anima.SetTrigger("sac");
                yield return new WaitForSecondsRealtime(2.0f);

                cuello.SetActive(true);
                cambiarColor(manoCuello, true);
                manoCuello.SetActive(true);

                boca_Oido[0].SetActive(true);
                boca_Oido[1].SetActive(true);

                break;
             case 3://LLamada de Emergencia
                checkListActividades.activarUltimoCheck();
                boca_Oido[0].SetActive(false);
                boca_Oido[1].SetActive(false);
                manoCuello.SetActive(false);
                funcionalidades.posibleLlamada = true;

                break;
            case 4://abrir boca
                checkListActividades.activarUltimoCheck();
                cambiarColor(manosParaAbrirBoca[0], true);
                cambiarColor(manosParaAbrirBoca[1], true);
                manosParaAbrirBoca[0].SetActive(true);
                manosParaAbrirBoca[1].SetActive(true);
                espacioParaAbrirBoca[0].SetActive(true);
                espacioParaAbrirBoca[1].SetActive(true);
                break;
            case 5://30 compresiones
                checkListActividades.activarUltimoCheck();
                StartCoroutine(aperturaDeBoca());
                manosParaAbrirBoca[0].SetActive(false);
                manosParaAbrirBoca[1].SetActive(false);

                espacioManosCompresiones[0].SetActive(true);
                espacioManosCompresiones[1].SetActive(true);

                break;
            case 6://Respiracion
                checkListActividades.activarUltimoCheck();
                
                boca_Oido[0].SetActive(true);
                boca_Oido[2].SetActive(true);
                boca_Oido[3].SetActive(true);

                contadorRepeticiones.text = "2";
                break;
            //===============================2=====================
            case 7://30 compresiones
                checkListActividades.activarUltimoCheck();
                checkListActividades2.gameObject.SetActive(true);
                panelRondas.SetActive(true);
                //
                boca_Oido[0].SetActive(false);
                boca_Oido[2].SetActive(false);

                funcionalidades.activarEspacioDerechaCompresion(true);
                funcionalidades.activarEspacioIzquierdaCompresion(true);

                funContar.pecho.contador = 0;
                funContar.pecho.contable = false;
                contadorCompresionesTEXT.text = "0";
                funContar.primeraVez = false;
                //
                yield return new WaitForSecondsRealtime(3.00f);
                checkListActividades.gameObject.SetActive(false);
                
                break;
            case 8://Respiracion
                checkListActividades2.activarUltimoCheck();

                boca_Oido[0].SetActive(true);
                boca_Oido[2].SetActive(true);
                funcionalidades.activarNariz(true);

                bocaCollider.imposibleDarAire = false;

                
                break;
            //==============================3======================
            case 9://30 compresiones
                checkListActividades2.activarUltimoCheck();
                boca_Oido[0].SetActive(false);
                boca_Oido[2].SetActive(false);

                //
                funcionalidades.activarEspacioDerechaCompresion(true);
                funcionalidades.activarEspacioIzquierdaCompresion(true);

                funContar.pecho.contador = 0;
                funContar.pecho.contable = false;
                contadorCompresionesTEXT.text = "0";
                funContar.primeraVez = false;
                //
                yield return new WaitForSecondsRealtime(3.00f);
                checkListActividades2.reiniciar();
                contadorRepeticiones.text = "3";
                break;
            case 10://Respiracion
                checkListActividades2.activarUltimoCheck();
                //

                boca_Oido[0].SetActive(true);
                boca_Oido[2].SetActive(true);
                funcionalidades.activarNariz(true);

                bocaCollider.imposibleDarAire = false;//

                break;
            //==============================4======================
            case 11://30 compresiones
                checkListActividades2.activarUltimoCheck();
                boca_Oido[0].SetActive(false);
                boca_Oido[2].SetActive(false);
                //

                funcionalidades.activarEspacioDerechaCompresion(true);
                funcionalidades.activarEspacioIzquierdaCompresion(true);

                funContar.pecho.contador = 0;
                funContar.pecho.contable = false;
                contadorCompresionesTEXT.text = "0";
                funContar.primeraVez = false;
              
                //
                yield return new WaitForSecondsRealtime(3.00f);
                checkListActividades2.reiniciar();
                contadorRepeticiones.text = "4";
                break;
            case 12://Respiracion
                checkListActividades2.activarUltimoCheck();
                //

                boca_Oido[0].SetActive(true);
                boca_Oido[2].SetActive(true);
                funcionalidades.activarNariz(true);

                bocaCollider.imposibleDarAire = false;//

                break;
            //==============================5======================
            case 13://30 compresiones
                checkListActividades2.activarUltimoCheck();
                boca_Oido[0].SetActive(false);
                boca_Oido[2].SetActive(false);
                //

                funcionalidades.activarEspacioDerechaCompresion(true);
                funcionalidades.activarEspacioIzquierdaCompresion(true);

                funContar.pecho.contador = 0;
                funContar.pecho.contable = false;
                contadorCompresionesTEXT.text = "0";
                funContar.primeraVez = false;

                //
                yield return new WaitForSecondsRealtime(1.5f);
                checkListActividades2.gameObject.SetActive(false);
                checkListActividades3.gameObject.SetActive(true);
                contadorRepeticiones.text = "5";
                break;
            case 14://Respiracion
                checkListActividades3.activarUltimoCheck();
                //

                boca_Oido[0].SetActive(true);
                boca_Oido[2].SetActive(true);
                funcionalidades.activarNariz(true);

                bocaCollider.imposibleDarAire = false;//

                break;
            case 15://Oir 
                checkListActividades3.activarUltimoCheck();

                cambiarColor(manoCuello, true);
                manoCuello.SetActive(true);
                //
                boca_Oido[0].SetActive(true);
                boca_Oido[1].SetActive(true);//odio
                //boca_Oido[2].SetActive(false);//boca
                funcionalidades.activarCuello(true);
                bocaCollider.imposibleOir = false;
                //
                break;
            case 16://
                checkListActividades3.activarUltimoCheck();
                checkListActividades.gameObject.SetActive(true);
                letreroFinal.SetActive(true);
                manoCuello.SetActive(false);
                //
                boca_Oido[0].SetActive(false);
                boca_Oido[1].SetActive(false);
                boca_Oido[2].SetActive(false);
                StartCoroutine(aperturaDeOjos());
                anima.SetTrigger("revivir");

                //
                break;
                /*
                case 0://MOVER MESA
                    yield return new WaitForSecondsRealtime(4.00f);
                    letreroMover.SetActive(true);

                    break;
                case 1://TOCAR HOMBRO
                    StartCoroutine(cerrarVista());
                    yield return new WaitForSeconds(0.5f);
                    cubosPersonajes[0].transform.position += new Vector3(-1.9f, 0, 0);
                    cubosPersonajes[1].transform.position += new Vector3(-1.9f, 0, 0);
                    checkListActividades.activarUltimoCheck();
                    muerto.SetActive(false);
                    personajeYMesa[0].SetActive(true);
                    personajeYMesa[1].SetActive(true);

                    cambiarColor(manosHombros[0], true);
                    cambiarColor(manosHombros[1], true);
                    manosHombros[0].SetActive(true);
                    manosHombros[1].SetActive(true);
                    colliderHombros.SetActive(true);//se desactiva solo
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    break;
                case 2://PEDIR AYUDA LETRERO
                    checkListActividades.activarUltimoCheck();
                    manosHombros[0].SetActive(false);
                    manosHombros[1].SetActive(false);
                    anima.SetTrigger("sac");
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    letreroAyuda.SetActive(true);//se desactiva Solo
                    break;
                case 3://ABRIR BOCA
                    checkListActividades.activarUltimoCheck();
                    cambiarColor(manosParaAbrirBoca[0], true);
                    cambiarColor(manosParaAbrirBoca[1], true);
                    manosParaAbrirBoca[0].SetActive(true);
                    manosParaAbrirBoca[1].SetActive(true);
                    espacioParaAbrirBoca[0].SetActive(true);
                    espacioParaAbrirBoca[1].SetActive(true);

                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    break;
                case 4://Escuchar respiracion
                    StartCoroutine(aperturaDeBoca());
                    checkListActividades.activarUltimoCheck();
                    manosParaAbrirBoca[0].SetActive(false);
                    manosParaAbrirBoca[1].SetActive(false);

                    boca_Oido[0].SetActive(true);
                    boca_Oido[1].SetActive(true);
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    break;
                case 5://LlamarEmergencia
                    checkListActividades.activarUltimoCheck();
                    boca_Oido[0].SetActive(false);
                    boca_Oido[1].SetActive(false);
                    funcionalidades.posibleLlamada = true;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    break;
                case 6://30 compresiones
                    checkListActividades.activarUltimoCheck();
                    espacioManosCompresiones[0].SetActive(true);
                    espacioManosCompresiones[1].SetActive(true);
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }

                    break;
                case 7://Respiracion
                    checkListActividades.activarUltimoCheck();
                    boca_Oido[0].SetActive(true);
                    boca_Oido[2].SetActive(true);
                    boca_Oido[3].SetActive(true);
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }

                    break;
                //==================================================1ra ronda=============================================
                case 8://30 compresiones
                    checkListActividades.activarUltimoCheck();
                    checkListActividades2.gameObject.SetActive(true);
                    panelRondas.SetActive(true);
                    boca_Oido[0].SetActive(false);//col boca
                    boca_Oido[2].SetActive(false);//boca

                    funcionalidades.activarEspacioDerechaCompresion(true);
                    funcionalidades.activarEspacioIzquierdaCompresion(true);

                    funContar.pecho.contador = 0;
                    funContar.pecho.contable = false;
                    contadorCompresionesTEXT.text = "0";
                    funContar.primeraVez = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    contadorRepeticiones.text = "1";
                    yield return new WaitForSecondsRealtime(3.00f);
                    checkListActividades.gameObject.SetActive(false);
                    break;
                case 9://2 Aire
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[0].SetActive(true);//col boca
                    boca_Oido[2].SetActive(true);//boca
                    funcionalidades.activarNariz(true);
                    bocaCollider.imposibleDarAire = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    break;
                case 10:// Oir Respiracion
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[2].SetActive(false);//boca
                    boca_Oido[1].SetActive(true);//odio
                    bocaCollider.imposibleOir = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }

                    break;
                //==================================================2da ronda=============================================
                case 11:// 30 compresiones
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[0].SetActive(false);//col boca
                    boca_Oido[1].SetActive(false);//odio
                    funcionalidades.activarEspacioDerechaCompresion(true);
                    funcionalidades.activarEspacioIzquierdaCompresion(true);

                    funContar.pecho.contador = 0;
                    funContar.pecho.contable = false;
                    contadorCompresionesTEXT.text = "0";
                    funContar.primeraVez = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    yield return new WaitForSecondsRealtime(3.00f);
                    checkListActividades2.reiniciar();
                    contadorRepeticiones.text = "2";
                    break;
                case 12://2 Aire
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[0].SetActive(true);//col boca
                    boca_Oido[2].SetActive(true);//boca
                    funcionalidades.activarNariz(true);
                    bocaCollider.imposibleDarAire = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    break;
                case 13:// Oir Respiracion
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[2].SetActive(false);//boca
                    boca_Oido[1].SetActive(true);//odio
                    bocaCollider.imposibleOir = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }

                    break;
                //==================================================3ra ronda=============================================
                case 14:// 30 compresiones
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[0].SetActive(false);//col boca
                    boca_Oido[1].SetActive(false);//oido
                    funcionalidades.activarEspacioDerechaCompresion(true);
                    funcionalidades.activarEspacioIzquierdaCompresion(true);

                    funContar.pecho.contador = 0;
                    funContar.pecho.contable = false;
                    contadorCompresionesTEXT.text = "0";
                    funContar.primeraVez = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    yield return new WaitForSecondsRealtime(3.00f);
                    checkListActividades2.reiniciar();
                    contadorRepeticiones.text = "3";
                    break;
                case 15://2 Aire
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[0].SetActive(true);//col boca
                    boca_Oido[2].SetActive(true);//boca
                    funcionalidades.activarNariz(true);
                    bocaCollider.imposibleDarAire = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    break;
                case 16:// Oir Respiracion
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[2].SetActive(false);//boca
                    boca_Oido[1].SetActive(true);//odio
                    bocaCollider.imposibleOir = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }

                    break;
                //==================================================4ra ronda=============================================
                case 17:// 30 compresiones
                    checkListActividades2.activarUltimoCheck();

                    boca_Oido[0].SetActive(false);//col boca
                    boca_Oido[1].SetActive(false);//oido
                    funcionalidades.activarEspacioDerechaCompresion(true);
                    funcionalidades.activarEspacioIzquierdaCompresion(true);

                    funContar.pecho.contador = 0;
                    funContar.pecho.contable = false;
                    contadorCompresionesTEXT.text = "0";
                    funContar.primeraVez = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    yield return new WaitForSecondsRealtime(3.00f);
                    checkListActividades2.reiniciar();
                    contadorRepeticiones.text = "4";
                    break;
                case 18://2 Aire
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[0].SetActive(true);//col boca
                    boca_Oido[2].SetActive(true);//boca
                    funcionalidades.activarNariz(true);
                    bocaCollider.imposibleDarAire = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    break;
                case 19:// Oir Respiracion
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[2].SetActive(false);//boca
                    boca_Oido[1].SetActive(true);//odio
                    bocaCollider.imposibleOir = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }

                    break;
                //==================================================5ta ronda=============================================
                case 20:// 30 compresiones
                    checkListActividades2.activarUltimoCheck();

                    boca_Oido[0].SetActive(false);//col boca
                    boca_Oido[1].SetActive(false);//oido
                    funcionalidades.activarEspacioDerechaCompresion(true);
                    funcionalidades.activarEspacioIzquierdaCompresion(true);

                    funContar.pecho.contador = 0;
                    funContar.pecho.contable = false;
                    contadorCompresionesTEXT.text = "0";
                    funContar.primeraVez = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    yield return new WaitForSecondsRealtime(3.00f);
                    checkListActividades2.reiniciar();
                    contadorRepeticiones.text = "5";
                    break;
                case 21://2 Aire
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[0].SetActive(true);//col boca
                    boca_Oido[2].SetActive(true);//boca
                    funcionalidades.activarNariz(true);
                    bocaCollider.imposibleDarAire = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    break;
                case 22:// Oir Respiracion
                    checkListActividades2.activarUltimoCheck();
                    boca_Oido[2].SetActive(false);//boca
                    boca_Oido[1].SetActive(true);//odio
                    bocaCollider.imposibleOir = false;
                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }

                    break;
                //==================================================FINAL=============================================
                case 23:// 30 compresiones
                    checkListActividades2.activarUltimoCheck();

                    boca_Oido[0].SetActive(false);//col boca
                    boca_Oido[1].SetActive(false);//oido

                    while (audioController.audioSource.isPlaying == true)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    yield return new WaitForSecondsRealtime(3.00f);
                    letreroFinal.SetActive(true);
                    break;*/

        }
    }

}
