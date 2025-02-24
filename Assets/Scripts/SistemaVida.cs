using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaVida : MonoBehaviour  //gestina el sistema de vida de los personajes (Player y enemigos)
{
    [SerializeField]
    private float vidaInicial;

    [SerializeField]
    public int cristales;
    
    [SerializeField]
    public float vidaActual {get; private set;}

    [SerializeField] private UIManager uimanager;

    [Header("Sonido muerte")]
    [SerializeField] private AudioClip sonidoMuerte;

    Animator animator;

    private void Awake() 
    {
        vidaActual = vidaInicial;
        animator = GetComponent<Animator>();         
        uimanager = FindObjectOfType<UIManager>();   

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

            StartCoroutine(GameOverRetraso(1f)); //llamar a gameover
            }
    }

    public void SumaCristales(int _value)
    {
        cristales = cristales + _value;
    }

    private IEnumerator GameOverRetraso(float delay)  // 2 seg y llama a gameover
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);
    }


                
        
    void Update()
    {
        
    }


}
