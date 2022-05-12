using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspacioDerecha : MonoBehaviour
{
    [SerializeField] bool espacioOcupado = false;
    GridEspacios grid;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.parent.position + Vector3.right;

        grid = GameObject.Find("GridEspacios").GetComponent<GridEspacios>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        espacioOcupado = collision.gameObject.GetComponent<EspacioCasilla>().estaOcupada();
        //Debug.Log("El espacio derecha esta " + collision.gameObject.GetComponent<EspacioCasilla>().estaOcupada());
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        espacioOcupado = false;
    }

    public bool puedeMoverseDerecha()
    {
        if (transform.position.x > 4) return true;
        return grid.casillaEstaOcupada((int)transform.position.x, (int)transform.position.y);
    }
}
