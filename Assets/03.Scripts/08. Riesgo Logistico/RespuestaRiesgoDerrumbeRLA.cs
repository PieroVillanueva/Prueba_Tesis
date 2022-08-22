using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class PreguntaDerrumbe
{
    public string textPregunta;
    public bool rptaCorrecta;
    public string respuesta;
}

public class RespuestaRiesgoDerrumbeRLA : MonoBehaviour
{
    // Start is called before the first frame update
    public PreguntaDerrumbe[] preguntas;
    public int indice;
    public Text textoP;
    public BoxCollider[] botones;
    public bool enEspera;
    public RLA_Manager manager;
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clip2;
    public AudioClip clip3;
    public Text[] textos;
    void Start()
    {
        textoP.text = preguntas[indice].textPregunta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AsignarRespuestaEmpleador()
    {
        string cadena = "EMPLEADOR";
        if (indice < preguntas.Length)
        {
            botones[0].enabled = false;
            botones[1].enabled = false;
            if (preguntas[indice].respuesta.Equals(cadena))
            {
                audioSource.PlayOneShot(clip3);
                preguntas[indice].rptaCorrecta = true;
                textos[0].color = Color.green;
                indice++;
                StartCoroutine(PasarPregunta());
            }
            else
            {
                textos[0].color = Color.red;
                StartCoroutine(RepetirPregunta(textos[0]));
            }
            if (indice >= preguntas.Length)
            {
                manager.CumplirTarea(26);
            }
        }
        
    }

    public void AsignarRespuestaColaborador()
    {
        string cadena = "COLABORADOR";
        if (indice < preguntas.Length)
        {
            botones[0].enabled = false;
            botones[1].enabled = false;
            if (preguntas[indice].respuesta.Equals(cadena))
            {
                audioSource.PlayOneShot(clip3);
                preguntas[indice].rptaCorrecta = true;
                textos[1].color = Color.green;
                indice++;
                StartCoroutine(PasarPregunta());
            }
            else
            {
                textos[1].color = Color.red;
                StartCoroutine(RepetirPregunta(textos[1]));
            }          
            if (indice >= preguntas.Length)
            {
                manager.CumplirTarea(26);
            }
        }
    }

    IEnumerator RepetirPregunta(Text boton)
    {
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(clip2);
        while (audioSource.isPlaying == true)
        {
            //Debug.Log("Se esta reproduciendo audio");
            yield return new WaitForFixedUpdate();
        }
        boton.color = Color.white;
        botones[0].enabled = true;
        botones[1].enabled = true;
    }

    IEnumerator PasarPregunta()
    {
        yield return new WaitForSeconds(1f);
        if (indice < preguntas.Length)
        {
            gameObject.GetComponent<Canvas>().enabled = false;
            textoP.text = preguntas[indice].textPregunta;
            textos[0].color = Color.white;
            textos[1].color = Color.white;
            yield return new WaitForSeconds(1.5f);
            gameObject.GetComponent<Canvas>().enabled = true;
            botones[0].enabled = true;
            botones[1].enabled = true;
        }
    }
}
