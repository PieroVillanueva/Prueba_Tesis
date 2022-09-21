using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FunManagerEscenarioUsoExtintor : MonoBehaviour
{
    public Movement usuario;
    public int siguienteEscenario;
    public bool agarroExtintorUnaVez;
    [Header("Audios")]
    public AudioSource reproductorAudios;
    public AudioClip[] listaAudios;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(inicio());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator inicio()
    {
        yield return new WaitForSeconds(2.00f);
        reproducirAudio(0);
    }
    public void llamarFinal() => StartCoroutine(final());

    IEnumerator final()
    {
        yield return new WaitForSeconds(2.00f);
        reproducirAudio(3);
        Debug.Log("CambiarEscenario");

        yield return new WaitForSeconds(6.00f);
        usuario.llamarTransitionIn();
        yield return new WaitForSeconds(2.00f);
        if (siguienteEscenario != -1)
        {
            SceneManager.LoadScene(siguienteEscenario);
        }
        

        //CAMBIAR ESCENARIO
    }
    public void agarrarExtintor()
    {
        if (!agarroExtintorUnaVez)
        {
            agarroExtintorUnaVez = true;
            reproducirAudio(1);
        }
        
    }
    public void reproducirAudio(int pos)
    {
        reproductorAudios.clip = listaAudios[pos];
        reproductorAudios.Play();
    }
}
