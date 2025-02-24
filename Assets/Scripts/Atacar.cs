using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MonoBehaviour  //gestion del ataque (causar daño)
{
    [SerializeField] private float danoAtaque = 1;
    
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
        //Golpear
        SistemaVida targetVida= colision.GetComponent<SistemaVida>();

        targetVida.RecibirDano(danoAtaque);
        Debug.Log("tag: " + gameObject.tag + " golpe ataque: " + danoAtaque);

    }
}
