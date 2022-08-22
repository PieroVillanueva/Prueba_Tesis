using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunArenero : MonoBehaviour
{
    public bool puedeEncender;
    public bool botonPresionado;
    public GameObject arena;
    public FunValidacionesArenado validaciones;
    public int contador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activarPuedeEncender()
    {
        puedeEncender = true;
        StartCoroutine(bucleArenero());
    }
    public void presionarBotonArenero()
    {
        botonPresionado = true;
        StartCoroutine(bucleArenero());
    }
    public void soltarBotonArenero()
    {
        botonPresionado = false;
    }
    IEnumerator bucleArenero()
    {
        while (puedeEncender&&botonPresionado)
        {
            yield return new WaitForSeconds(0.1f);
            arena.SetActive(true);
            
            contador++;
            contador = Mathf.Clamp(contador, 1, 41);
            if (!validaciones.todosEPPColocados && contador == 40)
            {
                Debug.Log("Intoxicación");
            }
        }
        arena.SetActive(false);
    }
}
