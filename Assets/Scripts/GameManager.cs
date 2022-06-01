using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject finDelJuego;
    public bool juegoCorriendo = true;
    public int puntaje = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void terminarJuego()
    {
        Debug.Log("JUEGO ACABADO");
        juegoCorriendo = false;
        finDelJuego.SetActive(true);
        GameObject.Find("Sonidos").GetComponent<Sonidos>().reproducirSonidoFinDelJuego();
    }

    public void sumarPuntaje(int valor)
    {
        puntaje += valor;
        GameObject.Find("PuntajeTexto").GetComponent<TextMeshPro>().text = "Puntaje: " + puntaje;
    }
}
