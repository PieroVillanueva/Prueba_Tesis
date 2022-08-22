using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager_RiesgosElectricosSupervisor : Lvl_Manager
{
    public Movement movimientoPersonaje;
    public FunImagenParpadeante imagenParpadeante;
    public Funcio2RiesgoElectrico funcio2;
    public GameObject video;
    public GameObject[] espacioEppPrimero;
    public GameObject[] eppPrimero;
    public GameObject[] aroPanelesMotor;
    public BoxCollider[] colidersSwitchesPanelesMotor;


    public GameObject[] espacioEppSegundo;
    public GameObject[] eppSegundo;

    public GameObject panelPrincipal;
    public BoxCollider coliderSwitchPrincipal;

    public GameObject[] espacioBloqueoPrincipal;

    public GameObject botonVerificarTierra;

    public GameObject[] polosMedibles;
    public GameObject espacioGancho;

    public GameObject llave;
    public GameObject espacioCandadoCajaMultibloqueo;
    public GameObject candadoParaCajaMultibloqueo;

    public GameObject[] colidersElectricidadPanelesMotor;
    public GameObject coliderElectricidadPrincipal;

    public GameObject personaje;
    public Vector3 nuevaPosPersonaje;

    public GameObject parteGiraSwitch;
    [Header ("Partes Iluminables")]
    public GameObject switchPanel;

    public GameObject secuenciaColocarCandados;


    [Header("Imagenes 6 pasos")]
    public GameObject[] imagenespasos;

    public override void Start()
    {
        base.Start();
        StartCoroutine(Tareas(actualTarea));
      
    }

    public override void CumplirTarea(int indexTarea)
    {
        base.CumplirTarea(indexTarea);
        StartCoroutine(Tareas(actualTarea));
    }
    

    /// <summary>
    /// Corrutina que activa los elemento a utilizar durante la tarea a realizar.
    /// </summary>
    /// <param name="tarea">Index de la tarea a realizar</param>
    /// <returns></returns>
    IEnumerator Tareas(int tarea)
    {
        switch (tarea)
        {
            case 0://Seleccion rol
                yield return new WaitForSeconds(13);//COMENTAR CUANDO PARA INICIAR
                /* //DESCOMENTAR CUANDO PARA INICIAR
                yield return new WaitForSeconds(3);
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }*/
                video.SetActive(true);

                break;
            case 1:// Colocar EPP
                //panelSeleccionRol.SetActive(false);
                movimientoPersonaje.Velocidad(1.5f);
                yield return new WaitForSeconds(1);
                espacioEppPrimero[0].SetActive(true);
                espacioEppPrimero[1].SetActive(true);
                espacioEppPrimero[2].SetActive(true);
                // espacioEppPrimero[3].SetActive(true); //SON GUANTES

                eppPrimero[0].SetActive(true);
                eppPrimero[1].SetActive(true);
                eppPrimero[2].SetActive(true);
                eppPrimero[3].SetActive(true);

                break;

            case 2://Tocar aros

                yield return new WaitForSeconds(1);
                colidersElectricidadPanelesMotor[0].SetActive(false);
                colidersElectricidadPanelesMotor[1].SetActive(false);
                colidersElectricidadPanelesMotor[2].SetActive(false);

                espacioEppPrimero[0].SetActive(false);
                espacioEppPrimero[1].SetActive(false);
                espacioEppPrimero[2].SetActive(false);
                espacioEppPrimero[3].SetActive(false); //SON GUANTES
                /*
                eppPrimero[0].SetActive(false);
                eppPrimero[1].SetActive(false);
                eppPrimero[2].SetActive(false);
                eppPrimero[3].SetActive(false);*/

                aroPanelesMotor[0].SetActive(true);
                aroPanelesMotor[1].SetActive(true);
                aroPanelesMotor[2].SetActive(true);

                break;
            case 3://Apagar paneles motor 
                colidersSwitchesPanelesMotor[0].enabled = true;
                colidersSwitchesPanelesMotor[1].enabled = true;
                colidersSwitchesPanelesMotor[2].enabled = true;
                break;
            case 4://Colocar EPP Segundo
               
                movimientoPersonaje.llamarTransitionIn();
                yield return new WaitForSeconds(0.5f);
                funcio2.quitarMaterialGuantesManos();
                espacioEppSegundo[0].SetActive(true);
                espacioEppSegundo[1].SetActive(true);
                movimientoPersonaje.llamarTransitionOut();
                //espacioEppSegundo[2].SetActive(true); //SON GUANTES

                eppSegundo[0].SetActive(true);
                eppSegundo[1].SetActive(true);
                eppSegundo[2].SetActive(true);

                break;

            case 5://Identificar panel Principal
                imagenParpadeante.gameObject.SetActive(true);
                imagenParpadeante.llamarSgteImagen(0);
                yield return new WaitForSeconds(1);
                coliderElectricidadPrincipal.SetActive(false);
                espacioEppSegundo[0].SetActive(false);
                espacioEppSegundo[1].SetActive(false);
                espacioEppSegundo[2].SetActive(false); //SON GUANTES

                imagenespasos[0].SetActive(true);
                /*
               eppSegundo[0].SetActive(false);
               eppSegundo[1].SetActive(false);
               eppSegundo[2].SetActive(false);*/

                panelPrincipal.SetActive(true);
                
                break;
            case 6://Apagar principal EXTERNO
                imagenParpadeante.llamarSgteImagen(1);
                coliderSwitchPrincipal.enabled = true;
                yield return new WaitForSeconds(1);
                imagenespasos[0].SetActive(false);
                imagenespasos[1].SetActive(true);
                break;
            case 7://Abrir panel y switch 
                imagenParpadeante.llamarSgteImagen(2);
                funcio2.posibleAbrirPrincipal = true;
                funcio2.resaltarObjeto(switchPanel);
                yield return new WaitForSeconds(1);
                imagenespasos[1].SetActive(false);
                imagenespasos[2].SetActive(true);
                break;
            case 8://Colocar bloqueo, pinza, candado etiquetado
                imagenParpadeante.llamarSgteImagen(3);
                parteGiraSwitch.transform.Rotate(90, 0, 0);
                funcio2.quitarResaltarObjeto(switchPanel);
                yield return new WaitForSeconds(1);
                espacioBloqueoPrincipal[0].SetActive(true);

                imagenespasos[2].SetActive(false);
                imagenespasos[3].SetActive(true);
                break;
            case 9://Verificar puesta tierra ( PRESIONAR BOTON)
                imagenParpadeante.llamarSgteImagen(4);
                yield return new WaitForSeconds(1);
                botonVerificarTierra.SetActive(true);

                yield return new WaitForSeconds(1);
                imagenespasos[3].SetActive(false);
                imagenespasos[4].SetActive(true);
                break;
            case 10://Medir tension con medidor
                imagenParpadeante.llamarSgteImagen(5);
                yield return new WaitForSeconds(1);
                polosMedibles[0].SetActive(true);
                polosMedibles[1].SetActive(true);
                polosMedibles[2].SetActive(true);
                polosMedibles[3].SetActive(true);


                yield return new WaitForSeconds(1);
                imagenespasos[4].SetActive(false);
                imagenespasos[5].SetActive(true);
                break;
            case 11://Colocar gancho corto
                imagenParpadeante.terminarBucle();
                yield return new WaitForSeconds(1);
                polosMedibles[0].SetActive(false);
                polosMedibles[1].SetActive(false);
                polosMedibles[2].SetActive(false);
                polosMedibles[3].SetActive(false);
                espacioGancho.SetActive(true);
                break;
            case 12://Colocar Llave en caja multibloqueo
                yield return new WaitForSeconds(1);
                llave.SetActive(true);

                break;
            case 13://Colocar candado en caja multibloqueo
                yield return new WaitForSeconds(1);
                candadoParaCajaMultibloqueo.SetActive(true);
                espacioCandadoCajaMultibloqueo.SetActive(true);
                break;
            case 14://Gente Colocando candados
               
                movimientoPersonaje.llamarTransitionIn();
                yield return new WaitForSeconds(1);
                movimientoPersonaje.Velocidad(0);
                movimientoPersonaje.transform.position = nuevaPosPersonaje;
                movimientoPersonaje.transform.Rotate(new Vector3(0, -90, 0));
                movimientoPersonaje.llamarTransitionOut();
                //Animaciones
                secuenciaColocarCandados.SetActive(true);

                yield return new WaitForSeconds(23);
                movimientoPersonaje.Velocidad(1.5f);
                SceneManager.LoadScene(1);

                break;
        }
    }

}
