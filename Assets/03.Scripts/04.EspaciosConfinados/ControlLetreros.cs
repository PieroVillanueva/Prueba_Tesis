using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLetreros : MonoBehaviour
{
    public GameObject obj;
    public Vector3 offset;
    public Camera cameraMain;
    public float velocidad;
    public float distancia;
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = obj.transform.position + offset + new Vector3(0, Mathf.PingPong(Time.time * velocidad, distancia), 0);
        transform.LookAt(cameraMain.transform.position);
    }
    public void Mostrar()
    {
        gameObject.SetActive(true);
    }
    public void Ocultar()
    {
        gameObject.SetActive(false);
    }
}
