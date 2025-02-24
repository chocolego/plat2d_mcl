using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_startMenu : MonoBehaviour
{
   [SerializeField] private GameObject startpantalla;
   

    public void Empezar()
    {
        SceneManager.LoadScene("xogo_scene");
    }


    public void Salir()
    {
        Application.Quit();
    }
}
