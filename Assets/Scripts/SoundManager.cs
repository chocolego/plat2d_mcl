using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour  //controlador de sonido
{
    public static SoundManager instance {get; private set;} //acceso publico al get, privado set singleton
    private AudioSource fuente;
    private AudioSource fuenteMusica;

    public void Awake()
    {
        //instance = this;
        
        fuente = GetComponent<AudioSource>();
        fuenteMusica = transform.GetChild(0).GetComponent<AudioSource>();
        float vol = PlayerPrefs.GetFloat("volumenMusica", 1);  //recupera y asigna el volumen de playerprefs
        fuenteMusica.volume = vol;

        //continua la musica en el siguiente nivel sin crear objetos repetidos
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }      
    }

    public void ReproducirSonido(AudioClip _sonido)
    {
        fuente.PlayOneShot(_sonido);
    }

    public void cambiarVolumen(float _cambio)
    {
        float volumenactual = PlayerPrefs.GetFloat("volumenMusica", 1); //obtiene el valor guardado en playerprefs      

        volumenactual += _cambio;

        //comprobacion de vol max
        if(volumenactual > 1.0f)
        {
            volumenactual = 0.0f;
        }
        else if(volumenactual < 0.0f)
        {
            volumenactual = 1.0f;
        }

        fuenteMusica.volume = volumenactual; //cambia volumen

        PlayerPrefs.SetFloat("volumenMusica", volumenactual);  //lo guarda en playerprefs tambien
        PlayerPrefs.Save();
    }

    // public void subirVolumen(float _cambio)
    // {
    //     float volumenactual = PlayerPrefs.GetFloat("volumenMusica", 1); //obtiene el valor guardado en playerprefs      

    //     volumenactual += _cambio;

    //     //comprobacion de vol max
    //     if(volumenactual >= 1.0f)
    //     {
    //         volumenactual = 1.0f;
    //     }

    //     fuenteMusica.volume = volumenactual; //cambia volumen

    //     PlayerPrefs.SetFloat("volumenMusica", volumenactual);  //lo guarda en playerprefs tambien
    //     PlayerPrefs.Save();
    // }

    // public void bajarVolumen(float _cambio)
    // {
    //     float volumenactual = PlayerPrefs.GetFloat("volumenMusica", 1); //obtiene el valor guardado en playerprefs      

    //     volumenactual += _cambio;

    //     //comprobacion de vol max
    //     if(volumenactual <= 0.0f)
    //     {
    //         volumenactual = 0.0f;
    //     }

    //     fuenteMusica.volume = volumenactual; //cambia volumen

    //     PlayerPrefs.SetFloat("volumenMusica", volumenactual);  //lo guarda en playerprefs tambien
    //     PlayerPrefs.Save();
    // }



}
