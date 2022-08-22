using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//este codigo solo funciona con la particula a trabajar
//en el espacio de Trigger de la particula asignar el objeto que sera el que recepcione el mensaje para activar "f"
//!!!No olvidar la agignacion!!!!
public class DetectParticle : MonoBehaviour
{
    public ParticleSystem ps;
    public bool f;
    public bool ocurrioAccidente;
    public FunFuncionesTra_Caliente contadorBasura;
    public GameObject fuego;
    [Header("Accidente Oxicorte")]
    public bool activarAccidenteOxicorte;
    public FunManagerOxicorte_Trabajo managerNivel; 

    void OnParticleCollision(GameObject other)
    {  
        //Debug.Log("detecto particula");
    }
    void OnParticleTrigger()
    {
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        f = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter) != 0 ? true : false;
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        if (f&&!ocurrioAccidente)
        {
            if (contadorBasura.existeBasura)
            {
                ocurrioAccidente = true;
                Debug.Log("Esto se prendió");
                fuego.SetActive(true);
                if (activarAccidenteOxicorte) 
                {
                    managerNivel.accidentePorFuego();
                }

            }
        }
        
    }  
    
}
