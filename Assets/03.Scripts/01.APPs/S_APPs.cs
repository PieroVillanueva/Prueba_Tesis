using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_APPs : MonoBehaviour
{   
    // Script general para los APPs que se van a colocar al jugador    
    /// <summary>
    /// Tipo de APP para ser colocado en cada parte del cuerpo
    /// </summary>
    public enum TipoAPP
    {
        cabeza,
        manos,
        cuerpo,
        piernas,
    };

    /// <summary>
    /// Muestra de los Tipo de APP en el codigo, se debe seleccionar el que se trabajara (Con material:  manos, cuerpo, piernas)
    /// </summary>
    public TipoAPP APP;

    /// <summary>
    /// Booleano que se debera de activar soltemos el app, retornado true.
    /// </summary>
    public bool enMano;
    public bool forPlayer;
    public AudioClip appSound;


    public Material changeToAPP;
    /// <summary>
    /// Evento que debe ser colocado en XR grab interactor o One hand interactable
    /// </summary>
    /// <param name="value">valor true o false</param>
    public void Evento_enMano(bool value)
    {
        enMano = value;
        if(gameObject.activeInHierarchy) StartCoroutine(ResetEnMano());
    }

    IEnumerator ResetEnMano()
    {
        yield return new WaitForSeconds(1);
        enMano = false;
    }

}

