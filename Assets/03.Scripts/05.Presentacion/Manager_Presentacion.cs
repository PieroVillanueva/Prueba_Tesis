using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Presentacion : Lvl_Manager
{
    public S_ColliderTarea Aro;
    public Vector3 aroPos1;
    public Vector3 aroPos2;
    public GameObject salida;
    public GameObject letrero;
    // Start is called before the first frame update
    public override void Start()
    {
        //Ejecuta las lineas que heredo
        base.Start();

        Aro.gameObject.SetActive(false);
        salida.SetActive(false);
        letrero.SetActive(false);
        StartCoroutine(Tareas(actualTarea));
    }

    public override void CumplirTarea(int indexTarea)
    {
        base.CumplirTarea(indexTarea);

        StartCoroutine(Tareas(actualTarea));
    }
    IEnumerator Tareas(int tarea)
    {

        yield return new WaitForSeconds(3);
        switch (tarea)
        {
            case 0:
                while (audioController.audioSource.isPlaying==true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                Debug.Log("se termino el audio tarea 0");
                Aro.gameObject.SetActive(true);
                Aro.transform.position = aroPos1;
                break;
            case 1:
                
                while (audioController.audioSource.isPlaying == true)
                {
                    //Debug.Log("Se esta reproduciendo audio");
                    yield return new WaitForFixedUpdate();
                }
                letrero.SetActive(true);
                Debug.Log("termino audio tarea 1");
                break;
            case 2:
                Debug.Log("No hay caso especial, solo debe encender la pelota");
                break;
            case 3:
                letrero.SetActive(false);
                Aro.gameObject.SetActive(true);
                Aro.tareaACumplir = 3;
                Aro.transform.position = aroPos2;
                salida.SetActive(true);
                break;

        }
    }

    
}
