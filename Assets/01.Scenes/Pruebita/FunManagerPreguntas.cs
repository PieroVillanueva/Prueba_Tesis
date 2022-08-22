using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunManagerPreguntas : MonoBehaviour
{
    public int contadorCorrectas;
    public Text textoPreguntaPanel;
    public Text textoOpcion1Panel;
    public Text textoOpcion2Panel;
    public Image colorOp1;
    public Image colorOp2;
    public Pregunta[] bancoPreguntas;
    public int posPregunta;
    public Color[] coloresNecesarios;
    public bool preguntaSeleccionada;

    private int aleatorio;
    private Pregunta auxiliar;

    public AudioSource reproductor;
    public AudioClip correcto;
    public AudioClip incorrecto;
    void Start()
    {
        mezclar();
        asignarPregunta();
    }
    public void asignarPregunta()
    {
        preguntaSeleccionada = false;
        textoPreguntaPanel.text = bancoPreguntas[posPregunta].textoPregunta;
        textoOpcion1Panel.text = bancoPreguntas[posPregunta].op1;
        textoOpcion2Panel.text = bancoPreguntas[posPregunta].op2;
        colorOp1.color = coloresNecesarios[2];
        colorOp2.color = coloresNecesarios[2];
    }

    public void contestarPregunta(int opcion)
    {
        if (!preguntaSeleccionada) {
            preguntaSeleccionada = true;
            if (opcion == 1)
            {
                if (bancoPreguntas[posPregunta].opCorrecta == 1)
                {
                    colorOp1.color = coloresNecesarios[0];
                    contadorCorrectas++;
                    reproductor.PlayOneShot(correcto);
                }
                else
                {
                    colorOp1.color = coloresNecesarios[1];
                    reproductor.PlayOneShot(incorrecto);
                }
            }
            else
            {
                if (bancoPreguntas[posPregunta].opCorrecta == 2)
                {
                    colorOp2.color = coloresNecesarios[0];
                    contadorCorrectas++;
                    reproductor.PlayOneShot(correcto);
                }
                else
                {
                    colorOp2.color = coloresNecesarios[1];
                    reproductor.PlayOneShot(incorrecto);
                }
            }
            StartCoroutine(siguientePregunta());
        }

    }
    IEnumerator siguientePregunta()
    {
        yield return new WaitForSecondsRealtime(2.00f);
        if (posPregunta < bancoPreguntas.Length-1)
        {
            posPregunta++;
            asignarPregunta();
        }
    }
    public void mezclar()
    {
        for (int i = 0; i < bancoPreguntas.Length; i++)
        {
            aleatorio=Random.Range(0, bancoPreguntas.Length-1);

            auxiliar = bancoPreguntas[aleatorio];
            bancoPreguntas[aleatorio] = bancoPreguntas[i];
            bancoPreguntas[i] = auxiliar;
        }
    }

}
[System.Serializable]
public class Pregunta { 
    public string textoPregunta; 
    public string op1; 
    public string op2;
    public int opCorrecta;
};

