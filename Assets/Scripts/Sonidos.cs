using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    private AudioSource sonidosJuego;

    public AudioClip movimientoLateral;
    public AudioClip piezaColocada;
    public AudioClip finDelJuego;

    // Start is called before the first frame update
    void Start()
    {
        sonidosJuego = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reproducirSonidoMovimientoLateral()
    {
        sonidosJuego.PlayOneShot(movimientoLateral, 1);
    }

    public void reproducirSonidoPiezaColocada()
    {
        sonidosJuego.PlayOneShot(piezaColocada, 1);
    }

    public void reproducirSonidoFinDelJuego()
    {
        sonidosJuego.PlayOneShot(finDelJuego, 1);
    }

}
