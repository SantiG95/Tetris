using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEspacios : MonoBehaviour
{
    [SerializeField] Vector2 origen;
    [SerializeField] int ancho;
    [SerializeField] int alto;
    [SerializeField] GameObject espacioGameobject;

    List<GameObject> listaEspacios;
    // Start is called before the first frame update
    void Start()
    {
        listaEspacios = new List<GameObject>();
        for (float alt = origen.y; alt < alto; alt++)  
        {
            for (float anc = origen.x; anc < ancho; anc++)
            {
                GameObject espacioNuevo = Instantiate(espacioGameobject);
                espacioNuevo.transform.position = new Vector2(anc, alt);
                listaEspacios.Add(espacioNuevo);
            }
        }
    }

    public void ocuparCasilla(int posX, int posY)
    {
        listaEspacios[10 * (int)(posY - origen.y) + posX +5].GetComponent<EspacioCasilla>().ocuparCasilla();
    }

    public bool casillaEstaOcupada(int posX, int posY)
    {
        return listaEspacios[10 * (int)(posY - origen.y) + posX + 5].GetComponent<EspacioCasilla>().estaOcupada();
    }
}
