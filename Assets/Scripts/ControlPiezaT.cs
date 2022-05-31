using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPiezaT : ControlPiezas
{
    int cantGiros;
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
                girarNuevamente(-1);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                girarPieza(1);
                girarNuevamente(1);
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

    public new void girarPieza(int direccionGiro)
    {
        cantGiros += direccionGiro;
        if (cantGiros > 3) cantGiros = 0;
        if (cantGiros < 0) cantGiros = 3;

        switch (cantGiros)
        {
            case 0:
                transform.GetChild(0).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(-1,  0));
                transform.GetChild(1).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2( 0,  0));
                transform.GetChild(2).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2( 1,  0));
                transform.GetChild(3).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2( 0, -1));
                break;


            case 1:
                transform.GetChild(0).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(0, 1));
                transform.GetChild(1).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(0, 0));
                transform.GetChild(2).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(0, -1));
                transform.GetChild(3).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(-1, 0));
                break;

            case 2:
                transform.GetChild(0).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(1, 0));
                transform.GetChild(1).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(0, 0));
                transform.GetChild(2).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(-1, 0));
                transform.GetChild(3).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(0, 1));
                break;

            case 3:
                transform.GetChild(0).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(0, -1));
                transform.GetChild(1).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(0, 0));
                transform.GetChild(2).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(0, 1));
                transform.GetChild(3).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(1, 0));
                break;
        }
        corregirPosicion();

        girarPiezas();
    }

    public new void girarNuevamente(int numeroGiro)
    {
        bool girar = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<MiniPiezas>().estaOcupado())
            {
                girar = true;
            }
        }
        if (girar) {
            girarPieza(numeroGiro);
            corregirPosicion();
            };
    }

}
