using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody2D), typeof(ContactoDirecciones))]

public class GoblinControl : MonoBehaviour  //control de enemigo tipo goblin
{

    public float andarVelocidad = 3f;
    public ZonaDetectarScript zonaAtaque;

    Rigidbody2D rb;
    ContactoDirecciones cd;
    Animator animator;

     [SerializeField] SistemaVida vidaGoblin;
     [SerializeField] private AudioClip sonidoataquegob;

    public enum DireccionAndar { Right, Left }

    private DireccionAndar _direccionAndar;
    private Vector2 vectorDireccion = Vector2.right;

    public DireccionAndar Direccion
    {
        get { return _direccionAndar;}
        set { 
            if (_direccionAndar != value)   //si no coincide
            {                               //invertir direccion
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == DireccionAndar.Right)
                {
                    vectorDireccion = Vector2.right;

                } else if(value == DireccionAndar.Left)
                {
                    vectorDireccion = Vector2.left;
                }
            }
            _direccionAndar = value;}
    }

    public bool _tieneTarget = false;
    public bool TieneTarget { get { return _tieneTarget; } 
    private set {
        _tieneTarget = value; 
        animator.SetBool(AnimacionStrings.tieneTarget, value);

    } }

    public bool CanMove {
        get { 
            return animator.GetBool(AnimacionStrings.canMove);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<ContactoDirecciones>();
        animator =GetComponent<Animator>(); 

    }

    
    // Update is called once per frame
    void Update()
    {
        TieneTarget = zonaAtaque.collidersDetectados.Count > 0;
    }

    private void FixedUpdate()   //si el goblin toca pared, invertir direccion
    {                            //si el goblin no puede moverse, bloquear movimiento
        if (cd.esSuelo && cd.esPared)
        {
            InvertirDireccion();
        }
        if (CanMove)
        {
            rb.velocity = new Vector2(andarVelocidad * vectorDireccion.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void InvertirDireccion()
    {
        if(Direccion == DireccionAndar.Right)
        {
            Direccion = DireccionAndar.Left;

        } else if(Direccion == DireccionAndar.Left)
        {
            Direccion = DireccionAndar.Right;
        } else {
            Debug.LogError("Error en invertir direccion.");
        }
      
    }

       public void OnAtacar(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SoundManager.instance.ReproducirSonido(sonidoataquegob);  //sonido ataque
            Debug.Log("Ataque Triggered");

            animator.SetTrigger(AnimacionStrings.atacarTrigger);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

}
