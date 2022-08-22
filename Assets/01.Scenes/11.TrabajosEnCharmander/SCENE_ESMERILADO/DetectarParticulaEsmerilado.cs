using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarParticulaEsmerilado : MonoBehaviour
{
    public ParticleSystem ps;
    public bool f;
    public bool ocurrioAccidente;
    public bool limpioPiso;
    public GameObject fuego;

    [Header("Accidente Esmerilado")]
    public bool activarAccidenteEsmerilado;
    public FunManagerEsmerilado managerNivel;

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("detecto particula");
    }
    void OnParticleTrigger()
    {
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        f = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter) != 0 ? true : false;
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        if (f && !ocurrioAccidente)
        {
            if (!limpioPiso)
            {
                ocurrioAccidente = true;
                fuego.SetActive(true);
                if (activarAccidenteEsmerilado)
                {
                    managerNivel.accidentePorFuego();
                }
            }
        }

    } 
    public void LimpiarPiso()
    {
        limpioPiso = true;
    }
}
