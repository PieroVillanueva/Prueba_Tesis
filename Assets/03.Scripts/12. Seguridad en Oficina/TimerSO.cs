using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TimerC
{
    public Text textoTimer;
    public bool activar;
    public float tiempoXSegundo;
    public int minutos = 0;
    public int segundos = 0;
    public float frame = 0f;
    public float escala = 1f;
    public string texto;
    private float tiempoAuxiliar;
    private float tiempoInicial;

    public void ObtenerTiempoInicial()
    {
        tiempoInicial = tiempoXSegundo;
    }

    public void ObtenerTiempo()
    {
        tiempoAuxiliar = tiempoXSegundo;
    }

    public void ReiniciarTiempo()
    {
        tiempoXSegundo = tiempoAuxiliar;
    }

    public void ReiniciarTiempoInicial()
    {
        tiempoXSegundo = tiempoInicial;
    }
}

public class TimerSO : MonoBehaviour
{
    public List<TimerC> timers;
    public SpawnerSO spawner;
    // Start is called before the first frame update
    void Start()
    {
        timers[0].ObtenerTiempoInicial();
        timers[1].ObtenerTiempoInicial();
        //timers[2].ObtenerTiempoInicial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EstadoTimer(bool estado)
    {
        foreach (TimerC aux in timers)
        {
            aux.activar = estado;
        }
    }

    public void ReiniciarTiempo()
    {
        foreach (TimerC aux in timers)
        {
            aux.ReiniciarTiempoInicial();
            if (aux.texto.Equals("Tiempo General: "))
            {
                aux.textoTimer.text = aux.texto + " 00:00";
            }
            else
            {
                aux.textoTimer.text = "00";
            }
            
        }
    }

    public void ComenzarTimer(TimerC timer, int indice) => StartCoroutine(Timer(timer, indice)); 

    IEnumerator Timer(TimerC timer, int indice)
    {
        while (timer.tiempoXSegundo != 0 && timer.activar)
        {
            timer.frame = Time.deltaTime * timer.escala;
            timer.tiempoXSegundo -= timer.frame;
            Formato(timer, indice);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    public void Formato(TimerC timer, int indice)
    {
        if (timer.tiempoXSegundo < 0)
        {
            timer.tiempoXSegundo = 0;
        }
        timer.minutos = (int)timer.tiempoXSegundo / 60;
        timer.segundos = (int)timer.tiempoXSegundo % 60;
        if (indice == 0)
        {
            timer.textoTimer.text = timer.texto + timer.minutos.ToString("00") + ":" + timer.segundos.ToString("00");
        }
        else
        {
            timer.textoTimer.text = timer.segundos.ToString("00");
        }
        
    }
}
