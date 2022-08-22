using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunElectrificar : MonoBehaviour
{
    public AudioClip clip;
    public GameObject Personaje;
    public GameObject electricidad;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player")) //En caso se toque con las manos, se generan chispas y el usuario va a emergencia
        {
            GameObject.Find("SoundManager").GetComponent<AudioSource>().PlayOneShot(clip);

            S_ControlEffect control = obj.GetComponentInChildren<S_ControlEffect>();
            control.Vibracion();

            electricidad.transform.position = gameObject.transform.position;
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
