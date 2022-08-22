using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FunCargarEsmerilado : MonoBehaviour
{
    [SerializeField] private string targetTag;

    public int porcentaje;
    public bool seguirContando;
    public GameObject siguienteCorte;
    public int limitePorcentaje;

    public FunManagerEsmerilado managerEsmerilado;


    public FunEsmeril esmeril;
    [Header("Accidente No EPP")]
    public bool puedeGenerarAccidente;
    public bool provocoAccidente;
    public FunValidacionesEsmerilado validaciones;
    [Header("Cambio Textura")]
    public GameObject cuboAEsmerilar;
    public Material m_cuboAEsmerilar;

    public UnityEvent terminarEsmerilado = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        seguirContando = true;
        m_cuboAEsmerilar = cuboAEsmerilar.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        float contarAuxiliar;
        if (other.CompareTag(targetTag))
        {
            if (seguirContando)
            {
                if (esmeril.chocaConSuperficie && esmeril.esmerilEncendido) {
                    porcentaje += 1;
                    contarAuxiliar =porcentaje / 4.0f;
                    m_cuboAEsmerilar.SetFloat("indicadorLleno", contarAuxiliar);
                }
                if (porcentaje == (limitePorcentaje/4))
                {
                    if (puedeGenerarAccidente)
                    {
                        if (!validaciones.todosEPPColocados)
                        {
                            seguirContando = false; 
                            provocoAccidente = true;
                            Debug.Log("Accidentado por no EPP.");
                            managerEsmerilado.accidentePorEpp();
                        }
                    }
                }
                if (porcentaje == limitePorcentaje)
                {
                    seguirContando = false;
                    siguientee();
                }
            }
        }
    }
    private void siguientee()
    {
        if (siguienteCorte == null)
        {
            Debug.Log("Esmerilado completado");
            //siguienteCorte.SetActive(true);
            terminarEsmerilado?.Invoke();
            managerEsmerilado.completarNivel();
        }
    }
}
