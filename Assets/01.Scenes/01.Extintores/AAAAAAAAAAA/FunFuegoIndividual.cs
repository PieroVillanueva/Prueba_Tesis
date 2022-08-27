using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunFuegoIndividual : MonoBehaviour
{
    public float fireLife = 100f;
    float MaxFireLife = 100f;
    public GameObject[] particles;
    public BoxCollider boxC;
    //public bool reflame = false;
    // Start is called before the first frame update
    public FunFuegoGeneral manager;
    void Start()
    {
        boxC = GetComponent<BoxCollider>();
        manager = gameObject.GetComponentInParent<FunFuegoGeneral>();
    }

    // Update is called once per frame
    void Update()
    {
        float actLife = fireLife / MaxFireLife;
        ParticlesScale(actLife);
        if (fireLife <= 1)
        {
            gameObject.SetActive(false);
            manager.ActivarVerificacion();
            manager.resizeSphere();
            Debug.Log(this.name + " se apago");
        }
        fireLife = Mathf.Clamp(fireLife, 0, 100);
    }

    void ParticlesScale(float value)
    {
        foreach (GameObject particle in particles)
        {
            particle.transform.localScale = Vector3.one * value;
            boxC.size = new Vector3(value, value, 1);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        fireLife -= 50 * Time.deltaTime;
        //Debug.Log(other.name);
    }

}
