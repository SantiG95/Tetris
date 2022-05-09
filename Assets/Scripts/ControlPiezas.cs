using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPiezas : MonoBehaviour
{
    public float tiempoMovimiento = 2;

    public float tiempoParaMoverse = 0;
    public bool moverse = true;
    

    public void hacerMovimientoAbajo()
    {
        tiempoParaMoverse += Time.deltaTime;
        if (tiempoParaMoverse > tiempoMovimiento)
        {
            tiempoParaMoverse = 0;
            transform.position += Vector3.down;
        }
    }

    public void girarPieza(int direccionGiro)
    {
        transform.Rotate(Vector3.forward * 90 * direccionGiro);
    }

}
