using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Electrificar : MonoBehaviour
{
    public bool startEnable;
    public AudioClip clip;
    public GameObject Personaje;
    public GameObject electricidad;
    public Transform offset;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(startEnable);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip);

            S_ControlEffect control = obj.GetComponentInChildren<S_ControlEffect>();
            control.Vibracion();

            
            electricidad.transform.position = offset.transform.position;
            electricidad.SetActive(true);
            StartCoroutine(muerte());
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
