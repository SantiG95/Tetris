using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPiezaSZ : ControlPiezas
{
    [SerializeField] bool modificadorInverso;
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

    private new void girarPieza(int direccionGiro)
    {
        cantGiros = 1 + -cantGiros;
        int primerY  = modificadorInverso ? 2 : 1;
        int segundoY = modificadorInverso ? 1 : 2;
        if (cantGiros == 0)
        {
            transform.GetChild(0).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(1, primerY));
            transform.GetChild(1).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(2, primerY));
            transform.GetChild(2).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(2, segundoY));
            transform.GetChild(3).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(3, segundoY));
        }
        else
        {
            transform.GetChild(0).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(segundoY, 1));
            transform.GetChild(1).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(segundoY, 2));
            transform.GetChild(2).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(primerY, 2));
            transform.GetChild(3).GetComponent<MiniPiezas>().cambiarPosicion(new Vector2(primerY, 3));
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
}
