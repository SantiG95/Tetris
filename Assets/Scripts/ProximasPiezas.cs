using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximasPiezas : MonoBehaviour
{
    public List<GameObject> posicionesPiezas = new List<GameObject>();
    public List<GameObject> piezasGenerables = new List<GameObject>();
    public List<int> ultimasPiezasCreadas = new List<int>();
    bool juegoComenzado = false;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i< posicionesPiezas.Count; i++)
        {
            int nPieza = -1;
            while(nPieza == -1 || nPieza == ultimasPiezasCreadas[1])
            {
                nPieza = Random.Range(0, 6);
            }
            ultimasPiezasCreadas[1] = ultimasPiezasCreadas[0];
            ultimasPiezasCreadas[0] = nPieza;

            GameObject piezaNueva = Instantiate(piezasGenerables[nPieza]);
            piezaNueva.transform.localScale = new Vector2(0.5f, 0.5f);
            piezaNueva.transform.SetParent(posicionesPiezas[i].transform);
        }
        moverPiezas();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!juegoComenzado)
            {
                arrancarPieza();
                juegoComenzado = true;
            }
            
        }
    }

    void moverPiezas()
    {
        for (int i = 0; i < posicionesPiezas.Count; i++)
        {
            posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(0, 0);
            switch (posicionesPiezas[i].transform.GetChild(0).name)
            {
                case ("Pieza O(Clone)"):
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(-0.2f, 0.2f);
                    break;

                case "Pieza T(Clone)":
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(0, 0.3f);
                    break;

                case ("Pieza L(Clone)"):
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(-0.8f, 0);
                    break;

                case "Pieza L inversa(Clone)":
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(-0.8f, 0);
                    break;

                case ("Pieza S(Clone)"):
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(-1f, -0.65f);
                    break;

                case "Pieza Z(Clone)":
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(-1f, -0.65f);
                    break;

                case "Pieza I(Clone)":
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(0, 0.2f);
                    break;
            }
        }
    }

    public void arrancarPieza()
    {
        prepararPieza(posicionesPiezas[0].transform.GetChild(0).gameObject);
        comenzarPieza(posicionesPiezas[0].transform.GetChild(0).gameObject);
        posicionesPiezas[0].transform.GetChild(0).SetParent(GameObject.Find("PiezasEnJuego").transform);

        for (int i = 1; i < posicionesPiezas.Count; i++)
        {
            posicionesPiezas[i].transform.GetChild(0).transform.SetParent(posicionesPiezas[i - 1].transform);
        }

        crearPiezaNueva();

        moverPiezas();
    }

    void crearPiezaNueva()
    {
        int nPieza = -1;
        while (nPieza == -1 || nPieza == ultimasPiezasCreadas[1])
        {
            nPieza = Random.Range(0, 6);
        }
        ultimasPiezasCreadas[1] = ultimasPiezasCreadas[0];
        ultimasPiezasCreadas[0] = nPieza;

        GameObject piezaNueva = Instantiate(piezasGenerables[nPieza]);
        piezaNueva.transform.localScale = new Vector2(0.5f, 0.5f);
        piezaNueva.transform.SetParent(posicionesPiezas[4].transform);
    }

    void prepararPieza(GameObject pieza)
    {
        posicionesPiezas[0].transform.GetChild(0).localScale = new Vector2(1, 1);
        Vector2 posicionNueva = new Vector2(0, 0);
        switch (pieza.name)
        {
            case ("Pieza O(Clone)"):
                posicionNueva = new Vector2(4, 21);
                break;

            case "Pieza T(Clone)":
                posicionNueva = new Vector2(4, 21);
                break;

            case ("Pieza L(Clone)"):
                posicionNueva = new Vector2(3, 21);
                break;

            case "Pieza L inversa(Clone)":
                posicionNueva = new Vector2(3, 21);
                break;

            case ("Pieza S(Clone)"):
                posicionNueva = new Vector2(2, 19);
                break;

            case "Pieza Z(Clone)":
                posicionNueva = new Vector2(2, 19);
                break;

            case "Pieza I(Clone)":
                posicionNueva = new Vector2(4, 22);
                break;
        }
        posicionesPiezas[0].transform.GetChild(0).position = posicionNueva;

    }

    void comenzarPieza(GameObject pieza)
    {
        switch (pieza.name)
        {
            case ("Pieza O(Clone)"):
                pieza.GetComponent<ControlPiezaO>().comenzarPieza();
                break;

            case "Pieza T(Clone)":
                pieza.GetComponent<ControlPiezaT>().comenzarPieza();
                break;

            case ("Pieza L(Clone)"):
                pieza.GetComponent<ControlPiezaL>().comenzarPieza();
                break;

            case "Pieza L inversa(Clone)":
                pieza.GetComponent<ControlPiezaL>().comenzarPieza();
                break;

            case ("Pieza S(Clone)"):
                pieza.GetComponent<ControlPiezaSZ>().comenzarPieza();
                break;

            case "Pieza Z(Clone)":
                pieza.GetComponent<ControlPiezaSZ>().comenzarPieza();
                break;

            case "Pieza I(Clone)":
                pieza.GetComponent<ControlPiezaI>().comenzarPieza();
                break;
        }
    }
    
}
