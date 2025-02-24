using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecibirDano : MonoBehaviour
{
    Animator animator;
   
   
    [SerializeField]
    private float _vidaMax = 100f;

    public float VidaMax {
        get {
            return _vidaMax;
        }
        set {
            _vidaMax = value;
        }
    }

    [SerializeField]
    private float _vida = 100f;
    
    public float Vida {
        get {
            return _vida;
        }
        set {
            _vida = value;

            //Si la vida baja mas de 0, no puede estar vivo.
            if(_vida <= 0)
            {
                IsVivo = false;
            }
        }
    }
    
    [SerializeField]
    private bool _isVivo = true;

    public bool IsVivo {
        get {
            return _isVivo;
        }
        set {
            _isVivo = value;
            animator.SetBool(AnimacionStrings.isVivo, value);
        }
    }
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        //_vida = _vidaMax;
    }

    
    
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
