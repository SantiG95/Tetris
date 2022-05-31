using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reserva : MonoBehaviour
{
    [SerializeField] GameObject piezaGuardada = null;
    [SerializeField] GameObject piezasEnJuego;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            guardarEIntercambiarPiezaEnJuego();
        }
    }

    void guardarEIntercambiarPiezaEnJuego()
    {
        int nPieza = piezasEnJuego.transform.childCount;
        GameObject piezaEnJuego = piezasEnJuego.transform.GetChild(nPieza - 1).gameObject;

        if (piezaGuardada)
        {
            piezaGuardada.transform.SetParent(piezasEnJuego.transform);
            piezaGuardada.transform.localScale = new Vector2(1, 1);
            switch (piezaGuardada.name)
            {
                case ("Pieza O(Clone)"):
                    piezaGuardada.transform.position = new Vector2(4, 21);
                    piezaGuardada.GetComponent<ControlPiezaO>().comenzarPieza();
                    break;

                case "Pieza T(Clone)":
                    piezaGuardada.transform.position = new Vector2(4, 21);
                    piezaGuardada.GetComponent<ControlPiezaT>().comenzarPieza();
                    break;

                case ("Pieza L(Clone)"):
                    piezaGuardada.transform.position = new Vector2(3, 21);
                    piezaGuardada.GetComponent<ControlPiezaL>().comenzarPieza();
                    break;

                case "Pieza L inversa(Clone)":
                    piezaGuardada.transform.position = new Vector2(3, 21);
                    piezaGuardada.GetComponent<ControlPiezaL>().comenzarPieza();
                    break;

                case ("Pieza S(Clone)"):
                    piezaGuardada.transform.position = new Vector2(2, 19);
                    piezaGuardada.GetComponent<ControlPiezaSZ>().comenzarPieza();
                    break;

                case "Pieza Z(Clone)":
                    piezaGuardada.transform.position = new Vector2(2, 19);
                    piezaGuardada.GetComponent<ControlPiezaSZ>().comenzarPieza();
                    break;

                case "Pieza I(Clone)":
                    piezaGuardada.transform.position = new Vector2(4, 22);
                    piezaGuardada.GetComponent<ControlPiezaI>().comenzarPieza();
                    break;
            }
        }
        else
        {
            GameObject.Find("Proximas Piezas").GetComponent<ProximasPiezas>().arrancarPieza();
        }

        piezaEnJuego.transform.localScale = new Vector2(0.5f, 0.5f);
        piezaEnJuego.transform.SetParent(GameObject.Find("Reserva").transform);
        piezaGuardada = piezaEnJuego;
        switch (piezaEnJuego.name)
        {
            case ("Pieza O(Clone)"):
                piezaEnJuego.transform.localPosition = new Vector2(-0.2f, 0.2f);
                piezaEnJuego.GetComponent<ControlPiezaO>().detenerPieza();
                break;

            case "Pieza T(Clone)":
                piezaEnJuego.transform.localPosition = new Vector2(0, 0.3f);
                piezaEnJuego.GetComponent<ControlPiezaT>().detenerPieza();
                break;

            case ("Pieza L(Clone)"):
                piezaEnJuego.transform.localPosition = new Vector2(-0.8f, 0);
                piezaEnJuego.GetComponent<ControlPiezaL>().detenerPieza();
                break;

            case "Pieza L inversa(Clone)":
                piezaEnJuego.transform.localPosition = new Vector2(-0.8f, 0);
                piezaEnJuego.GetComponent<ControlPiezaL>().detenerPieza();
                break;

            case ("Pieza S(Clone)"):
                piezaEnJuego.transform.localPosition = new Vector2(-1f, -0.65f);
                piezaEnJuego.GetComponent<ControlPiezaSZ>().detenerPieza();
                break;

            case "Pieza Z(Clone)":
                piezaEnJuego.transform.localPosition = new Vector2(-1f, -0.65f);
                piezaEnJuego.GetComponent<ControlPiezaSZ>().detenerPieza();
                break;

            case "Pieza I(Clone)":
                piezaEnJuego.transform.localPosition = new Vector2(0, 0.2f);
                piezaEnJuego.GetComponent<ControlPiezaI>().detenerPieza();
                break;
        }

    }
}
