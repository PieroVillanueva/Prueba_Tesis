using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FunColocarPresion : MonoBehaviour
{
    public Text textoPresion;
    public float tiempoPresion;
    public int numeroPresion;
    public bool terminado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void empezarConteoPresion()
    {
        terminado = false;
        StartCoroutine(conteoPresion());
    }
    public void pararConteoPresion()
    {
        terminado = true;
        textoPresion.text = "0";
    }
    IEnumerator conteoPresion()
    {
        tiempoPresion = 0;
        numeroPresion = Random.Range(80, 120);
        int aleatorio;
        while (true) { 
            yield return new WaitForSecondsRealtime(3.0f);
            tiempoPresion += 3.0f;
            if (tiempoPresion >= 5)
            {
                aleatorio= Random.Range(-3+numeroPresion, 3+numeroPresion);
                if (aleatorio >= 80 && aleatorio <= 120)
                {
                    textoPresion.text = "" + aleatorio;
                    numeroPresion = aleatorio;
                }
                else
                {
                    textoPresion.text = "" + numeroPresion;
                }
            }
            if (terminado)
            {
                yield break;
            }
        }
    }
}
