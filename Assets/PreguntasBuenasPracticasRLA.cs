using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PreguntaPracticas
{
    public string textPregunta;
    public Sprite imagen;
    public Respuestas alternativa1;
    public Respuestas alternativa2;
    public bool rptaCorrecta;
}

[System.Serializable]
public class Respuestas
{
    public string textRespuesta;
    public string indice;
    public bool correcta;
}

public class PreguntasBuenasPracticasRLA : MonoBehaviour
{
    public PreguntaPracticas[] preguntas;
    public Image imagenPregunta;
    public Text textoP;
    public Text botonA;
    public Text botonB;
    public AudioSource audioSource;
    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    public BoxCollider boton1;
    public BoxCollider boton2;
    public RLA_Manager manager;
    void Start()
    {
        textoP.text = preguntas[manager.indice].textPregunta;
        botonA.text = preguntas[manager.indice].alternativa1.textRespuesta;
        botonB.text = preguntas[manager.indice].alternativa2.textRespuesta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void textoOpcionA()
    {
        if (manager.indice < preguntas.Length)
        {
            boton1.enabled = false;
            boton2.enabled = false;
            if (preguntas[manager.indice].alternativa1.correcta)
            {
                audioSource.PlayOneShot(audio3);
                preguntas[manager.indice].rptaCorrecta = true;
                botonA.color = Color.green;
                pasarTareas();
            }
            else
            {
                botonA.color = Color.red;
                StartCoroutine(RepetirPregunta(botonA));
            }
            //PasarPregunta();
        }
    }

    public void textoOpcionB()
    {
        if (manager.indice < preguntas.Length)
        {
            boton1.enabled = false;
            boton2.enabled = false;
            if (preguntas[manager.indice].alternativa2.correcta)
            {
                audioSource.PlayOneShot(audio3);
                preguntas[manager.indice].rptaCorrecta = true;
                botonB.color = Color.green;
                pasarTareas();
            }
            else
            {
                botonB.color = Color.red;
                StartCoroutine(RepetirPregunta(botonB));
            }
            //PasarPregunta();
        }
    }

    public void pasarTareas()
    {
        switch (manager.indice)
        {
            case 0: manager.CumplirTarea(37);
                break;
            case 1: manager.CumplirTarea(39);
                break;
            case 2: manager.CumplirTarea(41);
                break;
            case 3: manager.CumplirTarea(43);
                break;

        }
    }

    public void PasarPregunta(int indice)
    {
        StartCoroutine(PasarNuevaPregunta(indice));
    }

    IEnumerator RepetirPregunta(Text boton)
    {
        audioSource.PlayOneShot(audio2);
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(audio1);
        while (audioSource.isPlaying == true)
        {
            //Debug.Log("Se esta reproduciendo audio");
            yield return new WaitForFixedUpdate();
        }
        boton.color = Color.white;
        boton1.enabled = true;
        boton2.enabled = true;
    }

    IEnumerator PasarNuevaPregunta(int indice1)
    {
        yield return new WaitForSeconds(1f);
        if (indice1 < preguntas.Length)
        {
            botonA.color = Color.white;
            botonB.color = Color.white;
            textoP.text = preguntas[indice1].textPregunta;
            botonA.text = preguntas[indice1].alternativa1.textRespuesta;
            botonB.text = preguntas[indice1].alternativa2.textRespuesta;
            if (preguntas[indice1].imagen != null)
            {
                imagenPregunta.gameObject.SetActive(true);
                imagenPregunta.sprite = preguntas[indice1].imagen;
            }
        }
    }
}
