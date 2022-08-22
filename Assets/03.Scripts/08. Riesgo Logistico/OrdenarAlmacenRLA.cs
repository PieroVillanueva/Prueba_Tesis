using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenarAlmacenRLA : MonoBehaviour
{
    public RLA_Manager manager;
    public GameObject panel;
    public GameObject[] cajas;
    public GameObject cajaDesorden;
    public bool primera;

    public void OrdenarAlmacen()
    {
        StartCoroutine(Ordenar());
    }

    public void ColocarCajasOrden()
    {
        for (int i = 0; i < cajas.Length; i++)
        {
            cajas[i].SetActive(true);
        }
    }

    IEnumerator Ordenar()
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        yield return new WaitForSecondsRealtime(0.3f);
        //yield return new WaitForSecondsRealtime(2f);
        player.StartCoroutine("TransitionLvlIn");
        yield return new WaitForSeconds(1.0f);
        cajaDesorden.SetActive(false);
        ColocarCajasOrden();
        panel.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        player.StartCoroutine("TransitionLvlOut");
        yield return new WaitForSeconds(1f);
        manager.CumplirTarea(21);
    }
}
