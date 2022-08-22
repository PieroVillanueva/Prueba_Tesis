using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private List<Transform> movePositionTransform;
    private NavMeshAgent agentNavMesh;
    public SpawnerSO spawner;
    public PuntajeManagerSO puntaje;
    public float velocidad;
    private Animator controlAnimator;
    public bool asignado;
    public bool primera;
    public bool noAplica;
    private Vector3 posicion;
    private Vector3 rotacion;
    
    private void Awake()
    {
        agentNavMesh = GetComponent<NavMeshAgent>();
        controlAnimator = GetComponent<Animator>();
        if (noAplica)
        {
            posicion = transform.localPosition;
            rotacion = transform.localEulerAngles;
        }
    }

    private void Update()
    {
        velocidad = agentNavMesh.velocity.magnitude;
        controlAnimator.SetFloat("velocidad", velocidad);     
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!primera)
        {   
            if (other.CompareTag("Bloqueo"))
            {
                primera = true;
                DetenerRecorrido(1); 

            }
            else if (other.CompareTag("Finish"))
            {
                DetenerRecorrido(0);
            }
            else if (other.CompareTag("PoloPositivo") && other.GetComponent<CablesSO>().enUso)
            {
                primera = true;
                DetenerRecorrido(2);
            }
            else if (other.CompareTag("Mono"))
            {
                primera = true;
                DetenerRecorrido(3);
            }
        }
        
    }

    public void OnEnable()
    {
        primera = false;
    }

    public void MoverAgente()
    {
        int i = Random.Range(0, movePositionTransform.Count);
        int indice = Random.Range(0, 2);
        agentNavMesh.isStopped = false;
        agentNavMesh.destination = movePositionTransform[i].position;
        controlAnimator.SetFloat("IndiceWalk", indice);
    }

    public void DetenerRecorrido(int indice)
    {
        StartCoroutine(DetenerAgente(indice));
    }

    public bool AgenteNoRecorrido()
    {
        if (agentNavMesh.isStopped)
            return true;
        else return false;
    }

    public void ReiniciarColaborador()
    {
        asignado = false;
    }

    IEnumerator DetenerAgente(int indice)
    {
        agentNavMesh.isStopped = true;
        //agentNavMesh.ResetPath();
        if (indice == 1)
        {    
            controlAnimator.SetTrigger("accidente");
            puntaje.Accidente();
            yield return new WaitForSeconds(2.03f);
        }
        else if (indice == 2)
        {
            controlAnimator.SetTrigger("accidenteElectro");
            puntaje.Accidente();
            yield return new WaitForSeconds(2.03f);

        }
        else if (indice == 3)
        {
            controlAnimator.SetTrigger("AccidenteCascara");
            puntaje.Accidente();
            yield return new WaitForSeconds(2.03f);
        }
        asignado = false;
        gameObject.SetActive(false);
        spawner.colaboradoresActuales--;
    }

}
