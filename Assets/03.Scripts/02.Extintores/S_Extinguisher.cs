using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Extinguisher : MonoBehaviour
{
    public ParticleSystem smoke;
    public AudioSource smokeSound;
    public Transform Initialpos;
    public bool ready2Use = false;
    public bool isUsing;
    public float timeToUse = 0;


    public GameManager managerLvl;
    // Start is called before the first frame update
    private void Start()
    {
        managerLvl = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
    }
    public void corfirmarTareaExt(int tareaValue)
    {        
        if(tareaValue == managerLvl.tareaActual)
        {
            UILvlControl UIlvl = GameObject.Find("ControllerUI").GetComponent<UILvlControl>();
            UIlvl.estadoTarea.isOn = managerLvl.tareas[tareaValue] = true;
            UIlvl.StartCoroutine("ResetIndicador");
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            OnExtinguisher();
        }
        if(Input.GetMouseButtonUp(0))
        {
            isUsing = false;
        }
        
    }*/

    public void OnExtinguisher()
    {
        //inicio de salida del componente del extintor.
        isUsing = true;
        if (ready2Use == true) 
        {
            StartCoroutine(ExtinguisherFuntion());            
        }
    }

    public void OffExtinguisher()
    {
        //Bloqueo de salida del componente del extintor.
        isUsing = false;
    }
    public void Repos()
    {
        //Cuando soltemos la manguera se recoloca como lo encontramos inicialmente.
        transform.position = Initialpos.position;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void DisableObj(GameObject obj)
    {
        //sirve para escoder el seguro del extintor.
        StartCoroutine(Disable(obj, 3));
    }
    public void ActiveExt(bool active)
    {
        //Se activa al sacar el seguro del extintor. 
        ready2Use = active;
    }

    IEnumerator ExtinguisherFuntion()
    {
        Debug.Log("inicia disparo");
        //llamamos a una funcion repetitiva para accionar con el disparo con el gatillo.
        while (isUsing /*&& timeToUse<=60*/)
        {
            timeToUse += Time.deltaTime;
            if (smoke.isPlaying == false) 
            {
                smoke.Play();
                smokeSound.Play();
            }
            Debug.Log("continuamos disparando"); 
            yield return new WaitForFixedUpdate();
        }
        //se detiene la corrutina al sobrepasar el tiempo de uso o cuando levantamos el dedo sobre el gatillo de disparo.
        smoke.Stop();
        smokeSound.Stop();
        Debug.Log("termina disparo");
    }
    IEnumerator Disable(GameObject obj,int time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }
    
}
