using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspacioDerecha : MonoBehaviour
{
    [SerializeField] bool espacioOcupado = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.parent.position + Vector3.right;
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

    public bool estaOcupado()
    {
        return espacioOcupado;
    }
}
