using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerControl : MonoBehaviour  //control de Player (jugador principal)
{
    public float andarVelocidad = 5f;
    public float correrVeloc = 8f;
    public float impulsoSalto = 10f;

    
    Rigidbody2D rb;
    Animator animator;


    Vector2 moverInput;
    ContactoDirecciones cd;

    [SerializeField] SistemaVida vidaplayer;

    [Header("sonidos")]
    [SerializeField] private AudioClip sonidoespada;
    [SerializeField] private AudioClip sonidosalto;

    


    public float velocActual { get
        {
            if(CanMove) //si puede moverse (no bloqueado)
            {
                if (IsMoving && !cd.esPared)
                {
                    if (IsRunning)
                    {
                        return correrVeloc;
                    }
                    else
                    {
                        return andarVelocidad;
                    }
                }
                else
                {
                    return 0;  //Si no se mueve (ni andar ni correr), la velocidad es 0.
                }
            } else {
                return 0;  //bloqueamos
            }
        }
    }
    

    [SerializeField]  //para ver la propiedad en el Inspector
    private bool _isMoving = false;

    public bool IsMoving { get
        {
                return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimacionStrings.isMoving, value);
        }
    }

    [SerializeField]
    private bool _isRunning = false;
    
    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
            animator.SetBool(AnimacionStrings.isRunning, value);
        }
    }
    
    public bool _isHaciaDerecha = true;
    

    public bool IsHaciaDerecha { get { return _isHaciaDerecha; } private set {
        if (_isHaciaDerecha != value)
        {
           //girar player a la direccion opuesta
           transform.localScale *= new Vector2(-1, 1);     //invertira la direccion que tenga en ese momento        
        }
        _isHaciaDerecha = value;
    } }

    public bool CanMove { get {     //usada para comprobar si puede moverse o no (para bloqueo por ataque, por ej)
        return animator.GetBool(AnimacionStrings.canMove); } 
    }



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cd = GetComponent<ContactoDirecciones>();
        vidaplayer = GetComponent<SistemaVida>();


        if (rb == null) Debug.LogError("Rigidbody2D component missing!");
        if (animator == null) Debug.LogError("Animator component missing!");
        if (cd == null) Debug.LogError("ContactoDirecciones component missing!");

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //usa el otro update
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moverInput.x * velocActual, rb.velocity.y);
        animator.SetFloat(AnimacionStrings.velocidadY, rb.velocity.y);
    }

    public void onMove(InputAction.CallbackContext context)
    {
        moverInput = context.ReadValue<Vector2>();
        IsMoving = moverInput != Vector2.zero;

        setDireccion(moverInput);

        Debug.Log("Mover Input: " + moverInput); // debug

    }

    private void setDireccion(Vector2 moverInput)
    {
        if (moverInput.x > 0 && !IsHaciaDerecha) // valor positivo: hacia derecha
        {
            IsHaciaDerecha = true;
        } else if (moverInput.x < 0 && IsHaciaDerecha) //valor negativo: izquierda
        {
            IsHaciaDerecha = false;
        }
    }

    public void OnCorrer(InputAction.CallbackContext context) 
    {
        if (context.started)   //segun context (tecla pulsada)
        {
            IsRunning = true;
        } else if (context.canceled)
        {
            IsRunning = false;
        }
    }

    public void OnSaltar(InputAction.CallbackContext context)
    {
        if (context.started && cd.esSuelo)
        {
            Debug.Log("Salto Triggered");
            SoundManager.instance.ReproducirSonido(sonidosalto);
            animator.SetTrigger(AnimacionStrings.saltarTrigger);
            rb.velocity = new Vector2(rb.velocity.x, impulsoSalto);
        }
    }


    public void OnAtacar(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SoundManager.instance.ReproducirSonido(sonidoespada);  //sonido ataque
            Debug.Log("Ataque Triggered");
            animator.SetTrigger(AnimacionStrings.atacarTrigger);
        }
    }

    public void OnHit(float dano)
    {
        vidaplayer.RecibirDano(dano);
        animator.SetTrigger(AnimacionStrings.dano);
    }





}
