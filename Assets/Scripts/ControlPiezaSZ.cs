using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPiezaSZ : ControlPiezas
{
    [SerializeField] bool piezaInversa = false;
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
        }

    }

    private new void girarPieza(int direccionGiro)
    {
        cantGiros += direccionGiro;
        if(cantGiros == 2)
        {
            cantGiros = 0;
            moverPieza(1);
        }
        else if (cantGiros == -2)
        {
            cantGiros = 0;
            moverPieza(-1);
        }

        transform.Rotate(Vector3.forward * (90 - transform.eulerAngles.z * 2));
        corregirPosicion();

        girarPiezas();
    }
}
