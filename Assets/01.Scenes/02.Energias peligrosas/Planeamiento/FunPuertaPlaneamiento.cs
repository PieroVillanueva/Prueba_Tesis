using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunPuertaPlaneamiento : MonoBehaviour
{
    public AudioClip clip;
    public float angulo;
    public bool abierto;
    public GameObject colliderPanel;
    public GameObject eje;
    void Awake()
    {
        //colliderPanel.SetActive(false);
    }
    void Start()
    {
        angulo = 180;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AbrirOCerrar()
    {
        
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            transform.RotateAround(eje.gameObject.transform.position, new Vector3(0, -1, 0), angulo);
            angulo *= -1;
            GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip);
            abierto = !abierto;
            colliderPanel.SetActive(abierto);
        }
    }
}
