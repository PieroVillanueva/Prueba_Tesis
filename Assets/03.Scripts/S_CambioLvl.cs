using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_CambioLvl : MonoBehaviour
{
    [Header("Seguridad en Oficina")]
    public Text textoAscensor;
    public GameObject panel;
    public ElevadorSO ascensor;
    private int indiceEscena = 0;
    private Singleton_SO singleton;
    public Transform posicion;
    public bool seguridadO;
    // Start is called before the first frame update
    void Start()
    {
        if (seguridadO)
        {
            singleton = GameObject.Find("Singleton").GetComponent<Singleton_SO>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            CambioDeEscena("03_EC_Preparacion");
        }*/
    }

    public void CambioDeEscena(string name) 
    {        
        StartCoroutine(CambioCorrutina(name));
        //SceneManager.LoadScene(name);
    }

    IEnumerator CambioCorrutina(string name)
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
    }

    //Seguridad en Oficina

    public void CambiarEscenaConPosicion(string name)
    {
        StartCoroutine(CambioCorrutina(name));
        
        singleton.AsignarPosicionPlayer(posicion);
        singleton.otroEjercicio = true;
    }

    public void MostrarDescripcion(int indice)
    {
        panel.SetActive(true);
        switch (indice)
        {
            case 0:
                textoAscensor.text = "Lobby";
                indiceEscena = 0;
                break;
            case 1:
                textoAscensor.text = "Ejercicios de Seguridad en Oficina";
                indiceEscena = 1;
                break;

        }
    }

    public void CambiarEscena()
    {
        //SceneManager.GetActiveScene().name == "Lobby_SO"
        if (indiceEscena == 0)
        {
            ascensor.StartCoroutine("AbrirElevador");
            ascensor.CambiarEstadoAscensor(true);
        }
        else
        {
            ascensor.StartCoroutine("CerrarElevador");
            ascensor.CambiarEstadoAscensor(false);
            CambioDeEscena("Lobby_SO");
        }
    }

    public void CambiarEscenaLobby()
    {
        if (indiceEscena == 0)
        {
            ascensor.StartCoroutine("CerrarElevador");
            ascensor.CambiarEstadoAscensor(false);
            CambioDeEscena("SC_Lobby 1");
        }
        else
        {
            ascensor.StartCoroutine("AbrirElevador");
            ascensor.CambiarEstadoAscensor(true);
        }
    }
}
