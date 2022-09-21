using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VidoeController : MonoBehaviour
{
    public VideoPlayer videoPanel;

    public RawImage imgPanel;
    float heightsMax;


    public bool isActive=false;
    public bool ready2Play = false;

    [Header("Tareas")]
    public bool completaTarea;
    public int numeroTareaACompletar;
    public Lvl_Manager managerNivel; 
    
    // Start is called before the first frame update
    void Start()
    {
        imgPanel.color = Color.white;
        // heightsMax = imgPanel.rectTransform.sizeDelta.y;                                                                          //comentado piero
        // imgPanel.rectTransform.sizeDelta = new Vector2(imgPanel.rectTransform.sizeDelta.x, 0);                                   //comentado piero
        StartCoroutine(CorreVideo());
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space)) StartCoroutine(CorreVideo());
    }
    IEnumerator CorreVideo()
    {
        //DISEÑO
        StartCoroutine(InitPanel());
        while (ready2Play != true)
        {
            //esperando panel
            yield return new WaitForFixedUpdate();
        }
        
        //LO QUE SIRVE
        if (!videoPanel.isPlaying) videoPanel.Play();

        yield return new WaitForSeconds(0.5f);

        //DISEÑO
        while (videoPanel.isPlaying)
        {
            //esperando video
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);
        //StartCoroutine(ClosePanel());
    }

    // Update is called once per frame
    IEnumerator InitPanel()
    {
        isActive = true;
        ready2Play = false;
        yield return new WaitForFixedUpdate();                                                                                           //agregado piero
        /*
        yield return new WaitForSeconds(0.5f);
        float h = 0;
        while (imgPanel.rectTransform.sizeDelta.y != heightsMax)
        {
            h = Mathf.MoveTowards(h, heightsMax, 1.5f * Time.deltaTime);
            imgPanel.rectTransform.sizeDelta = new Vector2(imgPanel.rectTransform.sizeDelta.x, h);
            yield return new WaitForFixedUpdate();
        }
        
        imgPanel.rectTransform.sizeDelta = new Vector2(imgPanel.rectTransform.sizeDelta.x, heightsMax);
        /*
        /*
        float color = 0;
        while (imgPanel.color != Color.white)
        {
            color = Mathf.MoveTowards(color, 1, 1.5f * Time.deltaTime);
            imgPanel.color = new Color(color, color, color);
            yield return new WaitForFixedUpdate();
        }*/
        Debug.Log("END");
        ready2Play = true;
    }

    IEnumerator ClosePanel()
    {
        yield return new WaitForSeconds(0.5f);
        float color = imgPanel.color.r;
        Debug.Log("END");
        while (imgPanel.color != Color.black)
        {
            color = Mathf.MoveTowards(color, 0, 1.5f * Time.deltaTime);
            imgPanel.color = new Color(color, color, color);
            yield return new WaitForFixedUpdate();
        }        
        
        float h = heightsMax;
        while (imgPanel.rectTransform.sizeDelta.y != 0)
        {
            h = Mathf.MoveTowards(h, 0, 1.5f * Time.deltaTime);
            imgPanel.rectTransform.sizeDelta = new Vector2(imgPanel.rectTransform.sizeDelta.x, h);
            yield return new WaitForFixedUpdate();
        }
        imgPanel.rectTransform.sizeDelta = new Vector2(imgPanel.rectTransform.sizeDelta.x, 0);
        
        Debug.Log("END");
        ready2Play = false;
        isActive = false;
        if (completaTarea)
        {
            completarTarea();
        }
    }

    public void completarTarea()
    {
        managerNivel.CumplirTarea(numeroTareaACompletar);
    }
}
