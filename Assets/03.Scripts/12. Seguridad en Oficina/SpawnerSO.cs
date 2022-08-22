using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSO : MonoBehaviour
{
    [Header("Colaborador")]
    public List<Transform> posicionesColaborador;
    private List<GameObject> colabAuxiliares =  new List<GameObject>();
    public GameObject[] colaboradores;
    public int maxColaboradores;
    public int colaboradoresActuales;
    [Header("Obstaculos")]
    public List<Obstaculo_RC_SO> obstaculos;
    public int maxObstaculos;
    public int obstaculosActual;
    [Header("Posiciones platanos")]
    public List<Transform> posicionesPlatano;
    private List<Transform> auxPosiciones = new List<Transform>();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnerTutorial()
    {
        bool archivador = false, cable = false, agua = false, cascara = false;
        foreach (Obstaculo_RC_SO aux in obstaculos)
        {
            if (aux.ComprobarTipoObstaculo("archivador") && !archivador)
            {
                aux.InvocarObstaculo();
                archivador = true;
            }
            else if (aux.ComprobarTipoObstaculo("cable") && !cable)
            {
                aux.InvocarObstaculo();
                cable = true;
            }
            else if (aux.ComprobarTipoObstaculo("agua") && !agua)
            {
                aux.InvocarObstaculo();
                agua = true;
            }
            else if (aux.ComprobarTipoObstaculo("cascara") && !cascara)
            {
                aux.InvocarObstaculo();
                cascara = true;
            }
        }
    }

    public void AgregarPosicionesAuxiliar(Transform posicion)
    {
        auxPosiciones.Add(posicion);
    }

    public bool ValidarPosicion(Transform posicion)
    {
        foreach (Transform aux in auxPosiciones)
        {
            if (posicion == aux)
            {
                return true;
            }
        }
        return false;
    }

    public void Invocar()
    {   
        while (obstaculosActual < maxObstaculos)
        {
            int nPosicion = Random.Range(0, obstaculos.Count);
            if (!obstaculos[nPosicion].enUso)
            {
                obstaculos[nPosicion].InvocarObstaculo();
                obstaculosActual++;
            }
        }
    }

    public void ResetObstaculos()
    {
        foreach (Obstaculo_RC_SO aux in obstaculos)
        {
            aux.ResetObstaculo();
        }
        obstaculosActual = 0;
        auxPosiciones.Clear();
    }

    public void AsignarPosicion(GameObject objeto, List<Transform> posiciones, int nPosicion)
    {
        objeto.transform.position = posiciones[nPosicion].position;
        objeto.transform.eulerAngles = posiciones[nPosicion].eulerAngles;
    }

    public void AsignarOperario()
    {
        int nPosicion = Random.Range(0, posicionesColaborador.Count);
        int i = 0;
        while (colabAuxiliares.Count < maxColaboradores)
        {
            int indice = Random.Range(0, colaboradores.Length);
            if (!colaboradores[indice].GetComponent<PlayerNavMesh>().asignado)
            {
                colabAuxiliares.Add(colaboradores[indice]);
                colaboradores[indice].GetComponent<PlayerNavMesh>().asignado = true;
                AsignarPosicion(colabAuxiliares[i], posicionesColaborador, nPosicion);
                colabAuxiliares[i].SetActive(true);
                colaboradoresActuales++;
                i++;
                if (maxColaboradores > 1)
                {
                    if (nPosicion == posicionesColaborador.Count - 1)
                        nPosicion -= 2;
                    else
                        nPosicion++;
                }
            }
        }
    }

    public void ReiniciarContadores()
    {
        maxColaboradores = 1;
        colaboradoresActuales = 0;
        maxObstaculos = 2;
    }

    
    public void AvanceOperario() => StartCoroutine(movimientoOperario());
    IEnumerator movimientoOperario()
    {
        while (colabAuxiliares.Count != 0)
        {
            float tiempo = Random.Range(0.5f, 3f);
            yield return new WaitForSeconds(tiempo);
            colabAuxiliares[colabAuxiliares.Count - 1].GetComponent<PlayerNavMesh>().MoverAgente();
            colabAuxiliares.RemoveAt(colabAuxiliares.Count - 1);
        }
        
    }

    public bool HayOperariosEnEscena()
    {
        foreach (GameObject auxiliar in colaboradores)
        {
            if (auxiliar.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }

    public void DetenerColaboradores()
    {
        foreach (GameObject aux in colaboradores)
        {
            if (aux.activeInHierarchy)
            {
                aux.GetComponent<PlayerNavMesh>().DetenerRecorrido(0);
            }
        }
    }

    public void ReiniciarColaboradores()
    {
        foreach (GameObject aux in colaboradores)
        {
            aux.GetComponent<PlayerNavMesh>().ReiniciarColaborador();
        }
        colabAuxiliares.Clear();
        
    }
}
