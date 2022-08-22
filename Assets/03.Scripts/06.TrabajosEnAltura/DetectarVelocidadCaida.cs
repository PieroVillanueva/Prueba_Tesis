using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarVelocidadCaida : MonoBehaviour
{
    // Start is called before the first frame update
    public Movement movement;
    public float velocidadCaida;
    public Transform posicionAmbulancia;
    public GameObject usuario;
    public bool coroutineEj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            velocidadCaida = movement.VelocidadCaida(); //Se obtiene la velocidad con la que cae el usuario a través de su scrip movement
            if (velocidadCaida <= -7.5f && !coroutineEj)
            {
                coroutineEj = true;
                StartCoroutine(Resetear()); //Llamado a la coroutine para el accidente
            }
            
        } 
    }
    
    IEnumerator Resetear()
    {
        if (coroutineEj)
        {
            Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
            yield return new WaitForSecondsRealtime(1.1f);
            player.StartCoroutine("TransitionLvlIn");
            yield return new WaitForSeconds(1.1f);
            //Se le da posición y rotación al usuario
            usuario.transform.position = posicionAmbulancia.position;
            usuario.transform.eulerAngles = posicionAmbulancia.eulerAngles;
            player.StartCoroutine("TransitionLvlOut");
            yield return new WaitForSeconds(1f);
            yield return new WaitForSeconds(0f);
            coroutineEj = false;
        }
        
    }

    


}
