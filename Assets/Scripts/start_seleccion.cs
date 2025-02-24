using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start_seleccion : MonoBehaviour
{
    private RectTransform rect; //para transformar parametros de posicion de elemento (imagen seleccion)

    [SerializeField] private RectTransform[] opciones;
    private int posicion;
    [SerializeField] private AudioClip sonidoPosicion;
    [SerializeField] private AudioClip sonidoSeleccion;

    

    public void Awake()
    {
        rect = GetComponent<RectTransform>();

    }

    private void Update()
    {
        //cambio posicion flecha
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            CambioPosicion(-1);
            
        } else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            CambioPosicion(1);
        }

        //usar opciones
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Interactuar();            
        } 
    }
    

    private void CambioPosicion(int _cambio)
    {
        posicion += _cambio;

        if(_cambio != 0)
        {
            SoundManager.instance.ReproducirSonido(sonidoPosicion);
        }

        if (posicion < 0) 
        {
            posicion = opciones.Length -1;

        } else if (posicion > opciones.Length - 1)
        {
            posicion = 0;
        }
        //mover marcador arriba o abajo , asignando la posicion Y de cada opcion
        rect.position = new Vector3(rect.position.x, opciones[posicion].position.y, 0);

    }

    private void Interactuar()
    {
        SoundManager.instance.ReproducirSonido(sonidoSeleccion);

        //se pulsa el boton
        opciones[posicion].GetComponent<Button>().onClick.Invoke();
    }
}
