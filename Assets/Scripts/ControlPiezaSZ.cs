using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPiezaSZ : ControlPiezas
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

    private new void girarPieza(int direccionGiro)
    {
        transform.Rotate(Vector3.forward * (90 - transform.eulerAngles.z * 2));
        Debug.Log(transform.eulerAngles.z);
    }
}
