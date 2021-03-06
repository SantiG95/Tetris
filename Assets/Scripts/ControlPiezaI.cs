using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPiezaI : ControlPiezas
{
    float modificadorGiro = 0.5f;

    [SerializeField] int cantGiros = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moverse)
        {
            //Movimiento para abajo
            hacerMovimientoAbajo();

            //Giro
            if (Input.GetKeyDown(KeyCode.Z))
            {
                girarPieza(-1);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                girarPieza(1);
            }

            //Desplazamiento
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moverPieza(1);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moverPieza(-1);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                tiempoMovimiento = 0.1f;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                tiempoMovimiento = 2f;
            }
        }
    }

    private new void girarPieza(int direccionGiro)
    {
        cantGiros = 1 + -cantGiros;
        int posicionNueva = 1;
        if (cantGiros == 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(0, posicionNueva));
                posicionNueva -= 1;
                //Debug.Log("la posicion nueva es " + posicionNueva);
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(posicionNueva, 0));
                posicionNueva -= 1;
            }
        }

        corregirPosicion();

        girarPiezas();

    }

    public new void girarNuevamente(int numeroGiro)
    {
        bool girar = false;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            if (transform.GetChild(i).GetComponent<MiniPiezas>().estaOcupado())
            {
                girar = true;
            }
        }
        if (girar) girarPieza(numeroGiro);
    }

    public void resetearPosicion()
    {
        cantGiros = 0;
        int posicionNueva = 1;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(0, posicionNueva));
            posicionNueva -= 1;
        }

        corregirPosicion();
        girarPiezas();
    }
}


