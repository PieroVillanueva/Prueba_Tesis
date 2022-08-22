using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_tableroPuerta : MonoBehaviour
{

    public AudioClip clip;
    public float angulo;
    public List<GameObject> objetosDepanel;
    public bool abierto;
    public Lvl_Manager lvl_manager;
    public GameObject eje;

    public bool inicial;

    public MeshRenderer puerta;
    void Awake()
    {
        lvl_manager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();

    }
    void Start()
    {
        abierto = true;        
        angulo = 180;
        AbrirOCerrar();
        inicial = true;
        //StartCoroutine(iniciarPanel());
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
            if (!abierto)
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
        transform.RotateAround(eje.gameObject.transform.position, new Vector3(0, -1, 0), angulo);
        angulo *= -1;
        if (inicial == true) GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip);
        abierto = !abierto;
        puerta.material.SetFloat("_EMISSION", 0);
        StartCoroutine(iniciarPanel());        
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            AbrirOCerrar();
            
        }
    }





}
