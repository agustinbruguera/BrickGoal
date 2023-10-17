using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Color colorInicial;
    public Color colorGolpeado;
    public int golpesNecesarios = 2;

    private int golpesRecibidos;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log("Color Inicial: " + colorInicial);
        spriteRenderer.color = colorInicial;
        Debug.Log("Color SpriteRenderer: " + spriteRenderer.color);
        golpesRecibidos = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            golpesRecibidos++;

            if (golpesRecibidos == 1)
            {
                spriteRenderer.color = colorGolpeado;
                Debug.Log("Primer Golpe");
            }
            else if (golpesRecibidos >= golpesNecesarios)
            {
                Debug.Log("Segundo Golpe");
                DestruirLadrillo();
            }
        }
    }

    private void DestruirLadrillo()
    {
        // Realizar aquí cualquier acción adicional antes de destruir el ladrillo, si es necesario.
        Destroy(gameObject);
    }
}

