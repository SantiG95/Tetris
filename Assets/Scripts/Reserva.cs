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
                piezaEnJuego.GetComponent<ControlPiezaO>().detenerPieza();
                piezaEnJuego.transform.localPosition = new Vector2(-0.2f, 0.2f);
                break;

            case "Pieza T(Clone)":
                piezaEnJuego.GetComponent<ControlPiezaT>().detenerPieza();
                piezaEnJuego.GetComponent<ControlPiezaT>().resetearPosicion();
                piezaEnJuego.transform.localPosition = new Vector2(0, -0.2f);
                break;

            case ("Pieza L(Clone)"):
                piezaEnJuego.GetComponent<ControlPiezaL>().detenerPieza();
                piezaEnJuego.GetComponent<ControlPiezaL>().resetearPosicion();
                piezaEnJuego.transform.localPosition = new Vector2(-0.8f, 0);
                break;

            case "Pieza L inversa(Clone)":
                piezaEnJuego.GetComponent<ControlPiezaL>().detenerPieza();
                piezaEnJuego.GetComponent<ControlPiezaL>().resetearPosicion();
                piezaEnJuego.transform.localPosition = new Vector2(-0.8f, 0);
                break;

            case ("Pieza S(Clone)"):
                piezaEnJuego.GetComponent<ControlPiezaSZ>().detenerPieza();
                piezaEnJuego.GetComponent<ControlPiezaSZ>().resetearPosicion();
                piezaEnJuego.transform.localPosition = new Vector2(-1f, -0.65f);
                break;

            case "Pieza Z(Clone)":
                piezaEnJuego.GetComponent<ControlPiezaSZ>().detenerPieza();
                piezaEnJuego.GetComponent<ControlPiezaSZ>().resetearPosicion();
                piezaEnJuego.transform.localPosition = new Vector2(-1f, -0.65f);
                break;

            case "Pieza I(Clone)":
                piezaEnJuego.GetComponent<ControlPiezaI>().detenerPieza();
                piezaEnJuego.GetComponent<ControlPiezaI>().resetearPosicion();
                piezaEnJuego.transform.localPosition = new Vector2(0, 0.2f);
                break;
        }

    }
}
