using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximasPiezas : MonoBehaviour
{
    public List<GameObject> posicionesPiezas = new List<GameObject>();
    public List<GameObject> piezasGenerables = new List<GameObject>();
    public List<int> ultimasPiezasCreadas = new List<int>();


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
        
    }

    void moverPiezas()
    {
        for (int i = 0; i < posicionesPiezas.Count; i++)
        {
            posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(0, 0);
            switch (posicionesPiezas[i].transform.GetChild(0).name)
            {
                case ("Pieza O(Clone)"):
                    Debug.Log("Pieza O");
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(-0.2f, 0.2f);
                    break;

                case "Pieza T(Clone)":
                    Debug.Log("Pieza T");
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(0, 0.3f);
                    break;

                case ("Pieza L(Clone)"):
                    Debug.Log("Pieza L");
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(-0.8f, 0);
                    break;

                case "Pieza L inversa(Clone)":
                    Debug.Log("Pieza L inversa");
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(-0.8f, 0);
                    break;

                case ("Pieza S(Clone)"):
                    Debug.Log("Pieza S");
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(-1f, -0.4f);
                    break;

                case "Pieza Z(Clone)":
                    Debug.Log("Pieza Z");
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(-1f, -0.4f);
                    break;

                case "Pieza I(Clone)":
                    Debug.Log("Pieza I");
                    posicionesPiezas[i].transform.GetChild(0).localPosition = new Vector2(0, 0.2f);
                    break;
            }
        }
    }

}
