using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumetexto : MonoBehaviour
{
    [SerializeField] private string NombreVol;
    [SerializeField] private string textoVol; //Sound:  or Music:
    private Text texto;

    private void Awake()
    {
        texto = GetComponent<Text>();
    }
    private void Update()
    {
        MuestraVol();
    }
    private void MuestraVol()
    {
        float volumeVal = PlayerPrefs.GetFloat("volumenMusica", 1) * 100;  //vol 0 a 1 pasa a 0 a 100  y recupera de player.prefs
        texto.text = textoVol + volumeVal.ToString();
    }
}
