using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool juegoCorriendo = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void terminarJuego()
    {
        Debug.Log("JUEGO ACABADO");
        juegoCorriendo = false;
    }
}