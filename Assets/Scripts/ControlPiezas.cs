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
        corregirPosicion();

        girarPiezas();

    }

    public void girarPiezas()
    {
        for (int i = 0; i < transform.childCount-1; i++)
        {
            transform.GetChild(i).GetComponent<MiniPiezas>().girarMiniPieza();
        }
    }

    public void moverPieza(int direccionMovimiento)
    {
        if (puedeMoverseAlCostado(direccionMovimiento))
        {
            transform.position += new Vector3(direccionMovimiento, 0, 0);
        }
    }

    public bool puedeMoverseAlCostado(int direccionMovimiento)
    {
        if(direccionMovimiento > 0)
        {
            for (int i = 0; i < transform.childCount -1; i++)
            {
                //Debug.Log(transform.GetChild(i).GetComponent<MiniPiezas>());
                if (transform.GetChild(i).GetComponent<MiniPiezas>().espacioDerechaEstaOcupado())
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                if (transform.GetChild(i).GetComponent<MiniPiezas>().espacioIzquierdaEstaOcupado())
                {
                    return false;
                }
            }
            return true;
        }
    }

    public void corregirPosicion()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).position.x > 4)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else if(transform.GetChild(i).position.x < -5)
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
    }
}
