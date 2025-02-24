using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactoDirecciones : MonoBehaviour  
{
    //gestion de contacto con otros elemntos (suelo, pared)
    CapsuleCollider2D col;
    Animator animator;
    public ContactFilter2D contactfilter;
    public float distanciaSuelo = 0.05f;
    public float distanciaPared = 0.2f;
    RaycastHit2D[] tocaSuelo = new RaycastHit2D[5];
    RaycastHit2D[] tocaPared = new RaycastHit2D[5];

    [SerializeField]
    private bool _esSuelo;

    public bool esSuelo { get {
        return _esSuelo; 

    } private set {
        _esSuelo = value;
        animator.SetBool(AnimacionStrings.isGrounded, value);
    } }

    private bool _esPared;

                        //(expr. lambda)    condicion:si esta prop. > 0, devuelve vector.right y viceversa
    private Vector2 calculoPared => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    public bool esPared { get {
        return _esPared; 

    } private set {
        _esPared = value;
        animator.SetBool(AnimacionStrings.isEnPared, value);
    } }

    private void Awake()
    {
        col = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        esSuelo = col.Cast(Vector2.down, contactfilter, tocaSuelo, distanciaSuelo) > 0;
        esPared = col.Cast(calculoPared, contactfilter, tocaPared, distanciaPared) > 0;
    }
}
