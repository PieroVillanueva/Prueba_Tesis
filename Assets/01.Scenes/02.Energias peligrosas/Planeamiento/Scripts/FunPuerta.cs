using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunPuerta : MonoBehaviour
{
  
    public AudioClip clip;
    public float angulo;
    public List<GameObject> objetosDepanel;
    public bool abierto;
    public bool PrimeraVez;
    public Lvl_Manager lvl_manager;
    public GameObject eje;
    void Awake()
    {
        lvl_manager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();

    }
    void Start()
    {
        abierto = false;
        PrimeraVez = true;
        angulo = 180;
        StartCoroutine(iniciarPanel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator iniciarPanel()
    {        
        yield return new WaitForSeconds(0.1f);
        foreach (GameObject obj in objetosDepanel)
        {
            if (abierto)
            {
                obj.gameObject.SetActive(true);
            }
            else
            {
                obj.gameObject.SetActive(false);
            }
        }
    }
    
    public void AbrirOCerrar()
    {
        /*
        transform.RotateAround(new Vector3(15.333f, 1.676f, 11.277f), new Vector3(0, -1, 0), angulo);
        angulo *= -1;
        GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip);
        abierto = !abierto;
        StartCoroutine(iniciarPanel());
        if (PrimeraVez)
        {
            PrimeraVez = false;
            lvl_manager.CumplirTarea(0);
        }*/
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            transform.RotateAround(eje.gameObject.transform.position, new Vector3(0, -1, 0), angulo);
            angulo *= -1;
            GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip);
            abierto = !abierto;
            StartCoroutine(iniciarPanel());
            if (PrimeraVez)
            {
                PrimeraVez = false;
                lvl_manager.CumplirTarea(0);
            }
        }
    }





}
