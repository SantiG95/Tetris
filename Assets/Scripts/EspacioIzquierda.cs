using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspacioIzquierda : MonoBehaviour
{
    [SerializeField] bool espacioOcupado = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.parent.position + Vector3.left;
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

    public bool estaOcupado()
    {
        return espacioOcupado;
    }
}
