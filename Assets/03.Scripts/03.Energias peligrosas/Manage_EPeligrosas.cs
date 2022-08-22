using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage_EPeligrosas : MonoBehaviour
{
    public AudioSource m_audioSource;
    public AudioClip[] m_locuciones;
        
    public int tareaActual = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        StartCoroutine(IniciarEjercicio(3.0f));
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AsignarTarea();
        }
    }
    //
    public int NumeroTarea()
    {
        return tareaActual;
    }
    public void AsignarTarea()
    {
        if (tareaActual == 0)
        {
            StartCoroutine(ReproducirAudio(tareaActual));
            Debug.Log("1° Tarea");
            return;
        }
        if (tareaActual < m_locuciones.Length)
        {            
            StartCoroutine(ReproducirAudio(tareaActual));
            Debug.Log($"{tareaActual + 1}° Tarea");
            return;
        }
        Debug.Log("No hay mas tareas");
    }

    IEnumerator ReproducirAudio(int tarea)
    {
        Debug.Log("Se asigna audio");
        m_audioSource.clip = m_locuciones[tarea];
        yield return new WaitForSeconds(1f);
        m_audioSource.Play();
        Debug.Log("Reproducion audio");
        //Siguiente tarea lista para reproducir
        tareaActual++;
    }

    /// <summary>
    /// Corrrutina que se ejecuta al iniciar la escena.
    /// </summary>
    /// <param name="tiempo">El primer tiempo para el llamado de las locuciones.</param>
    /// <returns></returns>
    IEnumerator IniciarEjercicio(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        AsignarTarea();
    }
}
