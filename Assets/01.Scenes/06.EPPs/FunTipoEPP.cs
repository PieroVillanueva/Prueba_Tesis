using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunTipoEPP : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Version { A, B, C, D, E, F, G, H };
    public enum ParteCuerpo { Cabeza, Ojos, Oidos, Manos, Respiratoria, Ropa, Pies };
    public Version version;
    public ParteCuerpo parteCuerpo;
    public string descripcion;
    public string nombreTecnico;
    public AudioClip audioDescripcion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
