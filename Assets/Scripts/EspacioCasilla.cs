using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspacioCasilla : MonoBehaviour
{
    public List<Sprite> listaSprites;
    [SerializeField] int casillaOcupada;
    [SerializeField] GameObject miniPiezaOcupante;
    SpriteRenderer miSprite;
    // Start is called before the first frame update
    void Start()
    {
        miSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();

        //QUITAR LUEGO
        miSprite.sprite = listaSprites[casillaOcupada];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ocuparCasilla(GameObject miniPiezaOcupadora)
    {
        casillaOcupada = 1;
        miSprite.sprite = listaSprites[casillaOcupada];
        miniPiezaOcupante = miniPiezaOcupadora;
    }

    public bool estaOcupada()
    {
        return casillaOcupada == 1;
    }
}
