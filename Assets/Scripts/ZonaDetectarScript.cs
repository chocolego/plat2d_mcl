using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDetectarScript : MonoBehaviour
{
    public List<Collider2D> collidersDetectados = new List<Collider2D>();
    Collider2D col;



    // Start is called before the first frame update
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        collidersDetectados.Add(colision);
    }

    private void OnTriggerExit2D(Collider2D colision)
    {
        collidersDetectados.Remove(colision);
    }

}
