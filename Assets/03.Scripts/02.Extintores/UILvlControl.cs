using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILvlControl : MonoBehaviour
{
    [Header("Contador Inicial / Panel Final")]
    public Image BGColor;
    public Text TextPanel;

    [Header("Tareas")]
    public string[] textoTareas;
    public Toggle estadoTarea;

    [Header("Timer")]
    public Text timer;

    [Header("AudioGame")]
    public AudioSource audioMain;
    public AudioClip[] tareasAudio;
    public GameObject ImgAudio;    

    [Header("Panel Resultado")]
    public GameObject panelResultado;
    public Text finalTime;

    public GameManager managerLvl;
    // Start is called before the first frame update
    void Start()
    {
        managerLvl = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
        StartCoroutine(CDTimer());
        LimpiarTareas();
    }

    public void LimpiarTareas()
    {
        managerLvl.LimpiarTareas();
    }

    IEnumerator CDTimer()
    {
        yield return new WaitForSeconds(0.5f);
        int cd = 3;        
        while (cd > 0)
        {            
            TextPanel.text = $"<size=300>{cd}</size>";
            yield return new WaitForSeconds(1);
            cd--;
        }
        GameObject bgparent = BGColor.transform.parent.gameObject;
        StartCoroutine(iniciarIndicador(0.5f));
        managerLvl.StartGame();
        StartCoroutine(TimerUI());
        bgparent.SetActive(false);
    }

    IEnumerator TimerUI()
    {
        int sec = 0;
        int min = 0;

        while (managerLvl.completeLvl == false)
        {
            sec = managerLvl.timerGame % 60;
            min = managerLvl.timerGame / 60;
            timer.text = $"{min.ToString("00")}:{sec.ToString("00")}";
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator CompleteText()
    {
        managerLvl.completeLvl = true;
        GameObject bgparent = BGColor.transform.parent.gameObject;
        timer.gameObject.SetActive(false);
        estadoTarea.gameObject.SetActive(false);
        ImgAudio.SetActive(false);
        bgparent.SetActive(true);


        audioMain.clip = tareasAudio[4];
        audioMain.Play();
        StartCoroutine(audioPlayed());

        string msjFinal= "PRUEBA EXITOSA";
        string nvoMsj = "";
        foreach(char caracter in msjFinal)
        {
            nvoMsj += caracter;
            TextPanel.text = $"<size=160>{nvoMsj}</size>";
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2f);
        bgparent.SetActive(false);
        MostrarResultado();
    }
    
   
    public void ConfirmarTarea(int valueTarea)
    {
        if (valueTarea == managerLvl.tareaActual)
        {
            estadoTarea.isOn = managerLvl.tareas[valueTarea] = true;             
            StartCoroutine(ResetIndicador());
        }        
    }
    IEnumerator ResetIndicador()
    {
        yield return new WaitForSeconds(0.5f);
        estadoTarea.gameObject.SetActive(false);        
        yield return new WaitForSeconds(0.5f);
        managerLvl.tareaActual++;
        if (managerLvl.CompletarActividad() == false)
        {
            StartCoroutine(iniciarIndicador(0));
        }
        else
        {
            StartCoroutine(CompleteText());
        }
        
    }

    IEnumerator iniciarIndicador(float delay)
    {
        yield return new WaitForSeconds(delay);
        int tareaValue = managerLvl.tareaActual;
        estadoTarea.GetComponentInChildren<Text>().text = textoTareas[tareaValue];
        estadoTarea.gameObject.SetActive(true);
        estadoTarea.isOn = false;
        if (tareasAudio[tareaValue] != null)
        {
            audioMain.clip = tareasAudio[tareaValue];
            audioMain.Play();
            StartCoroutine(audioPlayed());
        }        
    }

    IEnumerator audioPlayed()
    {
        Image imgAud = ImgAudio.transform.GetChild(0).GetComponent<Image>();
        GameObject audioIco = ImgAudio.transform.GetChild(1).gameObject;

        Color imcolor = imgAud.color;        
        while (audioMain.isPlaying)
        {
            imcolor.a = 1f;
            imgAud.color = imcolor;
            audioIco.SetActive(true);
            yield return new WaitForFixedUpdate();
        }
        imcolor.a = 0.5f;
        imgAud.color = imcolor;
        audioIco.SetActive(false);
    }

    public void Finalizar()
    {
        managerLvl.completeLvl = true;
    }
    void MostrarResultado()
    {
        panelResultado.SetActive(true);        
        finalTime.text = $"<color={ColorTiempo()}>Tiempo realizado: {timer.text} s</color>";
    }
    string ColorTiempo()
    {
        if (managerLvl.timerGame < 150)
        {
            return "green";
        }
        return "red";
    }

    public void SelectScene(int value)
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        player.StartCoroutine("TransitionLvlIn");
        StartCoroutine(endTransiion(value));
    }
    IEnumerator endTransiion(int value)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(value, LoadSceneMode.Single);
    }
}
