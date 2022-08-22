using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCajaMaquinaRLA : MonoBehaviour
{
    // Start is called before the first frame update
    public RLA_Manager manager;
    public BotonesMovimientoMaquinaRLA up;
    public BotonesMovimientoMaquinaRLA down;
    public Transform apoyos;
    public AudioSource audioSource;
    public AudioClip subir;
    public AudioClip bajar;
    public Vector3 movimiento;
    public float maxUp, maxDown;
    public float velocidad;
    void Start()
    {

    }

    void Update()
    {
        
    }

    
    IEnumerator BajarySubir()
    {
        /*if (parte1.enPosicion && parte2.enPosicion)
        {      
        Valida que se mueva solo cuando se haya posicionado correctamente
        }*/
        
        movimiento.x = apoyos.localPosition.x;
        movimiento.z = apoyos.localPosition.z;
        while (up.activar && apoyos.localPosition.y < maxUp)
        {
            movimiento.y = apoyos.localPosition.y;
            movimiento.y += velocidad * Time.deltaTime;
            apoyos.localPosition = movimiento;
            if (!audioSource.isPlaying)
            {
                audioSource.clip = subir;
                audioSource.Play();
            }
            //yield return new WaitForSeconds(0.1f);
            yield return new WaitForFixedUpdate();
        }
        while (down.activar && apoyos.localPosition.y > maxDown)
        {
            movimiento.y = apoyos.localPosition.y;
            movimiento.y -= velocidad * Time.deltaTime;
            apoyos.localPosition = movimiento;
            if (!audioSource.isPlaying)
            {
                audioSource.clip = bajar;
                audioSource.Play();
            }
            yield return new WaitForFixedUpdate();
        }
        audioSource.Stop();
        manager.CumplirTarea(14);
    }
}
