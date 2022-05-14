using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspacioIzquierda : MonoBehaviour
{
    [SerializeField] bool espacioOcupado = false;

    GridEspacios grid;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.parent.position + Vector3.left;

        grid = GameObject.Find("GridEspacios").GetComponent<GridEspacios>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        espacioOcupado = collision.gameObject.GetComponent<EspacioCasilla>().estaOcupada();
        //Debug.Log("El espacio izquierda esta " + collision.gameObject.GetComponent<EspacioCasilla>().estaOcupada());
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        espacioOcupado = false;
    }

    public bool puedeMoverseIzquierda()
    {
        if(transform.position.x < 0) return true;
        return grid.casillaEstaOcupada((int)transform.position.x, (int)transform.position.y);

    }
}
