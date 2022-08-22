using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarDocumentos_SO : MonoBehaviour
{
    public List<GameObject> documentos;
    public GameObject panel;
    private int maxDocumentos = 8;
    private int documentosActual = 0;

    public void ColocarDocumento()
    {
        if (documentosActual < maxDocumentos)
        {
            documentos[documentosActual].SetActive(true);
            documentosActual++;
        }
    }

    public void ReiniciarDocumentos()
    {
        foreach (GameObject aux in documentos)
        {
            aux.SetActive(false);
        }
        documentosActual = 0;
    }

    public void MostrarPanel(bool estado)
    {
        panel.SetActive(estado);
        Debug.Log("algo");
    }

    public void QuitarPanelPorMano()
    {
        panel.SetActive(false);
    }
}
