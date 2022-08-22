using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerOyL_SO : MonoBehaviour
{
    public Text textoTimer;
    public bool activar = true;
    private bool primeraVez = false;
    public float tiempoXSegundo;
    private float tiempoAux;
    private int minutos = 0;
    private int segundos = 0;
    private float frame = 0f;
    private float escala = 1f;
    public List<ObstaculoSO> obstaculos;
    public ManagerOyL_SO manager;
    // Start is called before the first frame update
    void Start()
    {
        tiempoAux = tiempoXSegundo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarTimer()
    {
        tiempoXSegundo = tiempoAux;
        primeraVez = false;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (tiempoXSegundo != 0 && activar)
        {
            frame = Time.deltaTime * escala;
            tiempoXSegundo -= frame;
            Formato();
            if (tiempoXSegundo <= 60 && !primeraVez)
            {
                primeraVez = true;
                EstadoPanelesPorTiempo(true);
            }
            yield return new WaitForSeconds(0.01f);
        }
        manager.FinalizarEscena();
    }

    public void EstadoPanelesPorTiempo(bool estado)
    {
        foreach (ObstaculoSO aux in obstaculos)
        {
            if (aux.enUso)
            {
                aux.ColocarPanel(estado);
            }     
        }
    }

    public void Formato()
    {
        if (tiempoXSegundo < 0)
        {
            tiempoXSegundo = 0;
        }
        minutos = (int)tiempoXSegundo / 60;
        segundos = (int)tiempoXSegundo % 60;
        textoTimer.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }
}
