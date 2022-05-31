using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEspacios : MonoBehaviour
{
    [SerializeField] Vector2 origen;
    [SerializeField] int ancho;
    [SerializeField] int alto;
    [SerializeField] GameObject espacioGameobject;

    List<List<GameObject>> listaEspacios;
    // Start is called before the first frame update
    void Start()
    {
        listaEspacios = new List<List<GameObject>>();
        for (int alt = (int)origen.y; alt < alto; alt++)  
        {
            listaEspacios.Add(new List<GameObject>());
            for (int anc = (int)origen.x; anc < ancho; anc++)
            {
                GameObject espacioNuevo = Instantiate(espacioGameobject);
                espacioNuevo.transform.SetParent(transform);
                espacioNuevo.transform.position = new Vector2(anc, alt);
                listaEspacios[alt].Add(espacioNuevo);
            }
        }
    }

    public void ocuparCasilla(int posX, int posY, GameObject miniPiezaRecibida)
    {
        listaEspacios[posY][posX].GetComponent<EspacioCasilla>().ocuparCasilla(miniPiezaRecibida);
    }

    public bool casillaEstaOcupada(int posX, int posY)
    {
        return listaEspacios[posY][posX].GetComponent<EspacioCasilla>().estaOcupada();
    }

    public void revisarGrid()
    {
        bool lineaCompleta = true;

        for (int alt = (int)origen.y; alt < alto; alt++)
        {
            for (int anc = (int)origen.x; anc < ancho; anc++)
            {
                if (!listaEspacios[alt][anc].GetComponent<EspacioCasilla>().estaOcupada())
                {
                    lineaCompleta = false;
                }
                
            } 
            if (lineaCompleta)
            {
                borrarLinea(alt);
                alt -= 1;
            }
            lineaCompleta = true;
        }
    }

    private void borrarLinea(int nFila)
    {
        //TODO
        for (int anc = (int)origen.x; anc < ancho; anc++)
        {
            listaEspacios[nFila][anc].GetComponent<EspacioCasilla>().liberarCasilla();
        }


        for (int alt = nFila + 1; alt < alto; alt++)
        {
            for (int anc = (int)origen.x; anc < ancho; anc++)
            {
                if (listaEspacios[alt][anc].GetComponent<EspacioCasilla>().estaOcupada())
                {
                    GameObject miniPieza = listaEspacios[alt][anc].GetComponent<EspacioCasilla>().soltarCasilla();
                    listaEspacios[alt - 1][anc].GetComponent<EspacioCasilla>().ocuparCasilla(miniPieza);
                    listaEspacios[alt - 1][anc].GetComponent<EspacioCasilla>().moverAbajoSprite();
                }
            }
        }
    }
}
