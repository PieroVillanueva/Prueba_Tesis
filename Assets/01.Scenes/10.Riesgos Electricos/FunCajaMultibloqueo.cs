using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunCajaMultibloqueo : MonoBehaviour
{
    public bool primeraVez;
    public Lvl_Manager manager;
    public GameObject llave;
    public GameObject tapaCaja;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Detect"))
        {
            if (!primeraVez)
            {
                primeraVez = true;
                manager.CumplirTarea(12);
                tapar();
                Debug.Log("TERMINEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            }

        }
    }
    public void dejarLlave()
    {
        if (primeraVez)
        {
            StartCoroutine(desaparecerLlave());
        }
    }
    IEnumerator desaparecerLlave()
    {
        yield return new WaitForSeconds(0.1f);
        llave.SetActive(false);
    }
    public void tapar()
    {
        tapaCaja.transform.Rotate(0, 0, -30);
    }
}
