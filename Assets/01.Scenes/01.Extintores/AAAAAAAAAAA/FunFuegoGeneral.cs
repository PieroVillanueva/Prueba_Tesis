using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FunFuegoGeneral : MonoBehaviour
{
    // public S_FireControl[] fireChild;
    public FunFuegoIndividual[] fireChild;
    public AudioSource fireSound;
    public SphereCollider warningZone;
    public float totalFlames = 4;
    public bool isAlive;
    // Start is called before the first frame update

    //public GameManager managerLvl;

    [SerializeField] private UnityEvent terminadoTarea = new UnityEvent();

    void Start()
    {
        //managerLvl = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
        //fireChild = GetComponentsInChildren<S_FireControl>();
        fireChild = GetComponentsInChildren<FunFuegoIndividual>();
        fireSound.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool CheckFireChild()
    {
        foreach (var fire in fireChild)
        {
            if (fire.gameObject.activeInHierarchy == true)
            {
                return true;
            }
        }
        fireSound.Stop();
        Debug.Log("Termino tareas");
        CompletarTarea(3);
        return false;
    }

    public void resizeSphere()
    {
        totalFlames--;
        if (totalFlames > 0)
        {
            warningZone.radius = 3f * (totalFlames / 4);
        }
    }

    void CompletarTarea(int tareaValue)
    {
        /*
        if (tareaValue == managerLvl.tareaActual)
        {
            UILvlControl UIlvl = GameObject.Find("ControllerUI").GetComponent<UILvlControl>();
            UIlvl.estadoTarea.isOn = managerLvl.tareas[tareaValue] = true;
            UIlvl.StartCoroutine("ResetIndicador");
        }*/
        Debug.Log("TERMINADO NIVEL");
        terminadoTarea?.Invoke();
    }

    public void ActivarVerificacion()
    {
        isAlive = CheckFireChild();
    }
}
