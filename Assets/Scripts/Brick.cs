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
    private GameObject manager;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Controller");
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
        // Realizar aqu� cualquier acci�n adicional antes de destruir el ladrillo, si es necesario.
        sumarPuntos(manager);

        Destroy(gameObject);
    }

    private void sumarPuntos(GameObject manager){

        if (manager != null)
        {
            BaseController controller = manager.GetComponent<BaseController>();
            if (controller != null)
            {
                // Ahora puedes acceder a la variable p�blica 'miVariable'
                controller.points += 100;
            }
            else
            {
                Debug.LogError("No se encontr� el componente BaseController en el objeto.");
            }
        }
        else
        {
            Debug.LogError("No se encontr� un objeto con la etiqueta 'Controller'");
        }
    }

}

