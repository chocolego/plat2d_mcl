using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private GameObject gameOverpantalla;
    [SerializeField] private AudioClip gameOversonido;

    public void GameOver() 
    {
        gameOverpantalla.SetActive(true);
        SoundManager.instance.ReproducirSonido(gameOversonido);
    }

    public void ReEmpezar()
    {
        SceneManager.LoadScene(1);
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
