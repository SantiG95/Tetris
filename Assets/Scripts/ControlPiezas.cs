using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPiezas : MonoBehaviour
{
    public float tiempoMovimiento = 2;

    public float tiempoParaMoverse = 0;
    public bool moverse = true;

    GridEspacios grid;

    void Start()
    {
        grid = GameObject.Find("GridEspacios").GetComponent<GridEspacios>();
    }

    void Update()
    {
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().juegoCorriendo)
        {
            moverse = false;
        }
    }


    public void hacerMovimientoAbajo()
    {
        tiempoParaMoverse += Time.deltaTime;
        if (tiempoParaMoverse > tiempoMovimiento)
        {
            tiempoParaMoverse = 0;

            if (!puedeMoverseAbajo())
            {
                moverse = false;
                GameObject.Find("Sonidos").GetComponent<Sonidos>().reproducirSonidoPiezaColocada();
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<MiniPiezas>().ocuparCasilla();
                }
                GameObject.Find("GridEspacios").GetComponent<GridEspacios>().revisarGrid();
                if (GameObject.Find("GameManager").GetComponent<GameManager>().juegoCorriendo)
                {

                    GameObject.Find("Proximas Piezas").GetComponent<ProximasPiezas>().arrancarPieza();
                }
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
            GameObject.Find("Sonidos").GetComponent<Sonidos>().reproducirSonidoMovimientoLateral();
        }
    }

    public bool puedeMoverseAlCostado(int direccionMovimiento)
    {
        if(direccionMovimiento > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
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
            for (int i = 0; i < transform.childCount; i++)
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
            
            if (transform.GetChild(i).position.x > 9)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else if(transform.GetChild(i).position.x < 0)
            {
                transform.position += new Vector3(1, 0, 0);
            }
            if (transform.GetChild(i).GetComponent<MiniPiezas>().estaOcupado())
            {
                //TODO corregir posicion despues del giro
                Debug.Log(transform.localPosition.x + ", " + transform.localPosition.y);
                if (transform.localPosition.y == 0)
                {
                    if (transform.localPosition.x == -1)
                    {

                        transform.position += new Vector3(-1, 0, 0);
                    }
                    else
                    {
                        transform.position += new Vector3(2, 0, 0);
                    }
                }
                else if (transform.localPosition.x == 0)
                {
                    if (transform.localPosition.y == -1)
                    {
                        transform.position += new Vector3(-1, 0, 0);
                    }
                    else
                    {
                        transform.position += new Vector3(1, 0, 0);
                    }
                }
            }
        }
    }

    public void girarNuevamente(int numeroGiro)
    {
        bool girar = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<MiniPiezas>().estaOcupado())
            {
                girar = true;
            }
        }
        if (girar) girarPieza(numeroGiro);
    }

    public void comenzarPieza()
    {
        moverse = true;
    }

    public void detenerPieza()
    {
        moverse = false;
    }
}
