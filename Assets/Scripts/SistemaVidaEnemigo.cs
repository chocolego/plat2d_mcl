using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVidaEnemigo : MonoBehaviour  //gestion vida enemigo
{
     [SerializeField]
    private float vidaInicial;

    
    
    [SerializeField]
    public float vidaActual {get; private set;}

    [Header("Sonido muerte")]
    [SerializeField] private AudioClip sonidoMuerte;

    Animator animator;

    private void Awake() 
    {
        vidaActual = vidaInicial;
        animator = GetComponent<Animator>();    

    }

    public void RecibirDano(float _dano)
    {
        vidaActual = Mathf.Clamp(vidaActual - _dano, 0, vidaInicial);
        
        if(vidaActual > 0)
        {
            //recibe dano
            animator.SetTrigger(AnimacionStrings.dano);
            Debug.Log("recibe dano: " + _dano);
        }
        else
        {
            //muerto
            Debug.Log("muerte");
            SoundManager.instance.ReproducirSonido(sonidoMuerte);
            animator.SetTrigger(AnimacionStrings.muerte);
            //GetComponent<PlayerControl>().enabled = false; 
                
        }
    }


    void Update()
    {
        
    }
}
