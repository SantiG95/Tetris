using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPiezas : MonoBehaviour
{
    SiguienteEspacio siguienteEspacio;
    EspacioDerecha espacioDerecha;
    EspacioIzquierda espacioIzquierda;

    GameObject casillaOcupando;
    GridEspacios grid;

    // Start is called before the first frame update
    void Start()
    {
        siguienteEspacio = transform.GetChild(0).gameObject.GetComponent<SiguienteEspacio>();
        espacioDerecha = transform.GetChild(1).gameObject.GetComponent<EspacioDerecha>();
        espacioIzquierda = transform.GetChild(2).gameObject.GetComponent<EspacioIzquierda>();

        grid = GameObject.Find("GridEspacios").GetComponent<GridEspacios>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarPosicion(Vector2 nuevaPosicion)
    {
        transform.localPosition = nuevaPosicion;
    }

    public void girarMiniPieza()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public bool siguienteEspacioEstaOcupado()
    {
        return siguienteEspacio.estaOcupado();
    }

    public bool espacioDerechaEstaOcupado()
    {
        return espacioDerecha.puedeMoverseDerecha();
    }

    public bool espacioIzquierdaEstaOcupado()
    {
        return espacioIzquierda.puedeMoverseIzquierda();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        casillaOcupando = collision.gameObject;
    }

    public void ocuparCasilla()
    {
        grid.ocuparCasilla((int)transform.position.x, (int)transform.position.y, gameObject);
    }

    public bool estaOcupado()
    {
        return grid.casillaEstaOcupada((int)transform.position.x, (int)transform.position.y);
    }
}
