using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPiezaI : ControlPiezas
{
    float modificadorGiro = 0.5f;

    

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
        transform.Rotate(Vector3.forward * 90 * direccionGiro);
        transform.position += Vector3.left * modificadorGiro;
        transform.position += Vector3.up * modificadorGiro;
        modificadorGiro *= -1;

        corregirPosicion();
        
        girarPiezas();

    }
}
