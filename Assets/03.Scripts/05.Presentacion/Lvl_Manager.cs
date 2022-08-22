using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl_Manager : MonoBehaviour
{
    public SoundController audioController;
    public int actualTarea;
    public int totalTareas;
    public bool guiado = true;
    

    // Ejemplo metodo para hacer herencia
    public virtual void Start()
    {
        Debug.Log("Inicia herencia del Start");
        totalTareas = audioController.locuciones.Length;
        StartCoroutine(IniciarNivel());
    }
    
    public virtual void CumplirTarea(int indexTarea)
    {        
        if (indexTarea == actualTarea)
        { 
            CargarNuevaTarea();                       
            return;
        }
        Debug.Log($"La tarea n{indexTarea} no es n{actualTarea}");
    }
    public void CargarNuevaTarea()
    {
        //cambiamos a la siguiente tarea.
        actualTarea++;
        //cargamos nuevo clip de audio.
        if (actualTarea < totalTareas)
        {
            StartCoroutine(CargarReproducir_Clip());
            Debug.Log($"se cargo tarea n{actualTarea}");
            return;
        }
        Debug.Log("se acabaron la tareas");
    }

    IEnumerator CargarReproducir_Clip()
    {
        yield return new WaitForSeconds(0.5f);

        audioController.CargarClip(actualTarea);
        Debug.Log($"se cargo audio clip de tarea n{actualTarea}");

        yield return new WaitForSeconds(0.5f);

        audioController.ReproducirAudio();
        Debug.Log("Reproducion audio");
    }
    public virtual void iniciarNivelDelay()
    {
        StartCoroutine(IniciarNivel());
    }
    IEnumerator IniciarNivel()
    {
        yield return new WaitForSeconds(0.5f);
        //esperamos un tiempo para reproducir el audio inicial(index = 0)
        StartCoroutine(CargarReproducir_Clip()); 
    }
}
