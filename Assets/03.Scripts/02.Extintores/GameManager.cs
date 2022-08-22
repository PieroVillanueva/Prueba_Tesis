using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int timerGame;
    public bool completeLvl;

    public bool[] tareas;
    public int tareaActual = 0;

    //public bool isInitilize = false;

    
    // Start is called before the first frame update
    
    public void StartGame()
    {
        StartCoroutine(StartTimer());
    }
    IEnumerator StartTimer()
    {
        Debug.ClearDeveloperConsole();
        Debug.Log("iniciamos");
        while (completeLvl == false)
        {
            yield return new WaitForSeconds(1);
            timerGame++;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LimpiarTareas()
    {
        for(int i=0;i<tareas.Length;i++)
        {
            tareas[i] = false;
        }
        tareaActual = 0;
        completeLvl = false;
        timerGame = 0;
    }

    public bool CompletarActividad()
    {
        bool resultado = tareaActual == tareas.Length ? true : false;       
        return resultado;
    }
}
