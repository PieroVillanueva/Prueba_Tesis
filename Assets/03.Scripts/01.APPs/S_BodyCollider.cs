using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BodyCollider : MonoBehaviour
{

    [Tooltip("tipos: cabeza, manos, cuerpo y piernas")]
    public string tipoApp;
    public S_APPs app;
    public AudioSource appAudioSource;


    [Header("Cambio material")]
    [Tooltip("Iniciar en true si quieres que tome un material al iniciar")]
    public bool init_otherMaterial;

    //Cambiar por uno generico cuando se tenga cuerpo completo
    public HandPresence ModelSkinned;
    [Tooltip("Si init_otherMaterial es true, colocar el material con el que iniciara el modelo.")]
    public Material InitMaterial;

    public S_MeshAppBody materialsManager;

    [Header("Energias Peligrosas")]
    public S_bodyApps listaApps;

    

    [Header("Espacios confinados")]
    public ValidarImplemtos implementos;
    public int indice;

    

    // Start is called before the first frame update
    void Start()
    {
        appAudioSource = gameObject.GetComponentInParent<AudioSource>();
        StartCoroutine(AsignarMaterial());
    }

    IEnumerator AsignarMaterial()
    {
        yield return new WaitForSeconds(0.2f);
        ModelSkinned = GetComponentInChildren<HandPresence>();

        
        if (init_otherMaterial == true && InitMaterial != null) ModelSkinned.skin.material = InitMaterial;
    }
    

    
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("App"))
        {
            app = other.GetComponent<S_APPs>();

            //Debug.Log($"esta tocando BodyCollider {gameObject.name} el app {app.APP}");
            if(app!=null)
                {
                if (app.enMano == true && tipoApp == app.APP.ToString() && app.forPlayer == true)
                {
                    //appAudioSource.clip = app.appSound;

                    //Exclusivo de Energias peligrosas
                    //esto se llama al sortar el APP, Coloca el APP en listaApps
                    if (listaApps != null)
                    {
                        listaApps.colocarObjetos(app);
                        //quitar indicador
                        other.GetComponent<ObjetoFuncion>().noVolverAsignar = true;

                    }
                    //

                    //Colocacion de APPs
                    if (materialsManager != null)
                    {
                        materialsManager.CambiarMeshAPP(app);
                    }

                    if (gameObject.activeInHierarchy) appAudioSource.PlayOneShot(app.appSound);
                    //appAudioSource.Play();

                    //Desactivar APP
                    other.gameObject.SetActive(false);

                    //Exclusivo de Espacios Confinados
                    if (implementos != null)
                    {
                        implementos.VerificarImplemento(true, indice);
                        other.GetComponent<ObjetoLetrero>().Desactivar();
                    }
                    //
                    Debug.Log($"se coloco App {tipoApp}");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("App"))
        {
            app = null;
            appAudioSource.clip = null;
            if (implementos != null)
            {
                if (!implementos.VerificarPosicion(indice))
                {
                    implementos.VerificarImplemento(false, indice);
                }
            }
            Debug.Log("no se coloco App");
        }
    }






}
