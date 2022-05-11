using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPiezaL : ControlPiezas
{
    [SerializeField] bool piezaInvertida = false;
    [SerializeField] int modificadorGiro = 1;
    [SerializeField] int cantGiros = 0;
    [SerializeField] int invertirGiro = 1;
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
        }

    }

    public new void girarPieza(int direccionGiro)
    {
        cantGiros += direccionGiro;
        if (cantGiros == 2)
        {
            cantGiros = 0;
            if (piezaInvertida) moverPieza(-1 * invertirGiro);
            if (!piezaInvertida) moverPieza(1 * invertirGiro);
            invertirGiro *= -1;
        }
        else if (cantGiros == -2)
        {
            cantGiros = 0;
            if (piezaInvertida) moverPieza(-1 * invertirGiro);
            if (!piezaInvertida) moverPieza(1 * invertirGiro);
            invertirGiro *= -1;
        }


        transform.Rotate(Vector3.forward * 90 * direccionGiro);
        corregirPosicion();

        girarPiezas();

    }
}
