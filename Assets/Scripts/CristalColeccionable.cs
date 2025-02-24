using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalColeccionable : MonoBehaviour
{
    [SerializeField] private AudioClip cristalsonido;
    private int numerocristales;

    private void OnTriggerEnter2D(Collider2D colision) 
    {
        if (colision.tag == "Player")
        {
            SoundManager.instance.ReproducirSonido(cristalsonido);
            colision.GetComponent<SistemaVida>().SumaCristales(1);
            gameObject.SetActive(false);
        }


    }
}
