using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIPausa : MonoBehaviour
{
    
    [Header ("PAUSA")]
    [SerializeField] 
    private GameObject pausaPantalla;

    private void Awake()
    {
        pausaPantalla.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausaPantalla.activeInHierarchy)  //si esta activa la pantalla pausa y viceversa
            {
                PausarJuego(false);
            }
            else
            {
                PausarJuego(true);
            }
        }
    }

    public void PausarJuego(bool estado)  //is estado = true se pausa, si estado = false se continua
    {
        pausaPantalla.SetActive(estado);

        if (estado)  //si pausa es true, timescale a 0, (el tiempo se para)  || si false, vuelve a 1
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void CambiarVolumenMusica()
    {
        // if(Input.GetKeyDown(KeyCode.Plus))
        // {
        //     SoundManager.instance.bajarVolumen(0.2f);
        // }

        // if(Input.GetKeyDown(KeyCode.Minus))
        // {
        //     SoundManager.instance.bajarVolumen(0.2f);
        // }
        
        SoundManager.instance.cambiarVolumen(0.2f);
        Debug.LogError("volumen +");
    }
    
    
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Salir()
    {
        Application.Quit();
    }

    

}
