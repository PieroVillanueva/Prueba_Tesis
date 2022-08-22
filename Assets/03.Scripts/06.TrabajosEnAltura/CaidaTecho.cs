using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaTecho : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jugador;
    public Vector3 posicionCheckPoint;
    public bool enganchado, enganchado2;
    public EngancheArnes enganche1;
    public EngancheArnes enganche2;
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
            enganchado = enganche1.enganchado;
            enganchado2 = enganche2.enganchado;
            if ((enganche1.enganchado || enganche2.enganchado))
            {
                StartCoroutine(PosicionJugador());
            }
            
            
        }
    }

    IEnumerator PosicionJugador()
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        yield return new WaitForSecondsRealtime(0.3f);
        player.Gravedad(0f);
        player.fallingSpeed = 0;
        player.Velocidad(0f);
        yield return new WaitForSecondsRealtime(2f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.0f);
        jugador.transform.position = posicionCheckPoint;
        yield return new WaitForSeconds(0.2f);        
        player.StartCoroutine("TransitionLvlOut");
        yield return new WaitForSeconds(1f);
        player.Gravedad(-9.81f);
        player.Velocidad(1.5f);
    }

    public void EngancheCaida(bool valor)
    {
        enganchado = valor;
    }

}
