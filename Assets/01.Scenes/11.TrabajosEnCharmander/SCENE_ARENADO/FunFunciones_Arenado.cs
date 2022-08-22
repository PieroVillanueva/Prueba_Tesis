using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunFunciones_Arenado : FunMultifunciones
{
    public GameObject personaje;
    public FunValidacionesArenado validaciones;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tocarArena()
    {
        Debug.Log("Prominence Burn");

    }
    public void iniciarLimpieza()
    {
        StartCoroutine(limpieza());
    }
    IEnumerator limpieza()
    {
        yield return new WaitForSeconds(0.1f);
        validaciones.limpiezaRealizada = true;
    }

}
