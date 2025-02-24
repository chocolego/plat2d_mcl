using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VidaBarra : MonoBehaviour   //controla la bara de vida (corazones) de la UI
{
    [SerializeField] private SistemaVida playerVida;
    [SerializeField]  private Image barraVidaTotal;
    [SerializeField] private Image barraVidaActual;



    // Start is called before the first frame update
    void Start()
    {
        barraVidaTotal.fillAmount = playerVida.vidaActual / 10;
    }

    // Update is called once per frame
    void Update()
    {
        barraVidaActual.fillAmount = playerVida.vidaActual / 10;

    }
}
