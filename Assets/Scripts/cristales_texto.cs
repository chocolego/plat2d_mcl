using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cristales_texto : MonoBehaviour  //controla el texto que informa de los cristales acumulados
{
    [SerializeField] private SistemaVida playerVida;
    [SerializeField] public TextMeshProUGUI textocristales;



    // Start is called before the first frame update
    void Start()
    {
        
        textocristales = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        String c = "Cristales: " + playerVida.cristales + "";
        textocristales.SetText(c);

    }
}
