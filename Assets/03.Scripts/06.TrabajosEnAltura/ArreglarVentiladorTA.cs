using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArreglarVentiladorTA : MonoBehaviour
{
    public GameObject aro;
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip clip;
    public FunCheckList checkList;
    public ManagerTA manager;
    public bool primera;
    public GameObject defectuoso;
    public GameObject cambio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destornillador"))
        {
            if (!primera)
            {
                StartCoroutine(ArreglarVentilación());

                
                checkList.activarCheck(5);
                manager.fresnelDestornillador.material.SetFloat("_EMISSION", 0);
                primera = true;

            }

        }
    }

    IEnumerator ArreglarVentilación()
    {
        Movement player = GameObject.Find("VR Rig").GetComponent<Movement>();
        yield return new WaitForSecondsRealtime(1.1f);
        audioSource.clip = clip;
        player.StartCoroutine("TransitionLvlIn");
        audioSource.Play();
        yield return new WaitForSeconds(1.1f);
        defectuoso.SetActive(false);
        cambio.SetActive(true);
        player.StartCoroutine("TransitionLvlOut");
        yield return new WaitForSeconds(1f);
        aro.SetActive(true);
        manager.CumplirTarea(9);
    }
}
