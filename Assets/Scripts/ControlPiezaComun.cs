using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPiezaComun : ControlPiezas
{
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
        }

    }
}
