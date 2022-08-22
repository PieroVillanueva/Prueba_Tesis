using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunMaquina : MonoBehaviour
{
    public GameObject panel;
    public AudioClip clip;
    public AudioClip clipElectrico;
    public Lvl_Manager lvl_manager;
    public bool PrimeraVez;
    public int Turno;
    public GameObject Personaje;
    public Material nuevoMaterial;
    public MeshRenderer caja;
    public GameObject electricidad;
    // Start is called before the first frame update
    void Awake()
    {
        lvl_manager = GameObject.Find("LvLManager").GetComponent<Lvl_Manager>();

    }
    void Start()
    {
        Turno = -1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Destornillador") && Turno == -1)
        {
            GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clipElectrico);
            
            electricidad.transform.position = gameObject.transform.position;
            electricidad.SetActive(true);
            StartCoroutine(muerte());


        }
        if (obj.CompareTag("Destornillador")&&Turno==1)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
            GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip);
            if (!PrimeraVez)
            {
                PrimeraVez = true;
                lvl_manager.CumplirTarea(10);
            }
            caja.material = nuevoMaterial;
        }
        
    }
    IEnumerator muerte()
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();

        yield return new WaitForSeconds(1.1f);
        player.StartCoroutine("TransitionLvlIn");

        yield return new WaitForSeconds(1.1f);
        Personaje.gameObject.transform.position = new Vector3(20.507f, 0.1631045f, -22.786f);
        Personaje.gameObject.transform.Rotate(new Vector3(0, 180, 0));
        player.StartCoroutine("TransitionLvlOut");

        yield return new WaitForSeconds(1f);
    }

}
