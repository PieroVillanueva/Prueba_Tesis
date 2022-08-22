using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerImplementoTA : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject appUsado;
    public S_BodyCollider apps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("App"))
        {
            if (apps.app.enMano == true && apps.tipoApp == apps.app.APP.ToString() && apps.app.forPlayer == true)
            {
                appUsado = apps.app.gameObject;
            }
            
        }
        
    }
}
