using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    [SerializeField] private float dano;
    [SerializeField] private AudioClip danosonido;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D colision) 
    {
       
    if (colision.CompareTag("Player"))
    {
        Debug.Log("Player tocó pinchos");

        SoundManager.instance.ReproducirSonido(danosonido);

        SistemaVida vidaPlayer = colision.GetComponent<SistemaVida>();
        if (vidaPlayer != null)
        {
            vidaPlayer.RecibirDano(dano);
        }
    }

    }
}
