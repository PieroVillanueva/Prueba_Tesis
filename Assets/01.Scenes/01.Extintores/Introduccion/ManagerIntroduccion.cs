using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerIntroduccion : MonoBehaviour
{
    public int siguienteEscena;
    public bool primerAgarre;
    public bool sePuedeSoltar;
    public bool primeraSoltada;
    public bool seColocoObjetoEnSuLugar;
    public bool sePuedeSegundoAgarre;
    public bool segundoAgarre;
    public GameObject casco; 

    [Header("Personaje")]
    public Movement personaje;
    public GameObject nuevaPosPersonaje;

    [Header("Aros")]
    public GameObject[] arosPersonaje;
    public GameObject aroMesa;

    [Header("UI")]
    public GameObject control2;
    public GameObject indicadorIzquierda;
    public GameObject boton;

    [Header("Audios")]
    public AudioSource reproductor;
    public AudioClip[] audiosSecuencia;

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
    public void colocarObjetoEnSuLugar()
    {
        if (!seColocoObjetoEnSuLugar)
        {
            seColocoObjetoEnSuLugar = true;
            llamarEmpezarTarea(8);          //FALTA
        }
    }
    public void llamarPrimerAgarre()
    {
        if (!primerAgarre)
        {
            primerAgarre = true;
            llamarEmpezarTarea(4);          //FALTA
        }
        if (sePuedeSegundoAgarre&&!segundoAgarre)
        {
            sePuedeSegundoAgarre = false;
            segundoAgarre = true;
            llamarEmpezarTarea(7);          //FALTA
        }
    }
    public void llamarPrimerSoltada()
    {
        if (sePuedeSoltar&&!primeraSoltada)
        {
            sePuedeSoltar = false;
            primeraSoltada = true;
            llamarEmpezarTarea(5);          //FALTA
        }
    }


    public void llamarEmpezarTarea(int numero) => StartCoroutine(empezarTarea(numero));
    IEnumerator empezarTarea(int numero)
    {
        switch (numero)
        {
            case 0://Iniciamos Aqui
                yield return new WaitForSeconds(3f);
                reproducirAudio(0);
                yield return new WaitForSeconds(audiosSecuencia[0].length+0.3f);
                // Mueve la cabeza
                reproducirAudio(1);
                yield return new WaitForSeconds(audiosSecuencia[1].length + 0.3f);

                yield return new WaitForSeconds(5.0f);
                //Habilita tocar aro               
                reproducirAudio(2);
                indicadorIzquierda.SetActive(true);
                yield return new WaitForSeconds(audiosSecuencia[2].length);
                arosPersonaje[0].SetActive(true);

                break;
            case 1: //Tocar aro      
                reproducirAudio(3);
                yield return new WaitForSeconds(audiosSecuencia[3].length);
                //Habilita boton
                boton.SetActive(true);

                break;
            case 2: //Tocar cartel
                    //FALTA TP Y PARPADEADA
                yield return new WaitForSeconds(0.5f);
                personaje.llamarTransitionIn();
                yield return new WaitForSeconds(1.0f);
                personaje.transform.position = nuevaPosPersonaje.transform.position;
                yield return new WaitForSeconds(1.0f);
                personaje.llamarTransitionOut();

                reproducirAudio(4);
                yield return new WaitForSeconds(audiosSecuencia[4].length);
                //Habilitar circulo azul
                arosPersonaje[1].SetActive(true);

                break;
            case 3: //Ingresa al circulo azul
                reproducirAudio(5);
                //Habilitar agarre 
                control2.SetActive(true);             
                casco.SetActive(true);
                yield return new WaitForSeconds(audiosSecuencia[5].length);
                break;
            case 4: //Agarras Objeto
                reproducirAudio(6);
                yield return new WaitForSeconds(audiosSecuencia[6].length);
                //Habilitar soltar
                sePuedeSoltar = true;
                break;
            case 5: //Sueltas Objeto
                //                                                               FALTA TP Y PARPADEADA
                yield return new WaitForSeconds(0.5f);
                personaje.llamarTransitionIn();
                yield return new WaitForSeconds(1.0f);
                personaje.transform.position = nuevaPosPersonaje.transform.position;
                yield return new WaitForSeconds(1.0f);
                personaje.llamarTransitionOut();


                reproducirAudio(7);
                yield return new WaitForSeconds(audiosSecuencia[7].length);
                //habilita aro azul
                arosPersonaje[2].SetActive(true);
                break;
            case 6: //Toca aro azul
                reproducirAudio(8);
                yield return new WaitForSeconds(audiosSecuencia[8].length);
                //habilita segundo agarre
                sePuedeSegundoAgarre = true;
                break;
            case 7: // Segundo Agarre
                reproducirAudio(9);
                yield return new WaitForSeconds(audiosSecuencia[9].length);
                //habilita espacio casco
                aroMesa.SetActive(true);

                break;
            case 8: //Coloca espacio Casco
                reproducirAudio(11);
                yield return new WaitForSeconds(audiosSecuencia[11].length);

                //MANDAMOS SIGUIENTE ESCENA
                yield return new WaitForSeconds(3.00f);
                Debug.Log("SE ACABO");
                //                                                               PARPADEADA
                personaje.llamarTransitionIn();
                yield return new WaitForSeconds(1.0f);
                SceneManager.LoadScene(siguienteEscena);

                break;


        }
    }
}
