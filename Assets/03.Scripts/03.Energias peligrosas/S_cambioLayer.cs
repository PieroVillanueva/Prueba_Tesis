using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_cambioLayer : MonoBehaviour
{
    //Layer 15 grab no snap / 9 grap
    public void CambioLayer(int layer)
    {
        gameObject.layer = layer;
    }
}
