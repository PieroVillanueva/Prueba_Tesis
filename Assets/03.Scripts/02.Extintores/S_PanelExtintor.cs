using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_PanelExtintor : MonoBehaviour
{
    [Header("UILvlControl")]
    public UILvlControl controller;

    [Header("Componentes")]
    public GameObject[] muestraRptas;
    public Transform[] posRptas;
    public int rpta;
    public RawImage imgVer;
    public GameObject PanelPregunta;

    [Header("Otros")]
    public GameObject prefabCorrecto;
    public bool used;

    public GameManager managerLvl;
    // Start is called before the first frame update
    void Start()
    {
        managerLvl = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
        IniciarPanel();
        PanelPregunta.SetActive(false);
    }
    public void AparecerExtintor()
    {
        
        if (used == false)
        {
            prefabCorrecto.SetActive(true);
            used = true;
            controller.ConfirmarTarea(1);
        }
    }

    // Update is called once per frame
    void IniciarPanel()
    {
        imgVer.gameObject.SetActive(false);
        for(int i = 0; i < muestraRptas.Length; i++)
        {
            //Asignamos los nombres a los espacios de nombre por elemento que se va a crear.
            string clonName = "" + muestraRptas[i].name;           
            Text nameRpta = posRptas[i].GetComponentInChildren<Text>();
            nameRpta.text = clonName;
            GameObject clon = Instantiate(muestraRptas[i]);
            //LLamamos al clon y lo hacemos child en su posion por respuesta, ademas de escalarlo y que este termine viendo frente a su posion al crearlo.
            clon.transform.parent = posRptas[i].Find("SpawnPoint").transform;
            clon.transform.position = posRptas[i].Find("SpawnPoint").transform.position;            
            clon.transform.localScale = Vector3.one;
            clon.transform.localEulerAngles = Vector3.forward;
        }
    }

    public void VerificarRpta(int rptaValue)
    {
        if (rptaValue == rpta)
        {            
            imgVer.color = Color.green;
            AparecerExtintor();
            StartCoroutine(ActivarPanelPregunta(false));
        }
        else
        {            
            imgVer.color = Color.red;
        }
        StartCoroutine(AnimacionPanel());
    }

    IEnumerator AnimacionPanel()
    {
        imgVer.gameObject.SetActive(true);
        ADCollider(false);
        yield return new WaitForSeconds(1f);
        imgVer.gameObject.SetActive(false);
        ADCollider(true);
    }

    void ADCollider(bool value)
    {
        foreach(var collider in posRptas)
        {
            collider.GetComponent<Collider>().enabled = value;
        }
    }
    IEnumerator ActivarPanelPregunta(bool value)
    {
        yield return new WaitForSeconds(1f);
        PanelPregunta.SetActive(value);        
    }

    public void ActivarPanel(int valueTarea)
    {        
        if (managerLvl.tareaActual == valueTarea)
        {
            StartCoroutine(ActivarPanelPregunta(true));
            controller.ConfirmarTarea(valueTarea);
        }
    }
}
