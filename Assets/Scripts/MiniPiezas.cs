using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPiezas : MonoBehaviour
{
    SiguienteEspacio siguienteEspacio;
    // Start is called before the first frame update
    void Start()
    {
        siguienteEspacio = transform.GetChild(0).gameObject.GetComponent<SiguienteEspacio>();
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
}
