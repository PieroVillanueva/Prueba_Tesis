using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindRLA : MonoBehaviour
{
    public AccidenteEstantesRLA[] accidente;
    public RLA_Manager manager;
    Movement player;
    public bool primera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("VR Rig").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Rewind());
        }
    }

    public void ActivarRewind()
    {
        StartCoroutine(Rewind());
    }

    IEnumerator Rewind()
    {
        
        yield return new WaitForSecondsRealtime(1.1f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.1f);
        manager.montacargas2.SetActive(false);
        RewindTime();
        manager.vallasSeguridad.SetActive(true);
        player.StartCoroutine("TransitionLvlOut");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    public void RewindTime()
    {
        foreach (AccidenteEstantesRLA ac in accidente)
        {
            foreach (Estantes estantes in ac.estantes)
            {
                estantes.Rewind();
            }
        }
        
    }
}
