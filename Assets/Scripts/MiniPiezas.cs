using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPiezas : MonoBehaviour
{
    SiguienteEspacio siguienteEspacio;
    EspacioDerecha espacioDerecha;
    EspacioIzquierda espacioIzquierda;

    // Start is called before the first frame update
    void Start()
    {
        siguienteEspacio = transform.GetChild(0).gameObject.GetComponent<SiguienteEspacio>();
        espacioDerecha = transform.GetChild(1).gameObject.GetComponent<EspacioDerecha>();
        espacioIzquierda = transform.GetChild(2).gameObject.GetComponent<EspacioIzquierda>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void girarMiniPieza()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public bool siguienteEspacioEstaOcupado()
    {
        return siguienteEspacio.estaOcupado();
    }

    public bool espacioDerechaEstaOcupado()
    {
        return espacioDerecha.estaOcupado();
    }

    public bool espacioIzquierdaEstaOcupado()
    {
        return espacioIzquierda.estaOcupado();
    }
}
