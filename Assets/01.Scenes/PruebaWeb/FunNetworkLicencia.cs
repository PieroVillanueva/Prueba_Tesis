using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FunNetworkLicencia : MonoBehaviour
{
    [System.Serializable]
    public struct estructuraLicencia{
        [System.Serializable]
        public struct licencia
        {
            public string codigo;
            public string duracion;
            public string fechaLimite;
            public string usado;
        }
        
        public licencia[] licencias;
    }
    public estructuraLicencia todoLicencias;


    [ContextMenu("Leer")]
    public void Leer()
    {
        StartCoroutine(CorrutinaLeer());
    }
    IEnumerator CorrutinaLeer()
    {
        UnityWebRequest web = UnityWebRequest.Get("https://oisvirtualreality-default-rtdb.firebaseio.com/licencias.json");
        yield return web.SendWebRequest();

        if(!web.isNetworkError&& !web.isHttpError)
        {
            Debug.Log("{\"licencias\":"+web.downloadHandler.text+"}");

            string cadenita = "{\"licencias\":" + web.downloadHandler.text + "}";

            todoLicencias = JsonUtility.FromJson<estructuraLicencia>(cadenita);
        }
        else
        {
            Debug.Log("TODO SE DERRUMBO");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
