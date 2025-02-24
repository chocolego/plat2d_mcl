using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private AudioClip portalsonido;
    private void OnTriggerEnter2D(Collider2D colision) 
    {
        if (colision.tag == "Player")
        {
            SoundManager.instance.ReproducirSonido(portalsonido);
            SceneManager.LoadScene(3);
        }


    }
}
