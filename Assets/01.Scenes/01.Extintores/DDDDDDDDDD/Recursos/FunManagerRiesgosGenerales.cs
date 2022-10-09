using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FunManagerRiesgosGenerales : MonoBehaviour
{
    public int siguienteEscena;
    public Movement personaje;
    public GameObject nuevaPos;

    [Header("Gifs")]
    public GameObject gif;

    [Header("Videos")]
    public GameObject video;

    [Header("Audios")]
    public AudioSource reproductor;
    public AudioClip[] audiosSecuencia;
    //public AudioClip audioGrito;
    [Header("Letreros")]
    public GameObject[] letreros;


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
    public void llamarEmpezarTarea(int numero) => StartCoroutine(empezarTarea(numero));
    IEnumerator empezarTarea(int numero)
    {
        switch (numero)
        {
            case 0://Inicial
                yield return new WaitForSeconds(3f);
                gif.SetActive(true);
                reproducirAudio(0);
                yield return new WaitForSeconds(audiosSecuencia[0].length+0.4f);
                gif.SetActive(false);

                reproducirAudio(1);
                yield return new WaitForSeconds(audiosSecuencia[1].length + 0.4f);
                
                video.SetActive(true);
                yield return new WaitForSeconds(143 + 0.3f);
                video.SetActive(false);

                reproducirAudio(2);
                yield return new WaitForSeconds(audiosSecuencia[2].length + 0.4f);
                //Activar letrero Ruido

                reproducirAudio(3);
                yield return new WaitForSeconds(audiosSecuencia[3].length + 0.4f);
                letreros[0].SetActive(true);
                //                                                                     FALTA ACTIVAR COLLIDER DE OBJETO

                break;
            case 1:  //Al tocar Ruido
                yield return new WaitForSeconds(0.3f);
                reproducirAudio(4);
                yield return new WaitForSeconds(audiosSecuencia[4].length + 0.4f);

                //Activar letrero Temperaturas
                letreros[1].SetActive(true);
                break;
            case 2:  //Al tocar Temperaturas
                yield return new WaitForSeconds(0.3f);
                reproducirAudio(5);
                yield return new WaitForSeconds(audiosSecuencia[5].length + 0.4f);

                //Activar letrero Atrapado
                letreros[2].SetActive(true);
                break;
            case 3:  //Al tocar Atrapado
                yield return new WaitForSeconds(0.3f);
                reproducirAudio(6);
                yield return new WaitForSeconds(audiosSecuencia[6].length + 0.4f);


                //                                                                       FALTA TEPEADA
                personaje.llamarTransitionIn();
                yield return new WaitForSeconds(1.0f);
                personaje.transform.position = nuevaPos.transform.position;
                personaje.transform.Rotate(new Vector3(0, 90, 0));
                personaje.llamarTransitionOut();


                //Activar letrero altura
                reproducirAudio(7);
                yield return new WaitForSeconds(audiosSecuencia[7].length + 0.4f);
                letreros[3].SetActive(true);
                break;
            case 4:  //Al tocar altura
                yield return new WaitForSeconds(0.3f);
                reproducirAudio(8);
                yield return new WaitForSeconds(audiosSecuencia[8].length + 0.4f);

                //Activar letrero quimicos
                letreros[4].SetActive(true);
                break;
            case 5:  //Al tocar quimicos
                yield return new WaitForSeconds(0.3f);
                reproducirAudio(9);
                yield return new WaitForSeconds(audiosSecuencia[9].length + 0.4f);

                //Activar letrero Ruido
                letreros[5].SetActive(true);
                break;
            case 6:  //Al tocar Ruido
                yield return new WaitForSeconds(0.3f);
                reproducirAudio(10);
                yield return new WaitForSeconds(audiosSecuencia[10].length + 0.4f);

                //Activar letrero Resbadizo
                letreros[6].SetActive(true);
                break;
            case 7:  //Al tocar Resbadizo
                yield return new WaitForSeconds(0.3f);
                reproducirAudio(11);
                yield return new WaitForSeconds(audiosSecuencia[11].length + 0.4f);

                yield return new WaitForSeconds(2f);
                reproducirAudio(12);
                yield return new WaitForSeconds(audiosSecuencia[12].length + 0.4f);
                //                                                                       FALTA SACAR ESCENARIO
                personaje.llamarTransitionIn();
                yield return new WaitForSeconds(1f);
                Debug.Log("TERMINADO");
                SceneManager.LoadScene(siguienteEscena);
                break;

        }
    }
}
