using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunMoverLetrero : MonoBehaviour
{
    public EPP_Manager em;
    public GameObject letrero;
    public GameObject nuevaPos;
    public Text texto;
    public FunPuertaLevadiza puerta;
    public bool moverManiqui;
    public GameObject maniqui;
    public GameObject manos;
    public GameObject posManiqui;
    public GameObject[] ocultables;
    public bool moverFinalizado;
    public GameObject letreroFinalizado;
    public GameObject nuevaPosFinalizado;
    public int numeroDeTarea;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mono")) // Cuando el cuerpo toque el box collider
        {
            em.CumplirTarea(numeroDeTarea);//audio
            letrero.transform.position = nuevaPos.transform.position;//se mueve el letrero con la descripción de los epp colocados
            texto.text = "";// Se resetea el texto del letrero de epp
            gameObject.SetActive(false);// Se desactiva el objeto
            puerta.LlamarBajada(); // Se cierra la puerta
            if (moverManiqui) { // En caso se necesite mover el maniqui
                manos.SetActive(true); // Se activan las manos del maniqui
                maniqui.transform.position = posManiqui.transform.position; // Se mueve el maniqui a la siguiente habitación
                for (int i = 0; i < ocultables.Length; i++)
                {
                    ocultables[i].SetActive(false); // Se ocultan los objetos de la lista en caso sea necesario
                }
            }
            if (moverFinalizado) // En caso se necesite mover el letrero de la finalización de 
            {
                letreroFinalizado.SetActive(false); // Se desactiva el letrero de finalización 
                letreroFinalizado.transform.position = nuevaPosFinalizado.transform.position; // Se mueve el letrero hacia la siguiente habitación
            }
        }
    }
}
