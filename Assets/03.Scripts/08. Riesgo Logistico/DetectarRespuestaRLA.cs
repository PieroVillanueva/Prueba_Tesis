using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DetectarRespuestaRLA : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle check;
    public Text respuesta;
    public Text resultadoPuntuacion;
    public bool tipoRpta;
    public Sprite spriteCorrecto;
    public Sprite spriteIncorrecto;
    public GameObject panel;
    public GameObject siguientePanel;
    //public DetectarRespuestaRLA detectar;
    public int puntuacion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            check.isOn = true;
            if (tipoRpta)
            {
                //detectar.puntuacion += 10;
                check.graphic.GetComponent<Image>().sprite = spriteCorrecto;
                respuesta.text = "Respuesta correcta";
                resultadoPuntuacion.GetComponent<DetectarRespuestaRLA>().puntuacion += 10;
                resultadoPuntuacion.text = resultadoPuntuacion.GetComponent<DetectarRespuestaRLA>().puntuacion.ToString();
            }
            else
            {
                check.graphic.GetComponent<Image>().sprite = spriteIncorrecto;
                respuesta.text = "Respuesta incorrecta";
            }
            if (siguientePanel != null)
            {
                siguientePanel.SetActive(true);     
            }
            panel.SetActive(false);
        }
    }
}
