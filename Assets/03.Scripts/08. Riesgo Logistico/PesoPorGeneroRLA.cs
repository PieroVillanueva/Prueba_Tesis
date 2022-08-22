using UnityEngine;
using System.Collections;

public class PesoPorGeneroRLA : MonoBehaviour
{
    // Start is called before the first frame update
    public SeleccionarSexoRLA sexo;
    public RLA_Manager manager;
    public float peso;
    public bool cajaAgarrada;
    public AccidenteCargaManualRLA accidente;
    public MeshRenderer texturaSnap;
    public GameObject hijo;
    public AudioSource audioSource;
    public AudioClip locuciones;
    Movement player;
    public AudioClip audioCaja;
    public TwoHandsGrabInteractable twoHands;
    void Start()
    {
        hijo.SetActive(false);
        player = GameObject.Find("VR Rig").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {       
            if (sexo.hombre || !sexo.hombre)
            {
                if (peso <= sexo.pesoMaxSoportado)
                {
                    Debug.Log("Puedes cargarlo");
                }
                else
                {
                    sexo.gameObject.GetComponent<Movement>().speed = 0.5f;
                    Debug.Log("Sobrepasaste tu límite de peso");
                }
            }         
        }
    }*/

    public void ComprobarPesoGenero()
    {
        cajaAgarrada = true;
        if (sexo.hombre || !sexo.hombre)
        {
            if (peso <= sexo.pesoMaxSoportado)
            {
                Debug.Log("Puedes cargarlo");
                audioSource.clip = audioCaja;
                audioSource.Play();
            }
            else
            {
                sexo.gameObject.GetComponent<Movement>().speed = 0.5f;
                player.Warning = true;
                Debug.Log("Sobrepasaste tu límite de peso");
                player.StartCoroutine("WarningEffect");
                StartCoroutine(Accidente());
            }
        }
    }

    public void PermitirAgarre(bool x)
    {
        if (sexo.hombre || !sexo.hombre)
        {
            if (peso <= sexo.pesoMaxSoportado)
            {
                twoHands.trackPosition = x;
                twoHands.trackRotation = x;
            }
        }
    }

    public void PasarReferencias()
    {
        accidente.collPadre = gameObject.GetComponent<BoxCollider>();
        accidente.textuPadre = gameObject.GetComponent<MeshRenderer>();
        accidente.copia = transform.GetChild(0).gameObject;
    }

    public void EliminarReferencias()
    {
        accidente.collPadre = null;
        accidente.textuPadre = null;
        accidente.copia = null;
    }

    public void VelocidadNormal()
    {
        //audioSource.clip = audioCaja;
        //audioSource.Play();
        audioSource.PlayOneShot(audioCaja);
        cajaAgarrada = false;
        player.Warning = false;
        sexo.gameObject.GetComponent<Movement>().speed = 1.5f;
    }

    public void QuitarMeshSnap()
    {
        texturaSnap.enabled = false;
    }

    public void ActivarTarea()
    {
        if (peso <= sexo.pesoMaxSoportado)
        {
            manager.CumplirTarea(6);
        }
        
    }

    IEnumerator Accidente()
    {
        audioSource.clip = locuciones;
        audioSource.Play();
        while (audioSource.isPlaying == true)
        {
            //Debug.Log("Se esta reproduciendo audio");
            yield return new WaitForFixedUpdate();
        }
        if (cajaAgarrada)
        {
            player.Velocidad(0);
        }
        player.Warning = false;

    }
}
