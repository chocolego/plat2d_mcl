using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Camera camara;
    public Transform seguirTarget;

    //punto inicio parallax gameobject
    Vector2 puntoInicio;

    // la flecha hace que el valor se actualice en cada frame
    Vector2 camMovida => (Vector2) camara.transform.position - puntoInicio;



    //start z
    float puntostartZ;

    float distanciaZdePlayer => transform.position.z - seguirTarget.transform.position.z;

    //Si el objeto está delante de player, usar el plano cercano. Si está por detrás, usar plano lejano.
    float plano => (camara.transform.position.z + (distanciaZdePlayer > 0 ? camara.farClipPlane : camara.nearClipPlane));

    //Cuanto más lejano el objeto del player, el efecto parallax aplicado al objeto hará que se mueva más rapido.
    float factorParallax => Mathf.Abs(distanciaZdePlayer) / plano;


    // Start is called before the first frame update
    void Start()
    {
        puntoInicio = transform.position;
        puntostartZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //cuando se mueve el player, el objeto parallax se mueve la misma distancia correspondiente
        Vector2 novaPos = puntoInicio + camMovida * factorParallax;

        //posiciones x e y cambias según melocidad de player, z no cambia (bloqueo)
        transform.position = new Vector3(novaPos.x, novaPos.y, puntostartZ);

    }
}
