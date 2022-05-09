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

            if (!puedeMoverseAbajo())
            {
                Debug.Log("DEJO DE MOVERSE");
                moverse = false;
                return;
            }

            transform.position += Vector3.down;
        }
    }

    private bool puedeMoverseAbajo()
    {
        for (int i = 0; i < 4; i++)
        {
            if (transform.GetChild(i).gameObject.GetComponent<MiniPiezas>().siguienteEspacioEstaOcupado())
            {
                return false;
            }
        }
        return true;
    }

    public void girarPieza(int direccionGiro)
    {
        transform.Rotate(Vector3.forward * 90 * direccionGiro);
        girarPiezas();

    }

    public void girarPiezas()
    {
        for (int i = 0; i < transform.childCount-1; i++)
        {
            transform.GetChild(i).GetComponent<MiniPiezas>().girarMiniPieza();
        }
    }

}
