using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar_this : MonoBehaviour
{
    // Start is called before the first frame update
public void desactivar_this()
    {
        this.gameObject.SetActive(false);
    }
}
