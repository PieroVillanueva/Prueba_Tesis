using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeManagerSO : MonoBehaviour
{
    
    public Text textAccidentesEvitados;
    public Text textAccidentesNoEvitados;
    public Text textAccidentesEvitadosGeneral;
    public Text textAccidentesNoEvitadosGeneral;
    public int puntajeSecuenciaCompleta;
    public int puntajeAccidente;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReiniciarPuntaje()
    {
        textAccidentesEvitados.text = "Accidentes Evitados: 0";
        textAccidentesNoEvitados.text = "Accidentes no Evitados: 0";
        puntajeSecuenciaCompleta = 0;
        puntajeAccidente = 0;
    }

    public void ColocarPuntaje()
    {
        textAccidentesEvitadosGeneral.text = "Accidentes Evitados: " + puntajeSecuenciaCompleta;
        textAccidentesNoEvitadosGeneral.text = "Accidentes no Evitados: " + puntajeAccidente;
    }
    
    public void SecuenciaCompleta()
    {
        StartCoroutine(CompletarSecuencia());
    }

    public void Accidente()
    {
        StartCoroutine(AccidenteSO());       
    }

    IEnumerator AccidenteSO()
    {
        puntajeAccidente++;
        textAccidentesNoEvitados.text = "Accidentes no Evitados: " + puntajeAccidente;
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator CompletarSecuencia()
    {
        puntajeSecuenciaCompleta++;
        textAccidentesEvitados.text = "Accidentes Evitados: " + puntajeSecuenciaCompleta;
        yield return new WaitForSeconds(0.1f);
    }
}
